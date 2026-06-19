# Raw Materials / Products Transfer Form — 實作驗證文檔

## 對應 Case Study

**來源**: Case Study Section 7.4.1 Raw Materials / Product Transfer Form (附錄表格)

## 一、Database Schema (system.sql)

### RawMaterialTransfer 表

| 欄位 | 型別 | Transfer Form 對應 | 來源 |
|------|------|-------------------|------|
| TransferID | VARCHAR(20) PK | Transfer Number (自動: IT + YYMMDD + 流水號) | trigger |
| TransferDate | DATE | Date of issues | 用戶輸入 |
| TransferType | ENUM | ☐ Raw Materials / ☐ Products | RadioButton |
| OrderID | VARCHAR(30) | Order ID | 用戶輸入 |
| ProductionID | VARCHAR(30) | Production ID | 用戶輸入 |
| RequestedBy | VARCHAR(20) FK→Staff | Requested By (簽名) | UserSession |
| FromLocation | VARCHAR(100) | Transfer From | 用戶輸入 |
| ToLocation | VARCHAR(100) | To | 用戶輸入 |
| Status | ENUM | Draft/Pending/Approved/Issued/Received | 系統狀態 |
| ApprovedBy | VARCHAR(20) FK→Staff | Approved By (Supervisor/Manager) | ComboBox |
| ApprovedDate | DATE | Approved Date | DateTimePicker |
| IssuedBy | VARCHAR(20) FK→Staff | Issued By (倉庫出貨人) | ComboBox |
| IssuedDate | DATE | Date Issued | DateTimePicker |
| ReceivedBy | VARCHAR(20) FK→Staff | Received By | ComboBox |
| ReceivedDate | DATE | Received Date | DateTimePicker |
| Remarks | TEXT | Comments (availability notes, etc.) | 用戶輸入 |

### RawMaterialTransferItem 表

| 欄位 | 型別 | Transfer Form 對應 | 來源 |
|------|------|-------------------|------|
| TransferItemID | VARCHAR(20) PK | (auto) | trigger |
| TransferID | VARCHAR(20) FK | (header link) | 系統 |
| MaterialID | VARCHAR(20) FK→RawMaterial | Item ID* (when Material) | ComboBox |
| ProductID | VARCHAR(20) FK→Product | Item ID* (when Product) | ComboBox |
| Quantity | DECIMAL(12,2) | Quantity | NumericUpDown |
| Unit | VARCHAR(20) | Unit | from DB |
| Description | VARCHAR(255) | Description | from DB |

### Staff 表 (新增欄位)

| 欄位 | 用途 |
|------|------|
| Phone | Contact Number of Requestor (Requestor Details) |

### 對應完整性: **22/22 欄位 = 100%**

---

## 二、C# 實作檔案

| 檔案 | 行數 | 功能 |
|------|------|------|
| `UcTransferForm.Designer.cs` | ~500 | 完整 UI 佈局 (5×GroupBox: Header/Requestor/Items/Authorization/Inventory) |
| `UcTransferForm.cs` | ~310 | 全部商業邏輯 |

### 核心方法

| 方法 | 功能 |
|------|------|
| `GenerateTransferID()` | 格式 IT + YYMMDD + 4位流水號 (含日期切換自動歸零) |
| `LoadStaffDropdowns()` | JOIN Staff + Jobs → 填充 Approved By / Received By / Issued By 三個 ComboBox |
| `LoadCurrentUser()` | 從 UserSession 自動填入登入用戶的 Name, Position, Phone |
| `LoadItemList()` | 根據 RadioButton (Material/Product) 動態切換 cmbItem 資料來源 |
| `btnAddRow_Click()` | 防重複檢查 → 加 row 到 DataGridView |
| `SaveTransfer(status)` | Transaction: INSERT RawMaterialTransfer header → foreach row INSERT RawMaterialTransferItem → COMMIT |

### 關鍵字檢查

```csharp
// ✅ 所有連接字串使用 Program.ConnectionString (無硬編碼)
// ✅ INNER JOIN Jobs ON Staff.Job_ID = Jobs.Job_ID (正確 FK)
// ✅ Transaction commit (確保原子性)
// ✅ MaterialID / ProductID 互斥寫入 (根據 rbMaterial.Checked 決定)
```

---

## 三、操作流程

```
1. Inventory Clerk 登入
2. 點擊 "Update Stock" 按鈕
3. 系統自動生成 Transfer ID (例: IT2506110001)
4. 系統自動填入 Requestor (Name + Position + Phone from UserSession)
5. 選擇 Material 或 Product (RadioButton → cmbItem 自動切換)
6. 從 ComboBox 選取 Item → 輸入 Quantity → Add
7. 填寫 Transfer From / To 地點
8. 選擇 Approved By / Received By / Issued By (from Staff dropdown)
9. 填寫各日期欄位
10. 點擊 Save as Draft (Status=Draft) 或 Submit (Status=Pending)
11. Transaction 一次性寫入 RawMaterialTransfer + RawMaterialTransferItem
```

---

## 四、與 Case Study 原版對照

| Case Study 表格區域 | 實作狀態 |
|---------------------|---------|
| Transfer Number: __IT2600642__ | ✅ DB trigger 生成 (C# 不傳入，INSERT 後查回) |
| Date of issues | ✅ DateTimePicker (顯示用) |
| Order ID | ✅ TextBox |
| Production ID | ✅ TextBox |
| ☐ Raw Materials / ☐ Products | ✅ RadioButton 雙模式 |
| Requestor: Name / Position / Contact | ✅ Auto-fill from UserSession |
| Item ID* / Description / Quantity / Unit | ✅ DataGridView |
| Transfer From / To | ✅ TextBox |
| Requested By (Signature) / Date | ✅ Staff ID auto + dtpReqDate → TransferDate |
| Approved By (Supervisor) / Date | ✅ ComboBox + DateTimePicker |
| Received By | ✅ ComboBox |
| For Inventory Dept Use: Issued By / Date / Comments | ✅ ComboBox + DateTimePicker + TextBox |

## 五、子 AI 審查修復記錄

| 問題 | 狀態 |
|------|------|
| E1: DB trigger 覆蓋 C# TransferID | ✅ 已修: 不傳入 TransferID，讓 trigger 生成，INSERT 後查回 |
| C1: dtpReqDate 孤兒欄位 | ✅ 已修: dtpReqDate.Value → TransferDate |
