-- ============================================================
-- Premium Living Furniture Co. Ltd.
-- ITP4915M System Development Project 2025/2026
-- Complete SQL v5.5
--
-- What's new in v5.5:
--   [Customization]  CustomizationImage.ImageURL (VARCHAR 500) replaced with
--                    ImageData (LONGBLOB NOT NULL) — images now stored directly
--                    in the database as binary blobs (no more file-system copy)
--
-- What's new in v5.4:
--   [Transfer]       ADD 'Delivering' status + DeliveredBy/DeliveringDate columns
--                    Logistics Staff handles delivery between Issued and Received
--
-- What's new in v5.3:
--   [MaterialRequest] REDESIGNED — split into MaterialRequest (header) +
--                      MaterialRequestItem (items) for multi-material per request
--
-- What's new in v5.2:
--   [BOM]            NEW TABLE ProductMaterial (Bill of Materials)
--                    links Product → RawMaterial with QuantityPerUnit
--
-- What's new in v5.1:
--   [RawMaterial]    ADD UnitPurchasePrice column (standard cost for PO auto-fill)
--
-- What's new in v5.0:
--   [Procurement]   NEW TABLE PurchaseOrder + PurchaseOrderItem
--                   + triggers + sample data + summary view
--
-- What's new in v4.0:
--   [Quotation]      NEW TABLE Quotation + QuotationItem
--   [Production]     NEW TABLE ProductionTracking (8-step) + MaterialRequest
--   [Inventory]      NEW TABLE RawMaterialTransfer + RawMaterialTransferItem
--   [Order]          ADD QuotationID (FK), PaymentStatus
--   [OrderItem]      ADD SerialNumber (XX#######)
--   [Invoice]        ADD BillingAddress, DispatchDate, DeliveryMethod, OtherCharges, Remarks
--   [DeliveryNote]   ADD InvoiceAddress
-- ============================================================

DROP DATABASE IF EXISTS PLFCDB;
CREATE DATABASE IF NOT EXISTS PLFCDB
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE PLFCDB;

SET FOREIGN_KEY_CHECKS = 0;
-- [v5.0 NEW] Procurement tables (drop items first, then header)
DROP TABLE IF EXISTS PurchaseOrderItem;
DROP TABLE IF EXISTS PurchaseOrder;
-- [v5.3 NEW] MaterialRequestItem must drop before MaterialRequest
DROP TABLE IF EXISTS MaterialRequestItem;
DROP TABLE IF EXISTS QuotationItem;
DROP TABLE IF EXISTS Quotation;
DROP TABLE IF EXISTS ProductionTracking;
DROP TABLE IF EXISTS MaterialRequestItem;       -- [v5.3 NEW] items before header
DROP TABLE IF EXISTS MaterialRequest;
DROP TABLE IF EXISTS RawMaterialTransferItem;
DROP TABLE IF EXISTS RawMaterialTransfer;
DROP TABLE IF EXISTS InvoiceItem;
DROP TABLE IF EXISTS Invoice;
DROP TABLE IF EXISTS ReturnImage;
DROP TABLE IF EXISTS ReturnRequest;
DROP TABLE IF EXISTS ComplaintImage;
DROP TABLE IF EXISTS Complaint;
DROP TABLE IF EXISTS RawMaterialMovement;
DROP TABLE IF EXISTS ProductMaterial;       -- [v5.2 NEW] BOM: must drop before RawMaterial & Product
DROP TABLE IF EXISTS RawMaterial;
DROP TABLE IF EXISTS ReplySlip;
DROP TABLE IF EXISTS DeliveryTracking;
DROP TABLE IF EXISTS DeliveryNoteItem;
DROP TABLE IF EXISTS DeliveryNote;
DROP TABLE IF EXISTS CustomizationImage;
DROP TABLE IF EXISTS OrderItemCustomization;
DROP TABLE IF EXISTS OrderItem;
DROP TABLE IF EXISTS `Order`;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS ProductCategory;
DROP TABLE IF EXISTS Supplier;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Staff;
DROP TABLE IF EXISTS Jobs;
DROP TABLE IF EXISTS ID_Sequence;
SET FOREIGN_KEY_CHECKS = 1;

-- ============================================================
-- ID SEQUENCE TABLE
-- ============================================================

CREATE TABLE ID_Sequence (
  SeqName    VARCHAR(50) PRIMARY KEY,
  CurrentVal INT NOT NULL DEFAULT 0
);

INSERT INTO ID_Sequence (SeqName, CurrentVal) VALUES
('Jobs', 0),
('Staff', 0),
('Supplier', 0),
('ProductCategory', 0),
('Product', 0),
('Customer', 0),
('OrderItem', 0),
('OrderItemCustomization', 0),
('CustomizationImage', 0),
('DeliveryNote', 0),
('DeliveryNoteItem', 0),
('DeliveryTracking', 0),
('ReplySlip', 0),
('RawMaterial', 0),
('RawMaterialMovement', 0),
('ProductMaterial', 0),       -- [v5.2 NEW] BOM
('Complaint', 0),
('ComplaintImage', 0),
('ReturnRequest', 0),
('ReturnImage', 0),
('Invoice', 0),
('InvoiceItem', 0),
-- [v4.0 NEW]
('QuotationItem', 0),
('ProductionTracking', 0),
('MaterialRequest', 0),
('MaterialRequestItem', 0),       -- [v5.3 NEW]
('RawMaterialTransferItem', 0),
-- [v5.0 NEW]
('PurchaseOrder', 0),
('PurchaseOrderItem', 0);

-- ============================================================
-- MODULE 1: JOBS & STAFF
-- ============================================================

CREATE TABLE Jobs (
  Job_ID      VARCHAR(20) PRIMARY KEY,
  Job_Title   VARCHAR(50) NOT NULL,
  System_Role VARCHAR(50) NOT NULL
);

CREATE TABLE Staff (
  StaffID   VARCHAR(20) PRIMARY KEY,
  Job_ID    VARCHAR(20) NOT NULL,
  StaffName VARCHAR(100) NOT NULL,
  Phone     VARCHAR(20) NULL,
  Username  VARCHAR(50) UNIQUE NOT NULL,
  PasswordHash VARCHAR(255) NOT NULL,
  IsSupervisor BOOLEAN DEFAULT FALSE,
  IsActive  BOOLEAN DEFAULT TRUE,
  FOREIGN KEY (Job_ID) REFERENCES Jobs(Job_ID)
);

-- ============================================================
-- MODULE 2: MASTER DATA
-- ============================================================

CREATE TABLE Supplier (
  SupplierID   VARCHAR(20) PRIMARY KEY,
  SupplierName VARCHAR(150) NOT NULL,
  Phone        VARCHAR(20),
  Email        VARCHAR(150)
);

CREATE TABLE ProductCategory (
  CategoryID   VARCHAR(20) PRIMARY KEY,
  CategoryName VARCHAR(100) NOT NULL,
  Description  VARCHAR(255)
);

CREATE TABLE Product (
  ProductID    VARCHAR(20) PRIMARY KEY,
  ProductName  VARCHAR(150) NOT NULL,
  CategoryID   VARCHAR(20) NULL,
  UnitPrice    DECIMAL(10,2),
  Stock        INT NOT NULL DEFAULT 0,
  ProductImage LONGBLOB,
  CONSTRAINT fk_product_category
    FOREIGN KEY (CategoryID) REFERENCES ProductCategory(CategoryID)
);

-- ============================================================
-- MODULE 3: CUSTOMER & ORDER
-- ============================================================

CREATE TABLE Customer (
  CustomerID   VARCHAR(20) PRIMARY KEY,
  CustomerType ENUM('B2B','B2C') NOT NULL,
  CustomerName VARCHAR(150) NOT NULL,
  Phone        VARCHAR(20),
  Email        VARCHAR(150),
  Address      VARCHAR(255)
);

-- ============================================================
-- MODULE 3A: QUOTATION  [v4.0 NEW]
-- ============================================================

CREATE TABLE Quotation (
  QuotationID       VARCHAR(30) PRIMARY KEY,
  CustomerID        VARCHAR(20) NOT NULL,
  SalesStaffID      VARCHAR(20) NOT NULL,
  QuotationDate     DATE NOT NULL,
  ValidUntil        DATE NOT NULL,
  PaymentMethod     ENUM('Cash','BankTransfer','Cheque','CreditCard','FPS')
                    NOT NULL,
  EstimatedDelivery DATE,
  Discount          DECIMAL(12,2) DEFAULT 0,
  SubTotal          DECIMAL(12,2),
  Total             DECIMAL(12,2),
  Status            ENUM('Draft','Sent','Accepted','Rejected','Expired','Converted')
                    NOT NULL DEFAULT 'Draft',
  Remarks           TEXT,
  FOREIGN KEY (CustomerID)   REFERENCES Customer(CustomerID),
  FOREIGN KEY (SalesStaffID) REFERENCES Staff(StaffID)
);

CREATE TABLE QuotationItem (
  QuotationItemID VARCHAR(20) PRIMARY KEY,
  QuotationID     VARCHAR(30) NOT NULL,
  ProductID       VARCHAR(20) NOT NULL,
  Quantity        INT NOT NULL,
  UnitPrice       DECIMAL(10,2),
  Discount        DECIMAL(10,2) DEFAULT 0,
  LineTotal       DECIMAL(10,2),
  IsCustom        BOOLEAN NOT NULL DEFAULT FALSE,
  CustomDesc      TEXT,
  FOREIGN KEY (QuotationID) REFERENCES Quotation(QuotationID),
  FOREIGN KEY (ProductID)   REFERENCES Product(ProductID)
);

CREATE TABLE `Order` (
  OrderID      VARCHAR(30) PRIMARY KEY,
  QuotationID  VARCHAR(30) NULL,          -- [v4.0 NEW]
  CustomerID   VARCHAR(20) NOT NULL,
  SalesStaffID VARCHAR(20) NOT NULL,
  OrderDate    DATE NOT NULL,
  RequiredDate DATE,
  PaymentStatus ENUM('Pending','Paid','Partial','Refunded')
               NOT NULL DEFAULT 'Pending', -- [v4.0 NEW]
  Status       ENUM('Pending','InProduction','ReadyToShip','Shipped','Delivered','Cancelled') DEFAULT 'Pending',
  FOREIGN KEY (QuotationID)  REFERENCES Quotation(QuotationID),  -- [v4.0 NEW]
  FOREIGN KEY (CustomerID)   REFERENCES Customer(CustomerID),
  FOREIGN KEY (SalesStaffID) REFERENCES Staff(StaffID)
);

CREATE TABLE OrderItem (
  OrderItemID  VARCHAR(20) PRIMARY KEY,
  OrderID      VARCHAR(30) NOT NULL,
  ProductID    VARCHAR(20) NOT NULL,
  Quantity     INT NOT NULL,
  UnitPrice    DECIMAL(10,2),
  ItemType     ENUM('Standard','Custom') NOT NULL DEFAULT 'Standard',
  SerialNumber VARCHAR(10) NULL UNIQUE,          -- [v4.0 NEW] XX#######
  CustomStatus ENUM('NotRequired','Draft','PendingConfirm','Confirmed','InProduction') NOT NULL DEFAULT 'NotRequired',
  FOREIGN KEY (OrderID)   REFERENCES `Order`(OrderID),
  FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE OrderItemCustomization (
  CustomID         VARCHAR(20) PRIMARY KEY,
  OrderItemID      VARCHAR(20) NOT NULL UNIQUE,
  DimensionL       DECIMAL(10,2),
  DimensionW       DECIMAL(10,2),
  DimensionH       DECIMAL(10,2),
  Material         VARCHAR(100),
  Color            VARCHAR(50),
  FinishType       VARCHAR(50),
  Fabric           VARCHAR(100),
  CustomDescription TEXT,
  QuoteConfirmed   BOOLEAN NOT NULL DEFAULT FALSE,
  DepositPaid      BOOLEAN NOT NULL DEFAULT FALSE,
  FinalConfirmedAt DATETIME NULL,
  Remarks          TEXT,
  FOREIGN KEY (OrderItemID) REFERENCES OrderItem(OrderItemID)
);

CREATE TABLE CustomizationImage (
  ImageID   VARCHAR(20) PRIMARY KEY,
  CustomID  VARCHAR(20) NOT NULL,
  ImageData LONGBLOB NOT NULL,            -- [v5.5 CHANGED] was ImageURL VARCHAR(500)
  FOREIGN KEY (CustomID) REFERENCES OrderItemCustomization(CustomID)
);

-- ============================================================
-- MODULE 4: LOGISTICS
-- ============================================================

CREATE TABLE DeliveryNote (
  DNID           VARCHAR(20) PRIMARY KEY,
  OrderID        VARCHAR(30) NOT NULL,
  IssuedByStaff  VARCHAR(20) NOT NULL,
  DispatchDate   DATE NOT NULL,
  InvoiceAddress VARCHAR(255),           -- [v4.0 NEW] auto-filled from Invoice.BillingAddress
  DeliveryMethod ENUM('Self-Pickup','Standard Delivery','Express Delivery','Third-Party Logistics')
                 NOT NULL DEFAULT 'Standard Delivery',
  Status         ENUM('Planned','Issued','InTransit','Delivered','Failed') DEFAULT 'Planned',
  FOREIGN KEY (OrderID)       REFERENCES `Order`(OrderID),
  FOREIGN KEY (IssuedByStaff) REFERENCES Staff(StaffID)
);

CREATE TABLE DeliveryNoteItem (
  DNItemID     VARCHAR(20) PRIMARY KEY,
  DNID         VARCHAR(20) NOT NULL,
  ProductID    VARCHAR(20) NOT NULL,
  Description  VARCHAR(255),
  QtyOrdered   INT NOT NULL,
  QtyDelivered INT DEFAULT 0,
  FOREIGN KEY (DNID)      REFERENCES DeliveryNote(DNID),
  FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE DeliveryTracking (
  TrackingID VARCHAR(20) PRIMARY KEY,
  DNID       VARCHAR(20) NOT NULL,
  Location   VARCHAR(150) NOT NULL,
  Action     ENUM('Arrived','Departed','OutForDelivery','Delivered') NOT NULL,
  ScanTime   DATETIME DEFAULT CURRENT_TIMESTAMP,
  UpdatedBy  VARCHAR(20) NOT NULL,
  Remarks    TEXT,
  FOREIGN KEY (DNID)      REFERENCES DeliveryNote(DNID),
  FOREIGN KEY (UpdatedBy) REFERENCES Staff(StaffID)
);

CREATE TABLE ReplySlip (
  ReplySlipID  VARCHAR(20) PRIMARY KEY,
  DNID         VARCHAR(20) NOT NULL UNIQUE,
  ReceivedBy   VARCHAR(100),
  ReceivedDate DATETIME,
  SignatureImage VARCHAR(500) NULL COMMENT 'Path to customer signature image',
  Status       ENUM('Pending','Confirmed','Disputed') DEFAULT 'Pending',
  FOREIGN KEY (DNID) REFERENCES DeliveryNote(DNID)
);

-- ============================================================
-- MODULE 5: INVENTORY CONTROL
-- ============================================================

CREATE TABLE RawMaterial (
  MaterialID          VARCHAR(20) PRIMARY KEY,
  SupplierID          VARCHAR(20),
  MaterialName        VARCHAR(150) NOT NULL,
  Unit                VARCHAR(20) NOT NULL,
  StockQty            DECIMAL(12,2) DEFAULT 0,
  ReorderLevel        DECIMAL(12,2) NOT NULL,
  UnitPurchasePrice   DECIMAL(12,2) DEFAULT 0,   -- [v5.1 NEW] standard cost for auto-fill in PO
  FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID)
);

CREATE TABLE RawMaterialMovement (
  MovementID   VARCHAR(20) PRIMARY KEY,
  MaterialID   VARCHAR(20) NOT NULL,
  MovementType ENUM('Inbound','Outbound') NOT NULL,
  Quantity     DECIMAL(12,2) NOT NULL,
  MovementDate DATETIME DEFAULT CURRENT_TIMESTAMP,
  RecordedBy   VARCHAR(20) NOT NULL,
  FOREIGN KEY (MaterialID) REFERENCES RawMaterial(MaterialID),
  FOREIGN KEY (RecordedBy) REFERENCES Staff(StaffID)
);

-- ============================================================
-- MODULE 5A2: BILL OF MATERIALS (BOM)  [v5.2 NEW]
-- Links Product to RawMaterial — defines how much of each
-- raw material is needed to produce 1 unit of a product.
-- Used by: Material Request auto-calc, production planning.
-- ID Format: PM-NNN (global sequence)
-- ============================================================

CREATE TABLE ProductMaterial (
  ProductMaterialID  VARCHAR(20) PRIMARY KEY,
  ProductID          VARCHAR(20) NOT NULL,
  MaterialID         VARCHAR(20) NOT NULL,
  QuantityPerUnit    DECIMAL(12,2) NOT NULL,    -- material needed per 1 product unit
  Unit               VARCHAR(20) NOT NULL,      -- copied from RawMaterial.Unit
  Remarks            VARCHAR(255),
  FOREIGN KEY (ProductID)  REFERENCES Product(ProductID),
  FOREIGN KEY (MaterialID) REFERENCES RawMaterial(MaterialID),
  UNIQUE (ProductID, MaterialID)                -- one BOM line per product-material pair
);

-- ============================================================
-- MODULE 5B: PRODUCTION TRACKING  [v4.0 NEW]
-- ============================================================

CREATE TABLE ProductionTracking (
  TrackingID    VARCHAR(20) PRIMARY KEY,
  OrderItemID   VARCHAR(20) NOT NULL,
  Step          ENUM('Tapping','Cutting','FJointing','Drilling',
                     'Sanding','Painting','Varnishing','Drying') NOT NULL,
  Status        ENUM('Pending','InProgress','Completed') NOT NULL DEFAULT 'Pending',
  AssignedTo    VARCHAR(20),
  StartDate     DATETIME,
  CompletedDate DATETIME,
  Remarks       TEXT,
  FOREIGN KEY (OrderItemID) REFERENCES OrderItem(OrderItemID),
  FOREIGN KEY (AssignedTo)  REFERENCES Staff(StaffID)
);

-- ============================================================
-- MODULE 5B2: MATERIAL REQUEST  [v5.3 REDESIGNED — header + items]
-- Production Clerk requests raw materials from Inventory.
-- One Request (header) can contain multiple Materials (items).
-- ID Format:
--   MaterialRequest:     MR-NNNN  (global sequence)
--   MaterialRequestItem: MRI-NNN  (global sequence)
-- Status Flow: Requested → Approved → Fulfilled
-- ============================================================

CREATE TABLE MaterialRequest (
  RequestID             VARCHAR(20) PRIMARY KEY,
  OrderItemID           VARCHAR(20) NULL,            -- nullable: general requests need no specific order item
  UrgencyLevel          ENUM('Low','Medium','High','Urgent') NOT NULL DEFAULT 'Medium',
  RequiredDeliveryDate  DATE,
  RequestDate           DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  RequestedBy           VARCHAR(20) NOT NULL,
  Status                ENUM('Requested','Approved','Fulfilled') NOT NULL DEFAULT 'Requested',
  ApprovedBy            VARCHAR(20),
  ApprovedDate          DATETIME,
  Remarks               TEXT,
  FOREIGN KEY (OrderItemID) REFERENCES OrderItem(OrderItemID),
  FOREIGN KEY (RequestedBy) REFERENCES Staff(StaffID),
  FOREIGN KEY (ApprovedBy)  REFERENCES Staff(StaffID)
);

CREATE TABLE MaterialRequestItem (
  RequestItemID   VARCHAR(20) PRIMARY KEY,
  RequestID       VARCHAR(20) NOT NULL,
  MaterialID      VARCHAR(20) NOT NULL,
  Quantity        DECIMAL(12,2) NOT NULL,
  Unit            VARCHAR(20) NOT NULL,             -- snapshot from RawMaterial.Unit
  Remarks         VARCHAR(255),
  FOREIGN KEY (RequestID)  REFERENCES MaterialRequest(RequestID) ON DELETE CASCADE,
  FOREIGN KEY (MaterialID) REFERENCES RawMaterial(MaterialID)
);

-- ============================================================
-- MODULE 5C: RAW MATERIAL TRANSFER  [v4.0 NEW]
-- ============================================================

CREATE TABLE RawMaterialTransfer (
  TransferID     VARCHAR(20) PRIMARY KEY,
  TransferDate   DATE NOT NULL,
  TransferType   ENUM('RawMaterial_In','RawMaterial_Out','Product_In','Product_Out')
                 NOT NULL,
  OrderID        VARCHAR(30) NULL,
  ProductionID   VARCHAR(30) NULL,
  RequestedBy    VARCHAR(20) NOT NULL,
  FromLocation   VARCHAR(100),
  ToLocation     VARCHAR(100),
  Status         ENUM('Draft','Pending','Approved','Issued','Delivering','Received','Cancelled')
                 NOT NULL DEFAULT 'Draft',
  ApprovedBy       VARCHAR(20),
  IssuedBy         VARCHAR(20),
  DeliveredBy      VARCHAR(20),     -- [v5.4 NEW] Logistics Staff who handles delivery
  ReceivedBy       VARCHAR(20),
  ApprovedDate     DATE NULL,
  IssuedDate       DATE NULL,
  DeliveringDate   DATETIME NULL,   -- [v5.4 NEW] when Logistics picks up for delivery
  ReceivedDate     DATE NULL,
  Remarks          TEXT,
  FOREIGN KEY (OrderID)     REFERENCES `Order`(OrderID),
  FOREIGN KEY (RequestedBy) REFERENCES Staff(StaffID),
  FOREIGN KEY (ApprovedBy)  REFERENCES Staff(StaffID),
  FOREIGN KEY (IssuedBy)    REFERENCES Staff(StaffID),
  FOREIGN KEY (DeliveredBy) REFERENCES Staff(StaffID),
  FOREIGN KEY (ReceivedBy)  REFERENCES Staff(StaffID)
);

CREATE TABLE RawMaterialTransferItem (
  TransferItemID VARCHAR(20) PRIMARY KEY,
  TransferID     VARCHAR(20) NOT NULL,
  MaterialID     VARCHAR(20) NULL,
  ProductID      VARCHAR(20) NULL,
  Quantity       DECIMAL(12,2) NOT NULL,
  Unit           VARCHAR(20),
  Description    VARCHAR(255),
  Remarks        TEXT,
  FOREIGN KEY (TransferID) REFERENCES RawMaterialTransfer(TransferID),
  FOREIGN KEY (MaterialID) REFERENCES RawMaterial(MaterialID),
  FOREIGN KEY (ProductID)  REFERENCES Product(ProductID)
);

-- ============================================================
-- MODULE 5D: PROCUREMENT (PURCHASE ORDER)  [v5.0 NEW]
-- Inventory Clerks issue Purchase Orders to Suppliers when stock
-- falls below the reorder threshold (Case Study §7.4).
-- ID Format:
--   PurchaseOrder:     PO-YYYYMMDD-NNN   (daily sequence)
--   PurchaseOrderItem: POI-NNN           (global sequence)
-- Status Flow:
--   Draft -> Sent -> PartiallyReceived -> Received
--                 \-> Cancelled
-- Payment Flow:
--   Unpaid -> Partial -> Paid  (managed by Finance Dept)
-- ============================================================

CREATE TABLE PurchaseOrder (
  PurchaseOrderID      VARCHAR(30) PRIMARY KEY,
  SupplierID           VARCHAR(20) NOT NULL,
  OrderDate            DATE NOT NULL DEFAULT (CURRENT_DATE),
  ExpectedDeliveryDate DATE,                                  -- when goods should arrive
  ActualDeliveryDate   DATE NULL,                              -- filled when fully received

  -- Lifecycle
  Status        ENUM('Draft','Sent','PartiallyReceived','Received','Cancelled')
                NOT NULL DEFAULT 'Draft',
  PaymentStatus ENUM('Unpaid','Partial','Paid') NOT NULL DEFAULT 'Unpaid',
  PaymentMethod ENUM('Cash','Cheque','BankTransfer','CreditCard','FPS')
                DEFAULT 'BankTransfer',

  -- Money (denormalized for report convenience; items carry line totals)
  SubTotal    DECIMAL(14,2) NOT NULL DEFAULT 0,
  TaxAmount   DECIMAL(14,2) NOT NULL DEFAULT 0,
  TotalAmount DECIMAL(14,2) NOT NULL DEFAULT 0,

  -- Audit / approval
  CreatedBy     VARCHAR(20) NOT NULL,                          -- Inventory Clerk who issues PO
  CreatedAt     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  ApprovedBy    VARCHAR(20) NULL,                              -- Supervisor approval (optional)
  ApprovedDate  DATETIME NULL,
  SentDate      DATETIME NULL,                                 -- when PO was emailed to supplier

  Remarks TEXT,

  FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID),
  FOREIGN KEY (CreatedBy)  REFERENCES Staff(StaffID),
  FOREIGN KEY (ApprovedBy) REFERENCES Staff(StaffID)
);

CREATE TABLE PurchaseOrderItem (
  POItemID            VARCHAR(20) PRIMARY KEY,
  PurchaseOrderID     VARCHAR(30) NOT NULL,
  MaterialID          VARCHAR(20) NOT NULL,

  -- Snapshot of the order (price/qty locked at PO time)
  Quantity      DECIMAL(12,2) NOT NULL,
  Unit          VARCHAR(20) NOT NULL,                           -- copied from RawMaterial at PO time
  UnitPrice     DECIMAL(12,2) NOT NULL,
  LineTotal     DECIMAL(14,2) GENERATED ALWAYS AS (Quantity * UnitPrice) STORED,

  -- Goods receipt tracking (filled incrementally as deliveries arrive)
  ReceivedQty     DECIMAL(12,2) NOT NULL DEFAULT 0,
  OutstandingQty  DECIMAL(12,2) GENERATED ALWAYS AS (Quantity - ReceivedQty) STORED,

  -- Optional link to the MaterialRequest that triggered this purchase
  MaterialRequestID VARCHAR(20) NULL,

  Remarks VARCHAR(255),

  FOREIGN KEY (PurchaseOrderID)   REFERENCES PurchaseOrder(PurchaseOrderID) ON DELETE CASCADE,
  FOREIGN KEY (MaterialID)        REFERENCES RawMaterial(MaterialID),
  FOREIGN KEY (MaterialRequestID) REFERENCES MaterialRequest(RequestID)
);

-- ============================================================
-- MODULE 6: AFTER-SERVICE
-- ============================================================

CREATE TABLE Complaint (
  ComplaintID   VARCHAR(20) PRIMARY KEY,
  CustomerID    VARCHAR(20) NOT NULL,
  HandledByID   VARCHAR(20) NOT NULL,
  OrderID       VARCHAR(30),
  ComplaintType ENUM('Damaged','Delayed','Wrong','Quality','Other') NOT NULL,
  Description   TEXT,
  ComplaintDate DATE DEFAULT (CURRENT_DATE),
  Status        ENUM('Open','InProgress','Resolved','Closed') DEFAULT 'Open',
  Resolution    ENUM('Repair','Replacement','Refund','NoAction'),
  FOREIGN KEY (CustomerID)  REFERENCES Customer(CustomerID),
  FOREIGN KEY (HandledByID) REFERENCES Staff(StaffID),
  FOREIGN KEY (OrderID)     REFERENCES `Order`(OrderID)
);

CREATE TABLE ComplaintImage (
  ImageID     VARCHAR(20) PRIMARY KEY,
  ComplaintID VARCHAR(20) NOT NULL,
  ImageData   LONGBLOB NOT NULL,
  FOREIGN KEY (ComplaintID) REFERENCES Complaint(ComplaintID)
);

CREATE TABLE ReturnRequest (
  ReturnID      VARCHAR(20) PRIMARY KEY,
  ComplaintID   VARCHAR(20),
  OrderID       VARCHAR(30) NOT NULL,
  ReturnType    ENUM('Return','Replacement','Refund') NOT NULL,
  ReturnReason  TEXT NOT NULL,
  RequestDate   DATE DEFAULT (CURRENT_DATE),
  ReturnDate    DATE,
  Status        ENUM('Pending','Approved','Rejected','Completed') DEFAULT 'Pending',
  ProcessedByID VARCHAR(20),
  ReceivedByID  VARCHAR(20),
  RefundAmount  DECIMAL(10,2),
  RefundDate    DATE,
  Remarks       TEXT,
  FOREIGN KEY (ComplaintID)   REFERENCES Complaint(ComplaintID),
  FOREIGN KEY (OrderID)       REFERENCES `Order`(OrderID),
  FOREIGN KEY (ProcessedByID) REFERENCES Staff(StaffID),
  FOREIGN KEY (ReceivedByID)  REFERENCES Staff(StaffID)
);

CREATE TABLE ReturnImage (
  ImageID   VARCHAR(20) PRIMARY KEY,
  ReturnID  VARCHAR(20) NOT NULL,
  ImageData LONGBLOB NOT NULL,
  FOREIGN KEY (ReturnID) REFERENCES ReturnRequest(ReturnID)
);

-- ============================================================
-- MODULE 7: FINANCE
-- ============================================================

CREATE TABLE Invoice (
  InvoiceID      VARCHAR(20) PRIMARY KEY,
  OrderID        VARCHAR(30) NOT NULL,
  BillingAddress VARCHAR(255),                        -- [v4.0 NEW]
  DispatchDate   DATE,                                -- [v4.0 NEW]
  DeliveryMethod ENUM('Self-Pickup','Standard Delivery','Express Delivery','Third-Party Logistics')
                 NULL,                                -- [v4.0 NEW]
  SubTotal       DECIMAL(12,2),
  Discount       DECIMAL(12,2) DEFAULT 0,
  OtherCharges   DECIMAL(10,2) DEFAULT 0,             -- [v4.0 NEW]
  Total          DECIMAL(12,2),
  Status         ENUM('Issued','Paid','Overdue') DEFAULT 'Issued',
  IssuedDate     DATE DEFAULT (CURRENT_DATE),
  Remarks        TEXT,                                -- [v4.0 NEW]
  FOREIGN KEY (OrderID) REFERENCES `Order`(OrderID)
);

CREATE TABLE InvoiceItem (
  InvItemID VARCHAR(20) PRIMARY KEY,
  InvoiceID VARCHAR(20) NOT NULL,
  ProductID VARCHAR(20) NOT NULL,
  Quantity  INT NOT NULL,
  UnitCost  DECIMAL(10,2),
  Discount  DECIMAL(10,2) DEFAULT 0,
  LineTotal DECIMAL(10,2),
  FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID),
  FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

-- ============================================================
-- TRIGGERS: AUTO-GENERATE ALL IDs
-- ============================================================

DROP TRIGGER IF EXISTS trg_jobs_id;
DROP TRIGGER IF EXISTS trg_staff_id;
DROP TRIGGER IF EXISTS trg_supplier_id;
DROP TRIGGER IF EXISTS trg_productcategory_id;
DROP TRIGGER IF EXISTS trg_product_id;
DROP TRIGGER IF EXISTS trg_customer_id;
DROP TRIGGER IF EXISTS trg_order_id;
DROP TRIGGER IF EXISTS trg_orderitem_id;
DROP TRIGGER IF EXISTS trg_orderitemcustomization_id;
DROP TRIGGER IF EXISTS trg_customizationimage_id;
DROP TRIGGER IF EXISTS trg_deliverynote_id;
DROP TRIGGER IF EXISTS trg_deliverynoteitem_id;
DROP TRIGGER IF EXISTS trg_deliverytracking_id;
DROP TRIGGER IF EXISTS trg_replyslip_id;
DROP TRIGGER IF EXISTS trg_rawmaterial_id;
DROP TRIGGER IF EXISTS trg_rawmaterialmovement_id;
-- [v5.2 NEW]
DROP TRIGGER IF EXISTS trg_productmaterial_id;
DROP TRIGGER IF EXISTS trg_complaint_id;
DROP TRIGGER IF EXISTS trg_complaintimage_id;
DROP TRIGGER IF EXISTS trg_returnrequest_id;
DROP TRIGGER IF EXISTS trg_returnimage_id;
DROP TRIGGER IF EXISTS trg_invoice_id;
DROP TRIGGER IF EXISTS trg_invoiceitem_id;
-- [v4.0 NEW]
DROP TRIGGER IF EXISTS trg_quotation_id;
DROP TRIGGER IF EXISTS trg_quotationitem_id;
DROP TRIGGER IF EXISTS trg_productiontracking_id;
DROP TRIGGER IF EXISTS trg_materialrequest_id;
-- [v5.3 NEW]
DROP TRIGGER IF EXISTS trg_materialrequestitem_id;
DROP TRIGGER IF EXISTS trg_rawmaterialtransfer_id;
DROP TRIGGER IF EXISTS trg_rawmaterialtransferitem_id;
-- [v5.0 NEW]
DROP TRIGGER IF EXISTS trg_purchaseorder_id;
DROP TRIGGER IF EXISTS trg_purchaseorderitem_id;

DELIMITER $$

CREATE TRIGGER trg_jobs_id BEFORE INSERT ON Jobs FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'Jobs';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'Jobs';
  SET NEW.Job_ID = CONCAT('J-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_staff_id BEFORE INSERT ON Staff FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'Staff';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'Staff';
  SET NEW.StaffID = CONCAT('S-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_supplier_id BEFORE INSERT ON Supplier FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'Supplier';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'Supplier';
  SET NEW.SupplierID = CONCAT('SUP-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_productcategory_id BEFORE INSERT ON ProductCategory FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'ProductCategory';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'ProductCategory';
  SET NEW.CategoryID = CONCAT('CAT-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_product_id BEFORE INSERT ON Product FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'Product';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'Product';
  SET NEW.ProductID = CONCAT('P-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_customer_id BEFORE INSERT ON Customer FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'Customer';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'Customer';
  SET NEW.CustomerID = CONCAT('C-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_order_id BEFORE INSERT ON `Order` FOR EACH ROW
BEGIN
  DECLARE today_str VARCHAR(8);
  DECLARE daily_count INT;
  SET today_str = DATE_FORMAT(NEW.OrderDate, '%Y%m%d');
  INSERT INTO ID_Sequence (SeqName, CurrentVal)
    VALUES (CONCAT('Order_', today_str), 1)
    ON DUPLICATE KEY UPDATE CurrentVal = CurrentVal + 1;
  SELECT CurrentVal INTO daily_count FROM ID_Sequence WHERE SeqName = CONCAT('Order_', today_str);
  SET NEW.OrderID = CONCAT('ORD-', today_str, '-', daily_count);
END$$

CREATE TRIGGER trg_orderitem_id BEFORE INSERT ON OrderItem FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'OrderItem';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'OrderItem';
  SET NEW.OrderItemID = CONCAT('OI-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_orderitemcustomization_id BEFORE INSERT ON OrderItemCustomization FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'OrderItemCustomization';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'OrderItemCustomization';
  SET NEW.CustomID = CONCAT('CUST-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_customizationimage_id BEFORE INSERT ON CustomizationImage FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'CustomizationImage';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'CustomizationImage';
  SET NEW.ImageID = CONCAT('CZI-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_deliverynote_id BEFORE INSERT ON DeliveryNote FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'DeliveryNote';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'DeliveryNote';
  SET NEW.DNID = CONCAT('DN-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_deliverynoteitem_id BEFORE INSERT ON DeliveryNoteItem FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'DeliveryNoteItem';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'DeliveryNoteItem';
  SET NEW.DNItemID = CONCAT('DNI-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_deliverytracking_id BEFORE INSERT ON DeliveryTracking FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'DeliveryTracking';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'DeliveryTracking';
  SET NEW.TrackingID = CONCAT('TRK-', LPAD(n, 4, '0'));
END$$

CREATE TRIGGER trg_replyslip_id BEFORE INSERT ON ReplySlip FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'ReplySlip';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'ReplySlip';
  SET NEW.ReplySlipID = CONCAT('RS-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_rawmaterial_id BEFORE INSERT ON RawMaterial FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'RawMaterial';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'RawMaterial';
  SET NEW.MaterialID = CONCAT('MAT-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_rawmaterialmovement_id BEFORE INSERT ON RawMaterialMovement FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'RawMaterialMovement';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'RawMaterialMovement';
  SET NEW.MovementID = CONCAT('MOV-', LPAD(n, 3, '0'));
END$$

-- [v5.2 NEW] BOM trigger: PM-NNN
CREATE TRIGGER trg_productmaterial_id BEFORE INSERT ON ProductMaterial FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'ProductMaterial';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'ProductMaterial';
  SET NEW.ProductMaterialID = CONCAT('PM-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_complaint_id BEFORE INSERT ON Complaint FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'Complaint';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'Complaint';
  SET NEW.ComplaintID = CONCAT('CMP-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_complaintimage_id BEFORE INSERT ON ComplaintImage FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'ComplaintImage';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'ComplaintImage';
  SET NEW.ImageID = CONCAT('CI-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_returnrequest_id BEFORE INSERT ON ReturnRequest FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'ReturnRequest';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'ReturnRequest';
  SET NEW.ReturnID = CONCAT('RET-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_returnimage_id BEFORE INSERT ON ReturnImage FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'ReturnImage';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'ReturnImage';
  SET NEW.ImageID = CONCAT('RI-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_invoice_id BEFORE INSERT ON Invoice FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'Invoice';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'Invoice';
  SET NEW.InvoiceID = CONCAT('INV-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_invoiceitem_id BEFORE INSERT ON InvoiceItem FOR EACH ROW
BEGIN
  DECLARE n INT;
  UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'InvoiceItem';
  SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'InvoiceItem';
  SET NEW.InvItemID = CONCAT('II-', LPAD(n, 3, '0'));
END$$

-- ============================================================
-- [v4.0 NEW] TRIGGERS FOR NEW TABLES
-- ============================================================

CREATE TRIGGER trg_quotation_id BEFORE INSERT ON Quotation FOR EACH ROW
BEGIN
    DECLARE today_str VARCHAR(8);
    DECLARE daily_count INT;
    SET today_str = DATE_FORMAT(NEW.QuotationDate, '%Y%m%d');
    INSERT INTO ID_Sequence (SeqName, CurrentVal)
        VALUES (CONCAT('Quotation_', today_str), 1)
        ON DUPLICATE KEY UPDATE CurrentVal = CurrentVal + 1;
    SELECT CurrentVal INTO daily_count
        FROM ID_Sequence WHERE SeqName = CONCAT('Quotation_', today_str);
    SET NEW.QuotationID = CONCAT('QUO-', today_str, '-', daily_count);
END$$

CREATE TRIGGER trg_quotationitem_id BEFORE INSERT ON QuotationItem FOR EACH ROW
BEGIN
    DECLARE n INT;
    UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'QuotationItem';
    SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'QuotationItem';
    SET NEW.QuotationItemID = CONCAT('QI-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_productiontracking_id BEFORE INSERT ON ProductionTracking FOR EACH ROW
BEGIN
    DECLARE n INT;
    UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'ProductionTracking';
    SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'ProductionTracking';
    SET NEW.TrackingID = CONCAT('PT-', LPAD(n, 4, '0'));
END$$

CREATE TRIGGER trg_materialrequest_id BEFORE INSERT ON MaterialRequest FOR EACH ROW
BEGIN
    DECLARE n INT;
    UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'MaterialRequest';
    SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'MaterialRequest';
    SET NEW.RequestID = CONCAT('MR-', LPAD(n, 4, '0'));
END$$

-- [v5.3 NEW] Material Request Item ID: MRI-NNN
CREATE TRIGGER trg_materialrequestitem_id BEFORE INSERT ON MaterialRequestItem FOR EACH ROW
BEGIN
    DECLARE n INT;
    UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'MaterialRequestItem';
    SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'MaterialRequestItem';
    SET NEW.RequestItemID = CONCAT('MRI-', LPAD(n, 3, '0'));
END$$

CREATE TRIGGER trg_rawmaterialtransfer_id BEFORE INSERT ON RawMaterialTransfer FOR EACH ROW
BEGIN
    DECLARE today_str VARCHAR(6);
    DECLARE daily_count INT;
    SET today_str = DATE_FORMAT(NEW.TransferDate, '%y%m%d');
    INSERT INTO ID_Sequence (SeqName, CurrentVal)
        VALUES (CONCAT('Transfer_', today_str), 1)
        ON DUPLICATE KEY UPDATE CurrentVal = CurrentVal + 1;
    SELECT CurrentVal INTO daily_count
        FROM ID_Sequence WHERE SeqName = CONCAT('Transfer_', today_str);
    SET NEW.TransferID = CONCAT('IT', today_str, LPAD(daily_count, 4, '0'));
END$$

CREATE TRIGGER trg_rawmaterialtransferitem_id BEFORE INSERT ON RawMaterialTransferItem FOR EACH ROW
BEGIN
    DECLARE n INT;
    UPDATE ID_Sequence SET CurrentVal = CurrentVal + 1 WHERE SeqName = 'RawMaterialTransferItem';
    SELECT CurrentVal INTO n FROM ID_Sequence WHERE SeqName = 'RawMaterialTransferItem';
    SET NEW.TransferItemID = CONCAT('RTI-', LPAD(n, 3, '0'));
END$$

-- [v5.0 NEW] Procurement triggers
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
-- SAMPLE DATA
-- ============================================================

INSERT INTO Jobs (Job_ID, Job_Title, System_Role) VALUES
(NULL, 'Sales Representative',   'Sales'),
(NULL, 'Finance Staff',          'Finance'),
(NULL, 'Home Planning Specialist','HomePlanning'),
(NULL, 'Inventory Clerk',        'Inventory'),
(NULL, 'Logistics Staff',        'Logistics'),
(NULL, 'Production Clerk',      'Production');

INSERT INTO Staff (StaffID, Job_ID, StaffName, Phone, Username, PasswordHash, IsSupervisor, IsActive) VALUES
(NULL, 'J-001', 'Chan Siu Ming',  '6123 4567', 'chansiuming', '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  FALSE, TRUE),
(NULL, 'J-001', 'Ho Tsz Kwan',   '6234 5678', 'hotszkwan',   '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  TRUE,  TRUE),
(NULL, 'J-003', 'Wong Mei Ling', '6345 6789', 'wongmeiling', '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  FALSE, TRUE),
(NULL, 'J-003', 'Fung Wai Sze',  '6456 7890', 'fungwaisze',  '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  TRUE,  TRUE),
(NULL, 'J-004', 'Ng Chun Fai',   '6567 8901', 'ngchunfai',   '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  FALSE, TRUE),
(NULL, 'J-004', 'Yuen Hoi Ting', '6678 9012', 'yuenhoiting', '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  TRUE,  TRUE),
(NULL, 'J-005', 'Cheung Ho Yin', '6789 0123', 'cheunghoyin', '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  FALSE, TRUE),
(NULL, 'J-005', 'Kwok Man Kit',  '6890 1234', 'kwokmankit',  '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  TRUE,  TRUE),
(NULL, 'J-002', 'Lee Pui Shan',  '6901 2345', 'leepuishan',  '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  TRUE,  TRUE),
(NULL, 'J-002', 'Mak Sui Ying',  '6012 3456', 'maksuiying',  '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  FALSE, TRUE),
(NULL, 'J-001', 'Admin User',    '9111 1111', 'admin',        '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm', TRUE,  TRUE),
(NULL, 'J-006', 'Lam Wai Keung', '6120 3456', 'lamwaikeung',  '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  FALSE, TRUE),
(NULL, 'J-006', 'Tang Sze Yu',   '6230 4567', 'tangszyu',     '$2b$12$eM2dLHePJVrHSNgjF/xuVO1HB6OlkF3vf6cYXzwA5GdXD/dYgZ3Lm',  TRUE,  TRUE);

INSERT INTO Supplier (SupplierID, SupplierName, Phone, Email) VALUES
(NULL, 'Guangzhou Wood Supply Co.', '020-88001234', 'supply@gzwood.cn'),
(NULL, 'Bangkok Textile Ltd.',      '02-9991234',   'info@bktextile.th'),
(NULL, 'Manila Metal Parts Inc.',   '02-8881234',   'sales@manilametal.ph'),
(NULL, 'Vietnam Foam Factory',      '028-7771234',  'vn@foamfactory.vn'),
(NULL, 'Shenzhen Glass Works Ltd.', '0755-6661234', 'glass@szworks.cn');

INSERT INTO ProductCategory (CategoryID, CategoryName, Description) VALUES
(NULL, 'Sofa',          'Sofas and leisure seating'),
(NULL, 'Dining Table',  'Dining tables and sets'),
(NULL, 'Dining Chair',  'Dining chairs and bar stools'),
(NULL, 'Office Chair',  'Office chairs and ergonomic seating'),
(NULL, 'Bedroom',       'Bed frames and bedroom furniture'),
(NULL, 'Coffee Table',  'Coffee tables and side tables'),
(NULL, 'Storage',       'Bookshelves, wardrobes and storage units'),
(NULL, 'Entertainment', 'TV consoles and entertainment units');

INSERT INTO Product (ProductID, ProductName, CategoryID, UnitPrice, Stock) VALUES
(NULL, 'Luxury 3-Seat Sofa',       'CAT-001', 4800.00, 3),
(NULL, 'Solid Wood Dining Table',  'CAT-002', 3200.00, 8),
(NULL, 'Ergonomic Office Chair',   'CAT-004', 1200.00, 15),
(NULL, 'King Size Bed Frame',      'CAT-005', 5500.00, 6),
(NULL, 'Coffee Table',             'CAT-006',  980.00, 4),
(NULL, 'Bookshelf 5-Tier',         'CAT-007',  760.00, 10),
(NULL, 'TV Console 180cm',         'CAT-008', 1850.00, 7),
(NULL, 'Dining Chair (Set of 4)',  'CAT-003', 2400.00, 12),
(NULL, 'Custom L-Shape Sofa',      'CAT-001', 7200.00, 2),
(NULL, 'Custom Built-in Wardrobe', 'CAT-007', 9800.00, 3),
(NULL, 'Custom Dining Set',        'CAT-002', 8500.00, 2),
(NULL, 'Custom Study Desk',        'CAT-006', 3600.00, 5);

INSERT INTO Customer (CustomerID, CustomerType, CustomerName, Phone, Email, Address) VALUES
(NULL, 'B2C', 'Chan Tai Man',          '9123 4567', 'taiman@email.com',    'Flat 5A, 12 Nathan Rd, Kowloon'),
(NULL, 'B2C', 'Yip Siu Fong',          '9234 5678', 'siufong@email.com',   'Room 3B, 88 Queen Rd, HK Island'),
(NULL, 'B2C', 'Leung Ka Wai',          '9345 6789', 'kawai@email.com',     'Unit 2, 5 Sai Yeung Choi St, MK'),
(NULL, 'B2C', 'Chow Wai Lun',          '9456 7890', 'wailun@email.com',    'Block 3, 22 Sha Tin Centre St, NT'),
(NULL, 'B2C', 'Pang Hiu Tung',         '9567 8901', 'hiutung@email.com',   'Flat 8C, 30 Tung Choi St, MK'),
(NULL, 'B2B', 'Metro Office Solutions','2345 6789', 'order@metrooff.com',  '18/F Tower 1, Kowloon Bay'),
(NULL, 'B2B', 'Grand Hotel HK',        '2456 7890', 'purchase@grandhk.com','1 Harbour Rd, Wan Chai'),
(NULL, 'B2B', 'Pacific Serviced Apt.', '2567 8901', 'fm@pacificapt.com',   '5/F Pacific Plaza, Tsim Sha Tsui'),
(NULL, 'B2B', 'Sunrise Co-Working Ltd.','2678 9012','ops@sunrisecw.com',   '22/F One Exchange Sq, Central'),
(NULL, 'B2C', 'Lau Cheuk Hin',         '9678 9012', 'cheukin@email.com',   'Unit 1, 9 Fuk Wing St, Sham Shui Po');

-- ============================================================
-- [FIXED] RawMaterial INSERTed BEFORE MaterialRequest (FK dependency)
-- ============================================================

INSERT INTO RawMaterial (MaterialID, SupplierID, MaterialName, Unit, StockQty, ReorderLevel, UnitPurchasePrice) VALUES
(NULL, 'SUP-001', 'Solid Oak Wood',      'm³',  45.00, 10.00,  450.00),
(NULL, 'SUP-001', 'MDF Board',           'pcs', 320.00,50.00,   35.00),
(NULL, 'SUP-001', 'Plywood Sheet',       'pcs', 180.00,40.00,   38.00),
(NULL, 'SUP-002', 'Fabric Grey',         'm²',  800.00,100.00,  70.00),
(NULL, 'SUP-002', 'Fabric Beige',        'm²',  650.00,100.00,  68.00),
(NULL, 'SUP-002', 'Leather Brown',       'm²',  250.00,50.00,  220.00),
(NULL, 'SUP-002', 'Leather Black',       'm²',  190.00,50.00,  215.00),
(NULL, 'SUP-003', 'Steel Frame 50mm',    'pcs', 180.00,30.00,  150.00),
(NULL, 'SUP-003', 'Metal Bracket Set',   'set',  95.00,20.00,  150.00),
(NULL, 'SUP-004', 'High-Density Foam',   'pcs', 110.00,20.00,  150.00),
(NULL, 'SUP-004', 'Soft Cushion Filling','kg',  230.00,40.00,  100.00),
(NULL, 'SUP-005', 'Tempered Glass 8mm',  'pcs',  40.00,10.00,  120.00);

INSERT INTO RawMaterialMovement (MovementID, MaterialID, MovementType, Quantity, MovementDate, RecordedBy) VALUES
(NULL, 'MAT-001', 'Inbound',  20.00, '2026-01-05 09:00:00', 'S-005'),
(NULL, 'MAT-002', 'Inbound', 200.00, '2026-01-05 09:30:00', 'S-005'),
(NULL, 'MAT-003', 'Inbound', 100.00, '2026-01-05 10:00:00', 'S-005'),
(NULL, 'MAT-004', 'Inbound', 500.00, '2026-01-06 09:00:00', 'S-005'),
(NULL, 'MAT-005', 'Inbound', 400.00, '2026-01-06 09:30:00', 'S-005'),
(NULL, 'MAT-006', 'Inbound', 150.00, '2026-01-07 10:00:00', 'S-005'),
(NULL, 'MAT-007', 'Inbound', 120.00, '2026-01-07 10:30:00', 'S-005'),
(NULL, 'MAT-008', 'Inbound', 100.00, '2026-01-08 09:00:00', 'S-006'),
(NULL, 'MAT-010', 'Inbound',  80.00, '2026-01-08 09:30:00', 'S-006'),
(NULL, 'MAT-001', 'Outbound',  5.00, '2026-01-15 13:00:00', 'S-005'),
(NULL, 'MAT-004', 'Outbound', 80.00, '2026-01-20 14:00:00', 'S-005'),
(NULL, 'MAT-006', 'Outbound', 30.00, '2026-01-22 14:30:00', 'S-006'),
(NULL, 'MAT-002', 'Outbound', 50.00, '2026-02-01 10:00:00', 'S-005'),
(NULL, 'MAT-010', 'Outbound', 20.00, '2026-02-05 11:00:00', 'S-006'),
(NULL, 'MAT-008', 'Inbound',  80.00, '2026-02-10 09:00:00', 'S-006'),
(NULL, 'MAT-011', 'Inbound', 150.00, '2026-02-10 09:30:00', 'S-006'),
(NULL, 'MAT-012', 'Inbound',  30.00, '2026-02-12 10:00:00', 'S-006'),
(NULL, 'MAT-003', 'Outbound', 40.00, '2026-02-18 13:00:00', 'S-005'),
(NULL, 'MAT-005', 'Outbound', 60.00, '2026-02-20 14:00:00', 'S-005'),
(NULL, 'MAT-009', 'Inbound',  60.00, '2026-03-01 09:00:00', 'S-006');

-- ============================================================
-- [FIXED] Quotation INSERTed BEFORE Order (FK dependency)
-- ============================================================

INSERT INTO Quotation (QuotationID, CustomerID, SalesStaffID, QuotationDate, ValidUntil,
    PaymentMethod, EstimatedDelivery, Discount, SubTotal, Total, Status, Remarks) VALUES
(NULL, 'C-006', 'S-001', '2026-03-15', '2026-04-15', 'BankTransfer', '2026-05-30',
    2000.00, 79000.00, 77000.00, 'Accepted', 'Metro Office initial enquiry - 10 beds + 10 chair sets'),
(NULL, 'C-008', 'S-002', '2026-04-01', '2026-05-01', 'FPS',           '2026-06-15',
       0.00, 23000.00, 23000.00, 'Sent',    'Pacific Serviced Apt - 4 office chairs + 2 desks'),
(NULL, 'C-010', 'S-002', '2026-04-10', '2026-05-10', 'CreditCard',    '2026-06-01',
     500.00,  8500.00,  8000.00, 'Draft',   'Lau Cheuk Hin custom dining set enquiry');

INSERT INTO QuotationItem (QuotationItemID, QuotationID, ProductID, Quantity, UnitPrice,
    Discount, LineTotal, IsCustom, CustomDesc) VALUES
(NULL, 'QUO-20260315-1', 'P-004', 10, 5500.00, 1000.00, 54000.00, FALSE, NULL),
(NULL, 'QUO-20260315-1', 'P-008', 10, 2400.00, 1000.00, 23000.00, FALSE, NULL),
(NULL, 'QUO-20260401-1', 'P-003',  4, 1200.00,    0.00,  4800.00, FALSE, NULL),
(NULL, 'QUO-20260401-1', 'P-012',  2, 3600.00,    0.00,  7200.00,  TRUE, 'Built-in cable tray, natural oak finish'),
(NULL, 'QUO-20260410-1', 'P-011',  1, 8500.00,  500.00,  8000.00,  TRUE, 'Walnut wood, round edges, 6 matching chairs');

-- ============================================================
-- [FIXED] Order INSERT now comes AFTER Quotation
-- ============================================================

INSERT INTO `Order` (OrderID, QuotationID, CustomerID, SalesStaffID, OrderDate, RequiredDate, PaymentStatus, Status) VALUES
(NULL, NULL,                   'C-001', 'S-001', '2026-01-08', '2026-02-08', 'Paid',     'Delivered'),
(NULL, NULL,                   'C-006', 'S-001', '2026-01-12', '2026-02-20', 'Paid',     'Delivered'),
(NULL, NULL,                   'C-002', 'S-003', '2026-01-20', '2026-03-10', 'Paid',     'Delivered'),
(NULL, 'QUO-20260315-1',       'C-007', 'S-002', '2026-02-03', '2026-03-15', 'Paid',     'Shipped'),
(NULL, NULL,                   'C-003', 'S-003', '2026-02-10', '2026-04-01', 'Paid',     'InProduction'),
(NULL, NULL,                   'C-008', 'S-001', '2026-02-18', '2026-03-30', 'Paid',     'ReadyToShip'),
(NULL, NULL,                   'C-004', 'S-002', '2026-03-01', '2026-04-10', 'Paid',     'InProduction'),
(NULL, NULL,                   'C-009', 'S-001', '2026-03-05', '2026-05-01', 'Pending',  'Pending'),
(NULL, NULL,                   'C-005', 'S-004', '2026-03-12', '2026-04-20', 'Pending',  'Pending'),
(NULL, NULL,                   'C-010', 'S-003', '2026-03-20', '2026-05-15', 'Pending',  'Pending');

INSERT INTO OrderItem (OrderItemID, OrderID, ProductID, Quantity, UnitPrice, ItemType, SerialNumber, CustomStatus) VALUES
(NULL, 'ORD-20260108-1', 'P-001', 1, 4800.00, 'Standard', 'SO0000041', 'NotRequired'),
(NULL, 'ORD-20260108-1', 'P-005', 1,  980.00, 'Standard', 'CT0000052', 'NotRequired'),
(NULL, 'ORD-20260112-1', 'P-003', 6, 1200.00, 'Standard', 'OC0000063', 'NotRequired'),
(NULL, 'ORD-20260112-1', 'P-006', 4,  760.00, 'Standard', 'BS0000074', 'NotRequired'),
(NULL, 'ORD-20260120-1', 'P-009', 1, 7200.00, 'Custom',   'LS0000085', 'Confirmed'),
(NULL, 'ORD-20260203-1', 'P-004', 10,5500.00, 'Standard', 'BD0000096', 'NotRequired'),
(NULL, 'ORD-20260203-1', 'P-008', 10,2400.00, 'Standard', 'DC0000107', 'NotRequired'),
(NULL, 'ORD-20260210-1', 'P-009', 1, 7200.00, 'Custom',   NULL,        'Confirmed'),
(NULL, 'ORD-20260210-1', 'P-012', 1, 3600.00, 'Custom',   NULL,        'Confirmed'),
(NULL, 'ORD-20260218-1', 'P-002', 6, 3200.00, 'Standard', NULL,        'NotRequired'),
(NULL, 'ORD-20260218-1', 'P-007', 6, 1850.00, 'Standard', NULL,        'NotRequired'),
(NULL, 'ORD-20260301-1', 'P-003', 4, 1200.00, 'Standard', NULL,        'NotRequired'),
(NULL, 'ORD-20260301-1', 'P-001', 2, 4800.00, 'Standard', NULL,        'NotRequired'),
(NULL, 'ORD-20260305-1', 'P-010', 3, 9800.00, 'Custom',   NULL,        'PendingConfirm'),
(NULL, 'ORD-20260312-1', 'P-005', 2,  980.00, 'Standard', NULL,        'NotRequired'),
(NULL, 'ORD-20260312-1', 'P-006', 2,  760.00, 'Standard', NULL,        'NotRequired'),
(NULL, 'ORD-20260320-1', 'P-011', 1, 8500.00, 'Custom',   NULL,        'Draft');

INSERT INTO OrderItemCustomization (CustomID, OrderItemID, DimensionL, DimensionW, DimensionH, Material, Color, FinishType, Fabric, CustomDescription, QuoteConfirmed, DepositPaid, FinalConfirmedAt, Remarks) VALUES
(NULL, 'OI-005', 240.0, 180.0, 85.0, 'Solid Wood Frame', 'Navy Blue',    NULL,    'Premium Linen', 'Add extra USB charging port on the right armrest', TRUE,  TRUE,  '2026-01-22 10:30:00', 'Customer requested high density foam'),
(NULL, 'OI-008', 260.0, 200.0, 90.0, 'Steel Frame',      'Charcoal Grey',NULL,    'Leather',       'Left facing chaise, taller backrest',               TRUE,  TRUE,  '2026-02-12 14:00:00', 'VIP customer, ensure stitching is perfect'),
(NULL, 'OI-009', 150.0,  70.0, 75.0, 'Solid Oak Wood',   'Natural Oak',  'Matte', NULL,            'Include built-in cable management tray',            TRUE,  TRUE,  '2026-02-13 11:15:00', NULL),
(NULL, 'OI-014', 300.0,  60.0,240.0, 'MDF Board',        'White',        'Glossy',NULL,            'Floor to ceiling, 4 sliding doors with mirrors',   FALSE, FALSE, NULL,                  'Pending site measurement by S-003'),
(NULL, 'OI-017', 220.0, 100.0, 75.0, 'Walnut Wood',      'Dark Walnut',  'Satin', NULL,            'Round edges, matching set of 6 custom chairs',      FALSE, FALSE, NULL,                  'Waiting for customer to confirm wood stain samples');

-- Sample customization images (ImageData stored as empty blob for sample data; real data uploaded via application)
INSERT INTO CustomizationImage (ImageID, CustomID, ImageData) VALUES
(NULL, 'CUST-001', ''),
(NULL, 'CUST-001', ''),
(NULL, 'CUST-002', ''),
(NULL, 'CUST-004', '');

-- ============================================================
-- [v4.0 NEW] ProductionTracking, MaterialRequest, RawMaterialTransfer
-- ============================================================

INSERT INTO ProductionTracking (TrackingID, OrderItemID, Step, Status, AssignedTo,
    StartDate, CompletedDate, Remarks) VALUES
(NULL, 'OI-006', 'Tapping',    'Completed',  'S-005', '2026-03-16 08:00:00', '2026-03-16 12:00:00', 'Bed frame wood panels'),
(NULL, 'OI-006', 'Cutting',    'Completed',  'S-005', '2026-03-16 13:00:00', '2026-03-17 16:00:00', NULL),
(NULL, 'OI-006', 'FJointing',  'Completed',  'S-006', '2026-03-18 08:00:00', '2026-03-18 14:00:00', 'Frame joint assembly'),
(NULL, 'OI-006', 'Drilling',   'InProgress', 'S-006', '2026-03-18 15:00:00', NULL,                  'Drilling screw holes'),
(NULL, 'OI-006', 'Sanding',    'Pending',    NULL,     NULL,                   NULL,                  NULL),
(NULL, 'OI-006', 'Painting',   'Pending',    NULL,     NULL,                   NULL,                  NULL),
(NULL, 'OI-006', 'Varnishing', 'Pending',    NULL,     NULL,                   NULL,                  NULL),
(NULL, 'OI-006', 'Drying',     'Pending',    NULL,     NULL,                   NULL,                  NULL);

-- [v5.3 REDESIGNED] MaterialRequest (header) + MaterialRequestItem (items)
INSERT INTO MaterialRequest (RequestID, OrderItemID,
    UrgencyLevel, RequiredDeliveryDate, RequestedBy, Status, ApprovedBy, ApprovedDate, Remarks) VALUES
(NULL, 'OI-006', 'High',   '2026-03-20', 'S-005', 'Approved',  'S-006', '2026-03-16 09:00:00', 'Solid Oak + brackets for bed frames'),
(NULL, 'OI-006', 'Medium', '2026-03-22', 'S-005', 'Requested', NULL,     NULL,                  'Metal bracket sets for bed assembly'),
(NULL, 'OI-008', 'Low',    '2026-03-25', 'S-006', 'Requested', NULL,     NULL,                  'Grey fabric for dining chairs');

-- Material Request Items (RequestItemID auto-generated by trigger → MRI-NNN)
INSERT INTO MaterialRequestItem (RequestItemID, RequestID, MaterialID, Quantity, Unit, Remarks) VALUES
-- MR-0001 (Approved — bed frame materials)
(NULL, 'MR-0001', 'MAT-001', 15.00, 'm³',  'Solid Oak Wood for bed frames'),
-- MR-0002 (Requested — bracket sets)
(NULL, 'MR-0002', 'MAT-009', 20.00, 'set', 'Metal bracket sets for bed assembly'),
-- MR-0003 (Requested — grey fabric)
(NULL, 'MR-0003', 'MAT-004', 30.00, 'm²',  'Grey fabric for dining chairs');

INSERT INTO RawMaterialTransfer (TransferID, TransferDate, TransferType,
    OrderID, ProductionID, RequestedBy, FromLocation, ToLocation, Status,
    ApprovedBy, IssuedBy, DeliveredBy, ReceivedBy,
    ApprovedDate, IssuedDate, DeliveringDate, ReceivedDate, Remarks) VALUES
(NULL, '2026-03-16', 'RawMaterial_Out', 'ORD-20260203-1', 'PROD-001', 'S-005',
    'Main Warehouse', 'Production Workshop A', 'Delivering',
    'S-006', 'S-005', 'S-007', NULL,
    '2026-03-16', '2026-03-16', '2026-03-17 09:00:00', NULL,
    'Solid Oak Wood and Metal Brackets for bed frame production (Order ORD-20260203-1)'),
(NULL, '2026-03-20', 'RawMaterial_Out', NULL, 'PROD-002', 'S-006',
    'Main Warehouse', 'Production Workshop B', 'Approved',
    'S-005', NULL, NULL, NULL,
    '2026-03-20', NULL, NULL, NULL,
    'Fabric and Foam replenishment for dining chair production'),
(NULL, '2026-04-01', 'Product_In', 'ORD-20260108-1', 'PROD-003', 'S-005',
    'Production Workshop A', 'Finished Goods Warehouse', 'Pending',
    NULL, NULL, NULL, NULL,
    NULL, NULL, NULL, NULL,
    'Completed Luxury 3-Seat Sofa + Coffee Table ready for transfer');

INSERT INTO RawMaterialTransferItem (TransferItemID, TransferID, MaterialID,
    ProductID, Quantity, Unit, Description, Remarks) VALUES
(NULL, 'IT2603160001', 'MAT-001', NULL, 10.00, 'm3',    'Solid Oak Wood',    'For bed frame structure'),
(NULL, 'IT2603160001', 'MAT-009', NULL, 10.00, 'set',   'Metal Bracket Set', 'For bed frame assembly'),
(NULL, 'IT2603200001', 'MAT-004', NULL, 50.00, 'm2',    'Fabric Grey',       'Dining chair upholstery'),
(NULL, 'IT2603200001', 'MAT-010', NULL, 15.00, 'pcs',   'High-Density Foam', 'Dining chair cushion'),
(NULL, 'IT2604010001', NULL,      'P-001',  1.00, 'pcs', 'Luxury 3-Seat Sofa', 'ORD-20260108-1 completed'),
(NULL, 'IT2604010001', NULL,      'P-005',  1.00, 'pcs', 'Coffee Table',       'ORD-20260108-1 completed');

-- ============================================================
-- DeliveryNote + Items + Tracking + ReplySlip
-- ============================================================

INSERT INTO DeliveryNote (DNID, OrderID, IssuedByStaff, DispatchDate, InvoiceAddress, DeliveryMethod, Status) VALUES
(NULL, 'ORD-20260108-1', 'S-007', '2026-02-07', 'Flat 5A, 12 Nathan Rd, Kowloon',    'Standard Delivery',     'Delivered'),
(NULL, 'ORD-20260112-1', 'S-007', '2026-02-19', '18/F Tower 1, Kowloon Bay',          'Express Delivery',      'Delivered'),
(NULL, 'ORD-20260120-1', 'S-008', '2026-03-09', 'Room 3B, 88 Queen Rd, HK Island',   'Standard Delivery',     'Delivered'),
(NULL, 'ORD-20260203-1', 'S-007', '2026-03-14', '1 Harbour Rd, Wan Chai',             'Third-Party Logistics', 'InTransit'),
(NULL, 'ORD-20260218-1', 'S-008', '2026-03-28', '5/F Pacific Plaza, Tsim Sha Tsui',  'Standard Delivery',     'Issued'),
(NULL, 'ORD-20260301-1', 'S-007', '2026-04-10', 'Block 3, 22 Sha Tin Centre St, NT', 'Express Delivery',      'Planned'),
(NULL, 'ORD-20260312-1', 'S-008', '2026-04-20', 'Flat 8C, 30 Tung Choi St, MK',      'Standard Delivery',     'Planned');

INSERT INTO DeliveryNoteItem (DNItemID, DNID, ProductID, Description, QtyOrdered, QtyDelivered) VALUES
(NULL, 'DN-001', 'P-001', 'Luxury 3-Seat Sofa',      1,  1),
(NULL, 'DN-001', 'P-005', 'Coffee Table',             1,  1),
(NULL, 'DN-002', 'P-003', 'Ergonomic Office Chair',   6,  6),
(NULL, 'DN-002', 'P-006', 'Bookshelf 5-Tier',         4,  4),
(NULL, 'DN-003', 'P-009', 'Custom L-Shape Sofa',      1,  1),
(NULL, 'DN-004', 'P-004', 'King Size Bed Frame',      10, 7),
(NULL, 'DN-004', 'P-008', 'Dining Chair (Set of 4)', 10,  3),
(NULL, 'DN-005', 'P-002', 'Solid Wood Dining Table',  6,  0),
(NULL, 'DN-005', 'P-007', 'TV Console 180cm',         6,  0);

INSERT INTO DeliveryTracking (TrackingID, DNID, Location, Action, ScanTime, UpdatedBy, Remarks) VALUES
(NULL, 'DN-001', 'Kwun Tong Warehouse',   'Departed',       '2026-02-07 08:00:00', 'S-007', 'Goods loaded onto delivery van'),
(NULL, 'DN-001', 'Kowloon Transit Hub',   'Arrived',        '2026-02-07 09:30:00', 'S-007', NULL),
(NULL, 'DN-001', 'Kowloon Transit Hub',   'Departed',       '2026-02-07 10:00:00', 'S-007', NULL),
(NULL, 'DN-001', 'Nathan Rd, Kowloon',   'OutForDelivery', '2026-02-07 14:00:00', 'S-007', 'Final delivery attempt'),
(NULL, 'DN-001', 'Flat 5A, 12 Nathan Rd','Delivered',      '2026-02-07 15:15:00', 'S-007', 'Received by Chan Tai Man'),
(NULL, 'DN-002', 'Kwun Tong Warehouse',   'Departed',       '2026-02-19 08:00:00', 'S-007', 'Goods loaded onto delivery van'),
(NULL, 'DN-002', 'Kowloon Bay Hub',       'Arrived',        '2026-02-19 09:00:00', 'S-008', NULL),
(NULL, 'DN-002', 'Kowloon Bay Hub',       'Departed',       '2026-02-19 09:30:00', 'S-008', NULL),
(NULL, 'DN-002', 'Tower 1, Kowloon Bay', 'OutForDelivery', '2026-02-19 10:30:00', 'S-008', NULL),
(NULL, 'DN-002', 'Tower 1, Kowloon Bay', 'Delivered',      '2026-02-19 11:00:00', 'S-008', 'Received by John Wu'),
(NULL, 'DN-003', 'Kwun Tong Warehouse',   'Departed',       '2026-03-09 08:30:00', 'S-008', 'Custom sofa - handle with care'),
(NULL, 'DN-003', 'HK Island Transit Hub','Arrived',        '2026-03-09 10:00:00', 'S-008', 'Cross-harbour tunnel delay'),
(NULL, 'DN-003', 'HK Island Transit Hub','Departed',       '2026-03-09 10:30:00', 'S-008', NULL),
(NULL, 'DN-003', 'Queen Rd, HK Island',  'OutForDelivery', '2026-03-09 13:30:00', 'S-008', NULL),
(NULL, 'DN-003', 'Room 3B, 88 Queen Rd', 'Delivered',      '2026-03-09 14:45:00', 'S-008', 'Received by Yip Siu Fong'),
(NULL, 'DN-004', 'Kwun Tong Warehouse',   'Departed',       '2026-03-14 07:30:00', 'S-007', '10 bed frames + 10 dining chairs'),
(NULL, 'DN-004', 'Kowloon Transit Hub',   'Arrived',        '2026-03-14 09:00:00', 'S-007', NULL),
(NULL, 'DN-004', 'Kowloon Transit Hub',   'Departed',       '2026-03-14 10:00:00', 'S-007', NULL),
(NULL, 'DN-004', 'Wan Chai Transit Hub',  'Arrived',        '2026-03-14 12:00:00', 'S-007', 'Partial delivery - 7 bed frames + 3 chairs only'),
(NULL, 'DN-005', 'Kwun Tong Warehouse',   'Departed',       '2026-03-28 08:00:00', 'S-008', 'Awaiting dispatch to Tsim Sha Tsui');

INSERT INTO ReplySlip (ReplySlipID, DNID, ReceivedBy, ReceivedDate, Status) VALUES
(NULL, 'DN-001', 'Chan Tai Man',          '2026-02-07 15:20:00', 'Confirmed'),
(NULL, 'DN-002', 'John Wu (Metro Office)','2026-02-19 11:00:00', 'Confirmed'),
(NULL, 'DN-003', 'Yip Siu Fong',          '2026-03-09 14:45:00', 'Confirmed'),
(NULL, 'DN-004', NULL,                    NULL,                  'Pending'),
(NULL, 'DN-005', NULL,                    NULL,                  'Pending');

INSERT INTO Complaint (ComplaintID, CustomerID, HandledByID, OrderID, ComplaintType, Description, ComplaintDate, Status, Resolution) VALUES
(NULL, 'C-001', 'S-003', 'ORD-20260108-1', 'Damaged', 'Sofa armrest cracked upon delivery.',            '2026-02-08', 'Resolved',   'Replacement'),
(NULL, 'C-006', 'S-003', 'ORD-20260112-1', 'Wrong',   'Received grey chairs instead of ordered black.','2026-02-20', 'Resolved',   'Replacement'),
(NULL, 'C-002', 'S-004', 'ORD-20260120-1', 'Quality', 'Sofa stitching coming apart after 2 weeks.',    '2026-03-25', 'InProgress', 'Repair'),
(NULL, 'C-007', 'S-003', 'ORD-20260203-1', 'Delayed', 'Only 7 of 10 bed frames delivered, 3 outstanding.','2026-03-16','Open',     NULL),
(NULL, 'C-003', 'S-004', 'ORD-20260210-1', 'Damaged', 'Custom sofa corner damaged during transit.',    '2026-04-02', 'Open',       NULL),
(NULL, 'C-010', 'S-003', NULL,             'Other',   'Enquiry about delivery schedule for pending order.','2026-03-22','Closed',   'NoAction');

-- Sample complaint images (ImageData stored as empty blob for sample data; real data uploaded via application)
INSERT INTO ComplaintImage (ImageID, ComplaintID, ImageData) VALUES
(NULL, 'CMP-001', '' ),
(NULL, 'CMP-001', '' ),
(NULL, 'CMP-003', '' ),
(NULL, 'CMP-005', '' ),
(NULL, 'CMP-005', '' );

INSERT INTO ReturnRequest (ReturnID, ComplaintID, OrderID, ReturnType, ReturnReason, RequestDate, ReturnDate, Status, ProcessedByID, ReceivedByID, RefundAmount, RefundDate, Remarks) VALUES
(NULL, 'CMP-001', 'ORD-20260108-1', 'Replacement', 'Armrest broken on delivery, request replacement unit.',       '2026-02-09', '2026-02-12', 'Completed', 'S-007', 'S-005', NULL,    NULL, 'Item returned in original packaging'),
(NULL, 'CMP-002', 'ORD-20260112-1', 'Replacement', 'Wrong colour chairs received, original order was black.',     '2026-02-21', '2026-02-24', 'Completed', 'S-007', 'S-005', NULL,    NULL, 'All 6 chairs returned'),
(NULL, 'CMP-003', 'ORD-20260120-1', 'Refund',      'Sofa quality unacceptable, stitching defective after 2 weeks.','2026-03-26', NULL,        'Approved',  'S-007', NULL,    7200.00, NULL, NULL),
(NULL, 'CMP-005', 'ORD-20260210-1', 'Replacement', 'Custom sofa corner visibly dented, request replacement.',     '2026-04-03', NULL,        'Pending',   NULL,    NULL,    NULL,    NULL, NULL);

-- Sample return images (ImageData stored as empty blob for sample data; real data uploaded via application)
INSERT INTO ReturnImage (ImageID, ReturnID, ImageData) VALUES
(NULL, 'RET-001', '' ),
(NULL, 'RET-002', '' ),
(NULL, 'RET-002', '' ),
(NULL, 'RET-004', '' ),
(NULL, 'RET-004', '' );

INSERT INTO Invoice (InvoiceID, OrderID, BillingAddress, DispatchDate, DeliveryMethod, SubTotal, Discount, OtherCharges, Total, Status, IssuedDate, Remarks) VALUES
(NULL, 'ORD-20260108-1', 'Flat 5A, 12 Nathan Rd, Kowloon',    '2026-02-07', 'Standard Delivery',       5780.00,    0.00, 150.00,  5930.00, 'Paid',   '2026-01-08', 'Luxury 3-Seat Sofa + Coffee Table — standard delivery'),
(NULL, 'ORD-20260112-1', '18/F Tower 1, Kowloon Bay',         '2026-02-19', 'Express Delivery',       10240.00,  500.00,   0.00,  9740.00, 'Paid',   '2026-01-12', 'Metro Office Solutions bulk order — 6 chairs + 4 bookshelves'),
(NULL, 'ORD-20260120-1', 'Room 3B, 88 Queen Rd, HK Island',   '2026-03-09', 'Standard Delivery',       7200.00,    0.00, 200.00,  7400.00, 'Paid',   '2026-01-20', 'Custom L-Shape Sofa — delivery surcharge'),
(NULL, 'ORD-20260203-1', '1 Harbour Rd, Wan Chai',            '2026-03-14', 'Third-Party Logistics',  79000.00, 2000.00,   0.00, 77000.00, 'Issued', '2026-02-03', 'Grand Hotel HK — 10 beds + 10 dining chair sets'),
(NULL, 'ORD-20260210-1', 'Block 3, 22 Sha Tin Centre St, NT', NULL,          NULL,                    10800.00,    0.00,   0.00, 10800.00, 'Issued', '2026-02-10', 'Custom sofa + study desk — delivery pending'),
(NULL, 'ORD-20260218-1', '5/F Pacific Plaza, Tsim Sha Tsui',  '2026-03-28', 'Standard Delivery',      30300.00, 1000.00, 300.00, 29600.00, 'Issued', '2026-02-18', 'Pacific Serviced Apt — 6 dining tables + 6 TV consoles'),
(NULL, 'ORD-20260301-1', 'Flat 5A, 12 Nathan Rd, Kowloon',    NULL,          NULL,                    14400.00,    0.00,   0.00, 14400.00, 'Issued', '2026-03-01', 'Repeat customer — 4 office chairs + 2 sofas'),
(NULL, 'ORD-20260305-1', '22/F One Exchange Sq, Central',     NULL,          NULL,                    29400.00, 1500.00, 500.00, 28400.00, 'Issued', '2026-03-05', 'Sunrise Co-Working — 3 custom wardrobes, installation included'),
(NULL, 'ORD-20260312-1', 'Flat 8C, 30 Tung Choi St, MK',      NULL,          NULL,                     3480.00,    0.00,   0.00,  3480.00, 'Issued', '2026-03-12', 'Coffee table + bookshelf — self pickup requested'),
(NULL, 'ORD-20260320-1', 'Unit 1, 9 Fuk Wing St, Sham Shui Po', NULL,       NULL,                     8500.00,    0.00, 100.00,  8600.00, 'Issued', '2026-03-20', 'Custom dining set — awaiting wood stain confirmation');

INSERT INTO InvoiceItem (InvItemID, InvoiceID, ProductID, Quantity, UnitCost, Discount, LineTotal) VALUES
(NULL, 'INV-001', 'P-001', 1,  4800.00,    0.00,  4800.00),
(NULL, 'INV-001', 'P-005', 1,   980.00,    0.00,   980.00),
(NULL, 'INV-002', 'P-003', 6,  1200.00,  300.00,  6900.00),
(NULL, 'INV-002', 'P-006', 4,   760.00,  200.00,  2840.00),
(NULL, 'INV-003', 'P-009', 1,  7200.00,    0.00,  7200.00),
(NULL, 'INV-004', 'P-004', 10, 5500.00, 1000.00, 54000.00),
(NULL, 'INV-004', 'P-008', 10, 2400.00, 1000.00, 23000.00),
(NULL, 'INV-005', 'P-009', 1,  7200.00,    0.00,  7200.00),
(NULL, 'INV-005', 'P-012', 1,  3600.00,    0.00,  3600.00),
(NULL, 'INV-006', 'P-002', 6,  3200.00,  500.00, 18700.00),
(NULL, 'INV-006', 'P-007', 6,  1850.00,  500.00, 10600.00),
(NULL, 'INV-007', 'P-003', 4,  1200.00,    0.00,  4800.00),
(NULL, 'INV-007', 'P-001', 2,  4800.00,    0.00,  9600.00),
(NULL, 'INV-008', 'P-010', 3,  9800.00, 1500.00, 27900.00),
(NULL, 'INV-009', 'P-005', 2,   980.00,    0.00,  1960.00),
(NULL, 'INV-009', 'P-006', 2,   760.00,    0.00,  1520.00),
(NULL, 'INV-010', 'P-011', 1,  8500.00,    0.00,  8500.00);

-- ============================================================
-- [v5.0 NEW] PROCUREMENT SAMPLE DATA
--   5 Purchase Orders covering all 5 statuses
--   9 Purchase Order Items (incl. partial receipt scenario)
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
   '2026-02-15 16:00:00', 'Quarterly fabric restock — 600m2 split delivery'),

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

-- Purchase Order Items (POItemID auto-generated by trigger; pass NULL)
INSERT INTO PurchaseOrderItem
  (POItemID, PurchaseOrderID, MaterialID, Quantity, Unit, UnitPrice,
   ReceivedQty, MaterialRequestID, Remarks)
VALUES
  -- PO 1 items — fully received
  (NULL, 'PO-20260110-001', 'MAT-001',  40.00, 'm3',  450.00,
   40.00, NULL, 'Solid Oak Wood — 40m3 at $450/m3'),
  (NULL, 'PO-20260110-001', 'MAT-003',  60.00, 'pcs',  35.00,
   60.00, NULL, 'Plywood Sheet — 60pcs at $35/pc'),

  -- PO 2 items — partial receipt (400 of 600m2 arrived)
  (NULL, 'PO-20260215-001', 'MAT-004', 600.00, 'm2',   70.00,
   400.00, NULL, 'Fabric Grey — 600m2, 400 received'),

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
-- [v5.0 NEW] VIEW — open procurement summary
--   Lists all Sent / PartiallyReceived POs sorted by ExpectedDeliveryDate
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

-- ============================================================
-- [v5.2 NEW] BILL OF MATERIALS SAMPLE DATA
--   Defines raw materials required per 1 unit of each product.
--   Run after Product and RawMaterial are populated.
-- ============================================================

INSERT INTO ProductMaterial (ProductMaterialID, ProductID, MaterialID, QuantityPerUnit, Unit, Remarks) VALUES
-- P-001: Luxury 3-Seat Sofa
(NULL, 'P-001', 'MAT-001', 0.30, 'm³',  'Solid oak frame'),
(NULL, 'P-001', 'MAT-004', 12.00, 'm²', 'Grey fabric upholstery'),
(NULL, 'P-001', 'MAT-008', 1.00, 'pcs', 'Steel frame reinforcement'),
(NULL, 'P-001', 'MAT-010', 3.00, 'pcs', 'High-density foam cushions'),
(NULL, 'P-001', 'MAT-009', 1.00, 'set', 'Metal brackets for assembly'),

-- P-002: Solid Wood Dining Table
(NULL, 'P-002', 'MAT-001', 0.50, 'm³',  'Solid oak tabletop + legs'),
(NULL, 'P-002', 'MAT-009', 1.00, 'set', 'Metal brackets for leg joints'),

-- P-003: Ergonomic Office Chair
(NULL, 'P-003', 'MAT-008', 1.00, 'pcs', 'Steel frame base'),
(NULL, 'P-003', 'MAT-004', 2.50, 'm²',  'Fabric back + seat'),
(NULL, 'P-003', 'MAT-010', 1.00, 'pcs', 'Foam seat cushion'),
(NULL, 'P-003', 'MAT-009', 1.00, 'set', 'Bracket set for assembly'),

-- P-004: King Size Bed Frame
(NULL, 'P-004', 'MAT-001', 0.80, 'm³',  'Solid oak frame'),
(NULL, 'P-004', 'MAT-003', 4.00, 'pcs',  'Plywood slats base'),
(NULL, 'P-004', 'MAT-009', 2.00, 'set',  'Bracket sets for frame assembly'),

-- P-005: Coffee Table
(NULL, 'P-005', 'MAT-001', 0.15, 'm³',  'Oak legs + frame'),
(NULL, 'P-005', 'MAT-012', 1.00, 'pcs',  'Tempered glass top'),

-- P-006: Bookshelf 5-Tier
(NULL, 'P-006', 'MAT-002', 5.00, 'pcs',  'MDF shelves'),
(NULL, 'P-006', 'MAT-009', 1.00, 'set',  'Bracket set for wall mounting'),

-- P-007: TV Console 180cm
(NULL, 'P-007', 'MAT-001', 0.25, 'm³',  'Oak frame'),
(NULL, 'P-007', 'MAT-012', 1.00, 'pcs',  'Tempered glass doors'),
(NULL, 'P-007', 'MAT-009', 1.00, 'set',  'Bracket set for assembly'),

-- P-008: Dining Chair (Set of 4)
(NULL, 'P-008', 'MAT-001', 0.10, 'm³',  'Oak frame per chair (×4)'),
(NULL, 'P-008', 'MAT-004', 4.00, 'm²',  'Grey fabric seats (×4)'),
(NULL, 'P-008', 'MAT-010', 4.00, 'pcs',  'Foam cushions (×4)'),

-- P-009: Custom L-Shape Sofa
(NULL, 'P-009', 'MAT-006', 18.00, 'm²', 'Brown leather upholstery'),
(NULL, 'P-009', 'MAT-008', 2.00, 'pcs',  'Steel frames (L-shape)'),
(NULL, 'P-009', 'MAT-010', 5.00, 'pcs',  'Foam cushions'),
(NULL, 'P-009', 'MAT-011', 10.00, 'kg',  'Soft cushion filling'),

-- P-010: Custom Built-in Wardrobe
(NULL, 'P-010', 'MAT-002', 12.00, 'pcs', 'MDF panels for wardrobe'),
(NULL, 'P-010', 'MAT-003', 4.00, 'pcs',  'Plywood backing'),
(NULL, 'P-010', 'MAT-009', 3.00, 'set',  'Bracket sets for installation'),

-- P-011: Custom Dining Set
(NULL, 'P-011', 'MAT-001', 0.60, 'm³',  'Oak table + chair frames'),
(NULL, 'P-011', 'MAT-005', 6.00, 'm²',  'Beige fabric chair seats'),
(NULL, 'P-011', 'MAT-010', 6.00, 'pcs',  'Foam cushions for chairs'),

-- P-012: Custom Study Desk
(NULL, 'P-012', 'MAT-001', 0.20, 'm³',  'Oak desk frame'),
(NULL, 'P-012', 'MAT-012', 1.00, 'pcs',  'Tempered glass desktop');
