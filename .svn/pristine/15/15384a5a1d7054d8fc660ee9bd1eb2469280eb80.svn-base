IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [ApplicationUserRole] bit NOT NULL,
        [BranchRole] bit NOT NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [CustomerLineRole] bit NOT NULL,
        [CustomerRole] bit NOT NULL,
        [Email] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [HomeRole] bit NOT NULL,
        [LockoutEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [PasswordHash] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [ProductRole] bit NOT NULL,
        [PurchaseOrderLineRole] bit NOT NULL,
        [PurchaseOrderRole] bit NOT NULL,
        [ReceivingLineRole] bit NOT NULL,
        [ReceivingRole] bit NOT NULL,
        [SalesOrderLineRole] bit NOT NULL,
        [SalesOrderRole] bit NOT NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ShipmentLineRole] bit NOT NULL,
        [ShipmentRole] bit NOT NULL,
        [TransferInLineRole] bit NOT NULL,
        [TransferInRole] bit NOT NULL,
        [TransferOrderLineRole] bit NOT NULL,
        [TransferOrderRole] bit NOT NULL,
        [TransferOutLineRole] bit NOT NULL,
        [TransferOutRole] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [UserName] nvarchar(256) NULL,
        [VendorLineRole] bit NOT NULL,
        [VendorRole] bit NOT NULL,
        [WarehouseRole] bit NOT NULL,
        [isSuperAdmin] bit NOT NULL,
        [profilePictureUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [Branch] (
        [branchId] nvarchar(38) NOT NULL,
        [branchName] nvarchar(50) NOT NULL,
        [city] nvarchar(30) NULL,
        [country] nvarchar(30) NULL,
        [createdAt] datetime2 NOT NULL,
        [description] nvarchar(50) NULL,
        [province] nvarchar(30) NULL,
        [street1] nvarchar(50) NOT NULL,
        [street2] nvarchar(50) NULL,
        CONSTRAINT [PK_Branch] PRIMARY KEY ([branchId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [Customer] (
        [customerId] nvarchar(38) NOT NULL,
        [HasChild] nvarchar(max) NULL,
        [city] nvarchar(30) NULL,
        [country] nvarchar(30) NULL,
        [createdAt] datetime2 NOT NULL,
        [customerName] nvarchar(50) NOT NULL,
        [description] nvarchar(50) NULL,
        [province] nvarchar(30) NULL,
        [size] int NOT NULL,
        [street1] nvarchar(50) NOT NULL,
        [street2] nvarchar(50) NULL,
        CONSTRAINT [PK_Customer] PRIMARY KEY ([customerId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [Product] (
        [productId] nvarchar(38) NOT NULL,
        [barcode] nvarchar(50) NULL,
        [createdAt] datetime2 NOT NULL,
        [description] nvarchar(50) NULL,
        [productCode] nvarchar(50) NOT NULL,
        [productName] nvarchar(50) NOT NULL,
        [productType] int NOT NULL,
        [serialNumber] nvarchar(50) NULL,
        [uom] int NOT NULL,
        CONSTRAINT [PK_Product] PRIMARY KEY ([productId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [Vendor] (
        [vendorId] nvarchar(38) NOT NULL,
        [HasChild] nvarchar(max) NULL,
        [city] nvarchar(30) NULL,
        [country] nvarchar(30) NULL,
        [createdAt] datetime2 NOT NULL,
        [description] nvarchar(50) NULL,
        [province] nvarchar(30) NULL,
        [size] int NOT NULL,
        [street1] nvarchar(50) NOT NULL,
        [street2] nvarchar(50) NULL,
        [vendorName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Vendor] PRIMARY KEY ([vendorId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [Warehouse] (
        [warehouseId] nvarchar(38) NOT NULL,
        [branchId] nvarchar(38) NULL,
        [city] nvarchar(30) NULL,
        [country] nvarchar(30) NULL,
        [createdAt] datetime2 NOT NULL,
        [description] nvarchar(50) NULL,
        [province] nvarchar(30) NULL,
        [street1] nvarchar(50) NOT NULL,
        [street2] nvarchar(50) NULL,
        [warehouseName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Warehouse] PRIMARY KEY ([warehouseId]),
        CONSTRAINT [FK_Warehouse_Branch_branchId] FOREIGN KEY ([branchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [CustomerLine] (
        [customerLineId] nvarchar(38) NOT NULL,
        [createdAt] datetime2 NOT NULL,
        [customerId] nvarchar(38) NULL,
        [fax] nvarchar(20) NULL,
        [firstName] nvarchar(20) NOT NULL,
        [gender] int NOT NULL,
        [jobTitle] nvarchar(20) NOT NULL,
        [lastName] nvarchar(20) NOT NULL,
        [middleName] nvarchar(20) NULL,
        [mobilePhone] nvarchar(20) NULL,
        [nickName] nvarchar(20) NULL,
        [officePhone] nvarchar(20) NULL,
        [personalEmail] nvarchar(50) NULL,
        [salutation] int NOT NULL,
        [workEmail] nvarchar(50) NULL,
        CONSTRAINT [PK_CustomerLine] PRIMARY KEY ([customerLineId]),
        CONSTRAINT [FK_CustomerLine_Customer_customerId] FOREIGN KEY ([customerId]) REFERENCES [Customer] ([customerId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [SalesOrder] (
        [salesOrderId] nvarchar(38) NOT NULL,
        [HasChild] nvarchar(max) NULL,
        [createdAt] datetime2 NOT NULL,
        [customerId] nvarchar(38) NULL,
        [deliveryAddress] nvarchar(50) NULL,
        [deliveryDate] datetime2 NOT NULL,
        [description] nvarchar(100) NULL,
        [picCustomer] nvarchar(30) NOT NULL,
        [picInternal] nvarchar(30) NOT NULL,
        [referenceNumberExternal] nvarchar(30) NULL,
        [referenceNumberInternal] nvarchar(30) NULL,
        [salesOrderNumber] nvarchar(20) NOT NULL,
        [salesOrderStatus] int NOT NULL,
        [salesShipmentNumber] nvarchar(max) NULL,
        [soDate] datetime2 NOT NULL,
        [top] int NOT NULL,
        [totalDiscountAmount] decimal(18, 2) NOT NULL,
        [totalOrderAmount] decimal(18, 2) NOT NULL,
        CONSTRAINT [PK_SalesOrder] PRIMARY KEY ([salesOrderId]),
        CONSTRAINT [FK_SalesOrder_Customer_customerId] FOREIGN KEY ([customerId]) REFERENCES [Customer] ([customerId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [PurchaseOrder] (
        [purchaseOrderId] nvarchar(38) NOT NULL,
        [HasChild] nvarchar(max) NULL,
        [createdAt] datetime2 NOT NULL,
        [deliveryAddress] nvarchar(50) NULL,
        [deliveryDate] datetime2 NOT NULL,
        [description] nvarchar(100) NULL,
        [picInternal] nvarchar(30) NOT NULL,
        [picVendor] nvarchar(30) NOT NULL,
        [poDate] datetime2 NOT NULL,
        [purchaseOrderNumber] nvarchar(20) NOT NULL,
        [purchaseOrderStatus] int NOT NULL,
        [purchaseReceiveNumber] nvarchar(max) NULL,
        [referenceNumberExternal] nvarchar(30) NULL,
        [referenceNumberInternal] nvarchar(30) NULL,
        [top] int NOT NULL,
        [totalDiscountAmount] decimal(18, 2) NOT NULL,
        [totalOrderAmount] decimal(18, 2) NOT NULL,
        [vendorId] nvarchar(38) NULL,
        CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY ([purchaseOrderId]),
        CONSTRAINT [FK_PurchaseOrder_Vendor_vendorId] FOREIGN KEY ([vendorId]) REFERENCES [Vendor] ([vendorId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [VendorLine] (
        [vendorLineId] nvarchar(38) NOT NULL,
        [createdAt] datetime2 NOT NULL,
        [fax] nvarchar(20) NULL,
        [firstName] nvarchar(20) NOT NULL,
        [gender] int NOT NULL,
        [jobTitle] nvarchar(20) NOT NULL,
        [lastName] nvarchar(20) NOT NULL,
        [middleName] nvarchar(20) NULL,
        [mobilePhone] nvarchar(20) NULL,
        [nickName] nvarchar(20) NULL,
        [officePhone] nvarchar(20) NULL,
        [personalEmail] nvarchar(50) NULL,
        [salutation] int NOT NULL,
        [vendorId] nvarchar(38) NULL,
        [workEmail] nvarchar(50) NULL,
        CONSTRAINT [PK_VendorLine] PRIMARY KEY ([vendorLineId]),
        CONSTRAINT [FK_VendorLine_Vendor_vendorId] FOREIGN KEY ([vendorId]) REFERENCES [Vendor] ([vendorId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [TransferOrder] (
        [transferOrderId] nvarchar(38) NOT NULL,
        [HasChild] nvarchar(max) NULL,
        [branchFrombranchId] nvarchar(38) NULL,
        [branchIdFrom] nvarchar(38) NULL,
        [branchIdTo] nvarchar(38) NULL,
        [branchTobranchId] nvarchar(38) NULL,
        [createdAt] datetime2 NOT NULL,
        [description] nvarchar(100) NOT NULL,
        [picName] nvarchar(50) NOT NULL,
        [transferOrderDate] datetime2 NOT NULL,
        [transferOrderNumber] nvarchar(20) NOT NULL,
        [warehouseFromwarehouseId] nvarchar(38) NULL,
        [warehouseIdFrom] nvarchar(38) NULL,
        [warehouseIdTo] nvarchar(38) NULL,
        [warehouseTowarehouseId] nvarchar(38) NULL,
        CONSTRAINT [PK_TransferOrder] PRIMARY KEY ([transferOrderId]),
        CONSTRAINT [FK_TransferOrder_Branch_branchFrombranchId] FOREIGN KEY ([branchFrombranchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferOrder_Branch_branchTobranchId] FOREIGN KEY ([branchTobranchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferOrder_Warehouse_warehouseFromwarehouseId] FOREIGN KEY ([warehouseFromwarehouseId]) REFERENCES [Warehouse] ([warehouseId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferOrder_Warehouse_warehouseTowarehouseId] FOREIGN KEY ([warehouseTowarehouseId]) REFERENCES [Warehouse] ([warehouseId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [SalesOrderLine] (
        [salesOrderLineId] nvarchar(38) NOT NULL,
        [createdAt] datetime2 NOT NULL,
        [discountAmount] decimal(18, 2) NOT NULL,
        [price] decimal(18, 2) NOT NULL,
        [productId] nvarchar(38) NULL,
        [qty] real NOT NULL,
        [salesOrderId] nvarchar(38) NULL,
        [totalAmount] decimal(18, 2) NOT NULL,
        CONSTRAINT [PK_SalesOrderLine] PRIMARY KEY ([salesOrderLineId]),
        CONSTRAINT [FK_SalesOrderLine_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_SalesOrderLine_SalesOrder_salesOrderId] FOREIGN KEY ([salesOrderId]) REFERENCES [SalesOrder] ([salesOrderId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [Shipment] (
        [shipmentId] nvarchar(38) NOT NULL,
        [HasChild] nvarchar(max) NULL,
        [branchId] nvarchar(38) NULL,
        [createdAt] datetime2 NOT NULL,
        [customerId] nvarchar(38) NULL,
        [customerPO] nvarchar(50) NULL,
        [expeditionMode] int NOT NULL,
        [expeditionType] int NOT NULL,
        [invoice] nvarchar(50) NULL,
        [salesOrderId] nvarchar(38) NOT NULL,
        [shipmentDate] datetime2 NOT NULL,
        [shipmentNumber] nvarchar(20) NOT NULL,
        [warehouseId] nvarchar(38) NULL,
        CONSTRAINT [PK_Shipment] PRIMARY KEY ([shipmentId]),
        CONSTRAINT [FK_Shipment_Branch_branchId] FOREIGN KEY ([branchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Shipment_Customer_customerId] FOREIGN KEY ([customerId]) REFERENCES [Customer] ([customerId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Shipment_SalesOrder_salesOrderId] FOREIGN KEY ([salesOrderId]) REFERENCES [SalesOrder] ([salesOrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Shipment_Warehouse_warehouseId] FOREIGN KEY ([warehouseId]) REFERENCES [Warehouse] ([warehouseId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [PurchaseOrderLine] (
        [purchaseOrderLineId] nvarchar(38) NOT NULL,
        [createdAt] datetime2 NOT NULL,
        [discountAmount] decimal(18, 2) NOT NULL,
        [price] decimal(18, 2) NOT NULL,
        [productId] nvarchar(38) NULL,
        [purchaseOrderId] nvarchar(38) NULL,
        [qty] real NOT NULL,
        [totalAmount] decimal(18, 2) NOT NULL,
        CONSTRAINT [PK_PurchaseOrderLine] PRIMARY KEY ([purchaseOrderLineId]),
        CONSTRAINT [FK_PurchaseOrderLine_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PurchaseOrderLine_PurchaseOrder_purchaseOrderId] FOREIGN KEY ([purchaseOrderId]) REFERENCES [PurchaseOrder] ([purchaseOrderId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [Receiving] (
        [receivingId] nvarchar(38) NOT NULL,
        [HasChild] nvarchar(max) NULL,
        [branchId] nvarchar(38) NULL,
        [createdAt] datetime2 NOT NULL,
        [purchaseOrderId] nvarchar(38) NOT NULL,
        [receivingDate] datetime2 NOT NULL,
        [receivingNumber] nvarchar(20) NOT NULL,
        [vendorDO] nvarchar(50) NOT NULL,
        [vendorId] nvarchar(38) NULL,
        [vendorInvoice] nvarchar(50) NULL,
        [warehouseId] nvarchar(38) NULL,
        CONSTRAINT [PK_Receiving] PRIMARY KEY ([receivingId]),
        CONSTRAINT [FK_Receiving_Branch_branchId] FOREIGN KEY ([branchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Receiving_PurchaseOrder_purchaseOrderId] FOREIGN KEY ([purchaseOrderId]) REFERENCES [PurchaseOrder] ([purchaseOrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Receiving_Vendor_vendorId] FOREIGN KEY ([vendorId]) REFERENCES [Vendor] ([vendorId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Receiving_Warehouse_warehouseId] FOREIGN KEY ([warehouseId]) REFERENCES [Warehouse] ([warehouseId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [TransferIn] (
        [transferInId] nvarchar(38) NOT NULL,
        [HasChild] nvarchar(max) NULL,
        [branchFrombranchId] nvarchar(38) NULL,
        [branchIdFrom] nvarchar(38) NULL,
        [branchIdTo] nvarchar(38) NULL,
        [branchTobranchId] nvarchar(38) NULL,
        [createdAt] datetime2 NOT NULL,
        [description] nvarchar(100) NOT NULL,
        [transferInDate] datetime2 NOT NULL,
        [transferInNumber] nvarchar(20) NOT NULL,
        [transferOrderId] nvarchar(38) NOT NULL,
        [warehouseFromwarehouseId] nvarchar(38) NULL,
        [warehouseIdFrom] nvarchar(38) NULL,
        [warehouseIdTo] nvarchar(38) NULL,
        [warehouseTowarehouseId] nvarchar(38) NULL,
        CONSTRAINT [PK_TransferIn] PRIMARY KEY ([transferInId]),
        CONSTRAINT [FK_TransferIn_Branch_branchFrombranchId] FOREIGN KEY ([branchFrombranchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferIn_Branch_branchTobranchId] FOREIGN KEY ([branchTobranchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferIn_TransferOrder_transferOrderId] FOREIGN KEY ([transferOrderId]) REFERENCES [TransferOrder] ([transferOrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_TransferIn_Warehouse_warehouseFromwarehouseId] FOREIGN KEY ([warehouseFromwarehouseId]) REFERENCES [Warehouse] ([warehouseId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferIn_Warehouse_warehouseTowarehouseId] FOREIGN KEY ([warehouseTowarehouseId]) REFERENCES [Warehouse] ([warehouseId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [TransferOrderLine] (
        [transferOrderLineId] nvarchar(38) NOT NULL,
        [createdAt] datetime2 NOT NULL,
        [productId] nvarchar(38) NULL,
        [qty] real NOT NULL,
        [transferOrderId] nvarchar(38) NULL,
        CONSTRAINT [PK_TransferOrderLine] PRIMARY KEY ([transferOrderLineId]),
        CONSTRAINT [FK_TransferOrderLine_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferOrderLine_TransferOrder_transferOrderId] FOREIGN KEY ([transferOrderId]) REFERENCES [TransferOrder] ([transferOrderId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [TransferOut] (
        [transferOutId] nvarchar(38) NOT NULL,
        [HasChild] nvarchar(max) NULL,
        [branchFrombranchId] nvarchar(38) NULL,
        [branchIdFrom] nvarchar(38) NULL,
        [branchIdTo] nvarchar(38) NULL,
        [branchTobranchId] nvarchar(38) NULL,
        [createdAt] datetime2 NOT NULL,
        [description] nvarchar(100) NOT NULL,
        [transferOrderId] nvarchar(38) NOT NULL,
        [transferOutDate] datetime2 NOT NULL,
        [transferOutNumber] nvarchar(20) NOT NULL,
        [warehouseFromwarehouseId] nvarchar(38) NULL,
        [warehouseIdFrom] nvarchar(38) NULL,
        [warehouseIdTo] nvarchar(38) NULL,
        [warehouseTowarehouseId] nvarchar(38) NULL,
        CONSTRAINT [PK_TransferOut] PRIMARY KEY ([transferOutId]),
        CONSTRAINT [FK_TransferOut_Branch_branchFrombranchId] FOREIGN KEY ([branchFrombranchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferOut_Branch_branchTobranchId] FOREIGN KEY ([branchTobranchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferOut_TransferOrder_transferOrderId] FOREIGN KEY ([transferOrderId]) REFERENCES [TransferOrder] ([transferOrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_TransferOut_Warehouse_warehouseFromwarehouseId] FOREIGN KEY ([warehouseFromwarehouseId]) REFERENCES [Warehouse] ([warehouseId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferOut_Warehouse_warehouseTowarehouseId] FOREIGN KEY ([warehouseTowarehouseId]) REFERENCES [Warehouse] ([warehouseId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [ShipmentLine] (
        [shipmentLineId] nvarchar(38) NOT NULL,
        [branchId] nvarchar(38) NULL,
        [createdAt] datetime2 NOT NULL,
        [productId] nvarchar(38) NULL,
        [qty] real NOT NULL,
        [qtyInventory] real NOT NULL,
        [qtyShipment] real NOT NULL,
        [shipmentId] nvarchar(38) NULL,
        [warehouseId] nvarchar(38) NULL,
        CONSTRAINT [PK_ShipmentLine] PRIMARY KEY ([shipmentLineId]),
        CONSTRAINT [FK_ShipmentLine_Branch_branchId] FOREIGN KEY ([branchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ShipmentLine_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ShipmentLine_Shipment_shipmentId] FOREIGN KEY ([shipmentId]) REFERENCES [Shipment] ([shipmentId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ShipmentLine_Warehouse_warehouseId] FOREIGN KEY ([warehouseId]) REFERENCES [Warehouse] ([warehouseId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [ReceivingLine] (
        [receivingLineId] nvarchar(38) NOT NULL,
        [branchId] nvarchar(38) NULL,
        [createdAt] datetime2 NOT NULL,
        [productId] nvarchar(38) NULL,
        [qty] real NOT NULL,
        [qtyInventory] real NOT NULL,
        [qtyReceive] real NOT NULL,
        [receivingId] nvarchar(38) NULL,
        [warehouseId] nvarchar(38) NULL,
        CONSTRAINT [PK_ReceivingLine] PRIMARY KEY ([receivingLineId]),
        CONSTRAINT [FK_ReceivingLine_Branch_branchId] FOREIGN KEY ([branchId]) REFERENCES [Branch] ([branchId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ReceivingLine_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ReceivingLine_Receiving_receivingId] FOREIGN KEY ([receivingId]) REFERENCES [Receiving] ([receivingId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ReceivingLine_Warehouse_warehouseId] FOREIGN KEY ([warehouseId]) REFERENCES [Warehouse] ([warehouseId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [TransferInLine] (
        [transferInLineId] nvarchar(38) NOT NULL,
        [createdAt] datetime2 NOT NULL,
        [productId] nvarchar(38) NULL,
        [qty] real NOT NULL,
        [qtyInventory] real NOT NULL,
        [transferInId] nvarchar(38) NULL,
        CONSTRAINT [PK_TransferInLine] PRIMARY KEY ([transferInLineId]),
        CONSTRAINT [FK_TransferInLine_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferInLine_TransferIn_transferInId] FOREIGN KEY ([transferInId]) REFERENCES [TransferIn] ([transferInId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE TABLE [TransferOutLine] (
        [transferOutLineId] nvarchar(38) NOT NULL,
        [createdAt] datetime2 NOT NULL,
        [productId] nvarchar(38) NULL,
        [qty] real NOT NULL,
        [qtyInventory] real NOT NULL,
        [transferOutId] nvarchar(38) NULL,
        CONSTRAINT [PK_TransferOutLine] PRIMARY KEY ([transferOutLineId]),
        CONSTRAINT [FK_TransferOutLine_Product_productId] FOREIGN KEY ([productId]) REFERENCES [Product] ([productId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TransferOutLine_TransferOut_transferOutId] FOREIGN KEY ([transferOutId]) REFERENCES [TransferOut] ([transferOutId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_CustomerLine_customerId] ON [CustomerLine] ([customerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_PurchaseOrder_vendorId] ON [PurchaseOrder] ([vendorId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_PurchaseOrderLine_productId] ON [PurchaseOrderLine] ([productId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_PurchaseOrderLine_purchaseOrderId] ON [PurchaseOrderLine] ([purchaseOrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_Receiving_branchId] ON [Receiving] ([branchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_Receiving_purchaseOrderId] ON [Receiving] ([purchaseOrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_Receiving_vendorId] ON [Receiving] ([vendorId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_Receiving_warehouseId] ON [Receiving] ([warehouseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_ReceivingLine_branchId] ON [ReceivingLine] ([branchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_ReceivingLine_productId] ON [ReceivingLine] ([productId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_ReceivingLine_receivingId] ON [ReceivingLine] ([receivingId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_ReceivingLine_warehouseId] ON [ReceivingLine] ([warehouseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_SalesOrder_customerId] ON [SalesOrder] ([customerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_SalesOrderLine_productId] ON [SalesOrderLine] ([productId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_SalesOrderLine_salesOrderId] ON [SalesOrderLine] ([salesOrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_Shipment_branchId] ON [Shipment] ([branchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_Shipment_customerId] ON [Shipment] ([customerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_Shipment_salesOrderId] ON [Shipment] ([salesOrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_Shipment_warehouseId] ON [Shipment] ([warehouseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_ShipmentLine_branchId] ON [ShipmentLine] ([branchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_ShipmentLine_productId] ON [ShipmentLine] ([productId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_ShipmentLine_shipmentId] ON [ShipmentLine] ([shipmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_ShipmentLine_warehouseId] ON [ShipmentLine] ([warehouseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferIn_branchFrombranchId] ON [TransferIn] ([branchFrombranchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferIn_branchTobranchId] ON [TransferIn] ([branchTobranchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferIn_transferOrderId] ON [TransferIn] ([transferOrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferIn_warehouseFromwarehouseId] ON [TransferIn] ([warehouseFromwarehouseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferIn_warehouseTowarehouseId] ON [TransferIn] ([warehouseTowarehouseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferInLine_productId] ON [TransferInLine] ([productId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferInLine_transferInId] ON [TransferInLine] ([transferInId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOrder_branchFrombranchId] ON [TransferOrder] ([branchFrombranchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOrder_branchTobranchId] ON [TransferOrder] ([branchTobranchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOrder_warehouseFromwarehouseId] ON [TransferOrder] ([warehouseFromwarehouseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOrder_warehouseTowarehouseId] ON [TransferOrder] ([warehouseTowarehouseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOrderLine_productId] ON [TransferOrderLine] ([productId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOrderLine_transferOrderId] ON [TransferOrderLine] ([transferOrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOut_branchFrombranchId] ON [TransferOut] ([branchFrombranchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOut_branchTobranchId] ON [TransferOut] ([branchTobranchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOut_transferOrderId] ON [TransferOut] ([transferOrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOut_warehouseFromwarehouseId] ON [TransferOut] ([warehouseFromwarehouseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOut_warehouseTowarehouseId] ON [TransferOut] ([warehouseTowarehouseId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOutLine_productId] ON [TransferOutLine] ([productId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_TransferOutLine_transferOutId] ON [TransferOutLine] ([transferOutId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_VendorLine_vendorId] ON [VendorLine] ([vendorId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    CREATE INDEX [IX_Warehouse_branchId] ON [Warehouse] ([branchId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180516150306_initialdb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180516150306_initialdb', N'2.0.2-rtm-10011');
END;

GO

