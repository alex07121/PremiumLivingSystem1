-- ============================================================
-- MODULE 7: PROCUREMENT (PURCHASE ORDER) — v5.0 NEW
-- Premium Living Furniture Co. Ltd.
-- ITP4915M System Development Project 2025/2026
--
-- Purpose: Inventory Clerks issue Purchase Orders to Suppliers
--          when stock falls below the reorder threshold.
--          Based on Case Study §7.4 (Inventory Control Department).
--
-- ID Format:
--   PurchaseOrder:    PO-YYYYMMDD-NNN     (e.g. PO-20260619-001)
--   PurchaseOrderItem: POI-NNN            (e.g. POI-001)
--
-- Status Flow:
--   Draft → Sent → PartiallyReceived → Received  (normal happy path)
--          ↘ Cancelled                              (canceled before sending)
--
-- Payment Flow:
--   Unpaid → Partial → Paid   (driven by Finance department)
-- ============================================================

-- ============================================================
-- 1. DROP (in dependency order)
-- ============================================================
SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS PurchaseOrderItem;
DROP TABLE IF EXISTS PurchaseOrder;
SET FOREIGN_KEY_CHECKS = 1;

-- ============================================================
-- 2. REGISTER IN ID_SEQUENCE
--    (must run AFTER the ID_Sequence table is created and seeded
--     in system.sql — these INSERTs are idempotent via ON DUPLICATE)
-- ============================================================
INSERT INTO ID_Sequence (SeqName, CurrentVal) VALUES
  ('PurchaseOrder', 0),
  ('PurchaseOrderItem', 0)
ON DUPLICATE KEY UPDATE SeqName = SeqName;

-- ============================================================
-- 3. PURCHASE ORDER (HEADER)
-- ============================================================
CREATE TABLE PurchaseOrder (
  PurchaseOrderID     VARCHAR(30) PRIMARY KEY,
  SupplierID          VARCHAR(20) NOT NULL,
  OrderDate           DATE NOT NULL DEFAULT (CURRENT_DATE),
  ExpectedDeliveryDate DATE,                            -- when goods should arrive
  ActualDeliveryDate  DATE NULL,                        -- filled when fully received

  -- Lifecycle
  Status              ENUM('Draft','Sent','PartiallyReceived','Received','Cancelled')
                      NOT NULL DEFAULT 'Draft',
  PaymentStatus       ENUM('Unpaid','Partial','Paid') NOT NULL DEFAULT 'Unpaid',
  PaymentMethod       ENUM('Cash','Cheque','BankTransfer','CreditCard','FPS')
                      DEFAULT 'BankTransfer',

  -- Money (denormalized for report convenience; items carry line totals)
  SubTotal            DECIMAL(14,2) NOT NULL DEFAULT 0,
  TaxAmount           DECIMAL(14,2) NOT NULL DEFAULT 0,
  TotalAmount         DECIMAL(14,2) NOT NULL DEFAULT 0,

  -- Audit / approval
  CreatedBy           VARCHAR(20) NOT NULL,             -- Inventory Clerk who issues PO
  CreatedAt           DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  ApprovedBy          VARCHAR(20) NULL,                 -- Supervisor approval (optional)
  ApprovedDate        DATETIME NULL,
  SentDate            DATETIME NULL,                    -- when PO was emailed to supplier

  Remarks             TEXT,

  FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID),
  FOREIGN KEY (CreatedBy)  REFERENCES Staff(StaffID),
  FOREIGN KEY (ApprovedBy) REFERENCES Staff(StaffID)
);

-- ============================================================
-- 4. PURCHASE ORDER ITEM (LINE ITEMS)
-- ============================================================
CREATE TABLE PurchaseOrderItem (
  POItemID            VARCHAR(20) PRIMARY KEY,
  PurchaseOrderID     VARCHAR(30) NOT NULL,
  MaterialID          VARCHAR(20) NOT NULL,

  -- Snapshot of the order (price/qty locked at PO time)
  Quantity            DECIMAL(12,2) NOT NULL,
  Unit                VARCHAR(20) NOT NULL,             -- copied from RawMaterial at PO time
  UnitPrice           DECIMAL(12,2) NOT NULL,
  LineTotal           DECIMAL(14,2) GENERATED ALWAYS AS (Quantity * UnitPrice) STORED,

  -- Goods receipt tracking (filled incrementally as deliveries arrive)
  ReceivedQty         DECIMAL(12,2) NOT NULL DEFAULT 0,
  OutstandingQty      DECIMAL(12,2) GENERATED ALWAYS AS (Quantity - ReceivedQty) STORED,

  -- Optional link to the MaterialRequest that triggered this purchase
  MaterialRequestID   VARCHAR(20) NULL,

  Remarks             VARCHAR(255),

  FOREIGN KEY (PurchaseOrderID)   REFERENCES PurchaseOrder(PurchaseOrderID) ON DELETE CASCADE,
  FOREIGN KEY (MaterialID)        REFERENCES RawMaterial(MaterialID),
  FOREIGN KEY (MaterialRequestID) REFERENCES MaterialRequest(RequestID)
);

-- ============================================================
-- 5. TRIGGERS — auto-generate IDs (matches existing trigger style)
-- ============================================================
DELIMITER $$

-- Purchase Order ID:  PO-YYYYMMDD-NNN  (daily sequence)
CREATE TRIGGER trg_purchaseorder_id BEFORE INSERT ON PurchaseOrder FOR EACH ROW
BEGIN
    DECLARE today_str VARCHAR(8);
    DECLARE daily_count INT;
    SET today_str = DATE_FORMAT(NEW.OrderDate, '%Y%m%d');
    INSERT INTO ID_Sequence (SeqName, CurrentVal)
        VALUES (CONCAT('PurchaseOrder_', today_str), 1)
        ON DUPLICATE KEY UPDATE CurrentVal = CurrentVal + 1;
    SELECT CurrentVal INTO daily_count
        FROM ID_Sequence WHERE SeqName = CONCAT('PurchaseOrder_', today_str);
    SET NEW.PurchaseOrderID = CONCAT('PO-', today_str, '-', LPAD(daily_count, 3, '0'));
END$$

-- Purchase Order Item ID:  POI-NNN  (global sequence)
CREATE TRIGGER trg_purchaseorderitem_id BEFORE INSERT ON PurchaseOrderItem FOR EACH ROW
BEGIN
    DECLARE n INT;
    UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'PurchaseOrderItem';
    SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'PurchaseOrderItem';
    SET NEW.POItemID = CONCAT('POI-', LPAD(n, 3, '0'));
END$$

DELIMITER ;

-- ============================================================
-- 6. SAMPLE DATA
--    (Run after Supplier, RawMaterial, Staff, MaterialRequest are populated)
-- ============================================================

INSERT INTO PurchaseOrder
  (PurchaseOrderID, SupplierID, OrderDate, ExpectedDeliveryDate, ActualDeliveryDate,
   Status, PaymentStatus, PaymentMethod,
   SubTotal, TaxAmount, TotalAmount,
   CreatedBy, CreatedAt, ApprovedBy, ApprovedDate, SentDate, Remarks)
VALUES
  -- PO 1: Fully received, paid — Solid Oak Wood restock
  ('PO-20260110-001', 'SUP-001', '2026-01-10', '2026-01-25', '2026-01-24',
   'Received', 'Paid', 'BankTransfer',
   18000.00, 0.00, 18000.00,
   'S-005', '2026-01-10 09:30:00', 'S-006', '2026-01-10 11:00:00',
   '2026-01-10 14:00:00', 'Restock Solid Oak Wood — triggered by low stock alert'),

  -- PO 2: Partially received, partial payment — Grey Fabric
  ('PO-20260215-001', 'SUP-002', '2026-02-15', '2026-03-01', NULL,
   'PartiallyReceived', 'Partial', 'BankTransfer',
   42000.00, 0.00, 42000.00,
   'S-005', '2026-02-15 10:00:00', 'S-006', '2026-02-15 14:00:00',
   '2026-02-15 16:00:00', 'Quarterly fabric restock — 600m² split delivery'),

  -- PO 3: Sent, unpaid — Steel Frames for upcoming production
  ('PO-20260305-001', 'SUP-003', '2026-03-05', '2026-03-22', NULL,
   'Sent', 'Unpaid', 'Cheque',
   27000.00, 0.00, 27000.00,
   'S-006', '2026-03-05 09:15:00', 'S-005', '2026-03-05 10:30:00',
   '2026-03-05 13:00:00', 'Steel frames for office chair production batch'),

  -- PO 4: Draft, not yet sent — Foam for cushion production
  ('PO-20260318-001', 'SUP-004', '2026-03-18', '2026-04-05', NULL,
   'Draft', 'Unpaid', 'BankTransfer',
   16500.00, 0.00, 16500.00,
   'S-006', '2026-03-18 11:00:00', NULL, NULL,
   NULL, 'Pending supervisor approval — high-density foam + filling'),

  -- PO 5: Cancelled — supplier out of stock
  ('PO-20260220-001', 'SUP-005', '2026-02-20', '2026-03-10', NULL,
   'Cancelled', 'Unpaid', 'CreditCard',
   4800.00, 0.00, 4800.00,
   'S-005', '2026-02-20 14:30:00', 'S-006', '2026-02-20 15:00:00',
   NULL, 'Cancelled — supplier cannot meet required delivery date');

-- Purchase Order Items (POItemID is auto-generated by trigger; pass NULL)
INSERT INTO PurchaseOrderItem
  (POItemID, PurchaseOrderID, MaterialID, Quantity, Unit, UnitPrice,
   ReceivedQty, MaterialRequestID, Remarks)
VALUES
  -- PO 1 items — fully received
  (NULL, 'PO-20260110-001', 'MAT-001',  40.00, 'm³',  450.00,
   40.00, NULL, 'Solid Oak Wood — 40m³ at $450/m³'),
  (NULL, 'PO-20260110-001', 'MAT-003',  60.00, 'pcs',  35.00,
   60.00, NULL, 'Plywood Sheet — 60pcs at $35/pc'),

  -- PO 2 items — partial receipt (400 of 600m² arrived)
  (NULL, 'PO-20260215-001', 'MAT-004', 600.00, 'm²',   70.00,
   400.00, NULL, 'Fabric Grey — 600m², 400 received'),
  (NULL, 'PO-20260215-001', 'MAT-005',   0.00, 'm²',    0.00,
   0.00,   NULL, 'PLACEHOLDER — removed from order (kept for audit)'),

  -- PO 3 items — not yet received
  (NULL, 'PO-20260305-001', 'MAT-008',  90.00, 'pcs',  150.00,
   0.00,   NULL, 'Steel Frame 50mm — 90pcs'),
  (NULL, 'PO-20260305-001', 'MAT-009',  90.00, 'set',  150.00,
   0.00,   NULL, 'Metal Bracket Set — 90 sets'),

  -- PO 4 items — draft, not received
  (NULL, 'PO-20260318-001', 'MAT-010',  60.00, 'pcs',  150.00,
   0.00,   'MR-0001', 'High-Density Foam — linked to MR-0001'),
  (NULL, 'PO-20260318-001', 'MAT-011',  75.00, 'kg',   100.00,
   0.00,   'MR-0001', 'Soft Cushion Filling — linked to MR-0001');

-- ============================================================
-- 7. (Optional) VIEW — open procurement summary
-- ============================================================
CREATE OR REPLACE VIEW vw_OpenProcurement AS
SELECT
    po.PurchaseOrderID,
    po.SupplierID,
    sup.SupplierName,
    po.OrderDate,
    po.ExpectedDeliveryDate,
    po.Status,
    po.PaymentStatus,
    po.TotalAmount,
    COUNT(poi.POItemID) AS ItemCount,
    SUM(poi.OutstandingQty) AS TotalOutstanding
FROM PurchaseOrder po
JOIN Supplier sup           ON po.SupplierID = sup.SupplierID
LEFT JOIN PurchaseOrderItem poi ON po.PurchaseOrderID = poi.PurchaseOrderID
WHERE po.Status IN ('Sent','PartiallyReceived')
GROUP BY po.PurchaseOrderID, sup.SupplierName
ORDER BY po.ExpectedDeliveryDate;
