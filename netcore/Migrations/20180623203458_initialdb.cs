using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace netcore.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ApplicationUserRole = table.Column<bool>(nullable: false),
                    BranchRole = table.Column<bool>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CustomerLineRole = table.Column<bool>(nullable: false),
                    CustomerRole = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    HomeRole = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    ProductRole = table.Column<bool>(nullable: false),
                    PurchaseOrderLineRole = table.Column<bool>(nullable: false),
                    PurchaseOrderRole = table.Column<bool>(nullable: false),
                    ReceivingLineRole = table.Column<bool>(nullable: false),
                    ReceivingRole = table.Column<bool>(nullable: false),
                    SalesOrderLineRole = table.Column<bool>(nullable: false),
                    SalesOrderRole = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ShipmentLineRole = table.Column<bool>(nullable: false),
                    ShipmentRole = table.Column<bool>(nullable: false),
                    StockRole = table.Column<bool>(nullable: false),
                    TransferInLineRole = table.Column<bool>(nullable: false),
                    TransferInRole = table.Column<bool>(nullable: false),
                    TransferOrderLineRole = table.Column<bool>(nullable: false),
                    TransferOrderRole = table.Column<bool>(nullable: false),
                    TransferOutLineRole = table.Column<bool>(nullable: false),
                    TransferOutRole = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    VendorLineRole = table.Column<bool>(nullable: false),
                    VendorRole = table.Column<bool>(nullable: false),
                    WarehouseRole = table.Column<bool>(nullable: false),
                    isSuperAdmin = table.Column<bool>(nullable: false),
                    profilePictureUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    branchId = table.Column<string>(maxLength: 38, nullable: false),
                    branchName = table.Column<string>(maxLength: 50, nullable: false),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    country = table.Column<string>(maxLength: 30, nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    isDefaultBranch = table.Column<bool>(nullable: false),
                    province = table.Column<string>(maxLength: 30, nullable: true),
                    street1 = table.Column<string>(maxLength: 50, nullable: false),
                    street2 = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.branchId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<string>(maxLength: 38, nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    country = table.Column<string>(maxLength: 30, nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    customerName = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    province = table.Column<string>(maxLength: 30, nullable: true),
                    size = table.Column<int>(nullable: false),
                    street1 = table.Column<string>(maxLength: 50, nullable: false),
                    street2 = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<string>(maxLength: 38, nullable: false),
                    barcode = table.Column<string>(maxLength: 50, nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    productCode = table.Column<string>(maxLength: 50, nullable: false),
                    productName = table.Column<string>(maxLength: 50, nullable: false),
                    productType = table.Column<int>(nullable: false),
                    serialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    uom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    vendorId = table.Column<string>(maxLength: 38, nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    country = table.Column<string>(maxLength: 30, nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    province = table.Column<string>(maxLength: 30, nullable: true),
                    size = table.Column<int>(nullable: false),
                    street1 = table.Column<string>(maxLength: 50, nullable: false),
                    street2 = table.Column<string>(maxLength: 50, nullable: true),
                    vendorName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.vendorId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    warehouseId = table.Column<string>(maxLength: 38, nullable: false),
                    branchId = table.Column<string>(maxLength: 38, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    country = table.Column<string>(maxLength: 30, nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 50, nullable: true),
                    province = table.Column<string>(maxLength: 30, nullable: true),
                    street1 = table.Column<string>(maxLength: 50, nullable: false),
                    street2 = table.Column<string>(maxLength: 50, nullable: true),
                    warehouseName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.warehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouse_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerLine",
                columns: table => new
                {
                    customerLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    customerId = table.Column<string>(maxLength: 38, nullable: true),
                    fax = table.Column<string>(maxLength: 20, nullable: true),
                    firstName = table.Column<string>(maxLength: 20, nullable: false),
                    gender = table.Column<int>(nullable: false),
                    jobTitle = table.Column<string>(maxLength: 20, nullable: false),
                    lastName = table.Column<string>(maxLength: 20, nullable: false),
                    middleName = table.Column<string>(maxLength: 20, nullable: true),
                    mobilePhone = table.Column<string>(maxLength: 20, nullable: true),
                    nickName = table.Column<string>(maxLength: 20, nullable: true),
                    officePhone = table.Column<string>(maxLength: 20, nullable: true),
                    personalEmail = table.Column<string>(maxLength: 50, nullable: true),
                    salutation = table.Column<int>(nullable: false),
                    workEmail = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLine", x => x.customerLineId);
                    table.ForeignKey(
                        name: "FK_CustomerLine_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    salesOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    customerId = table.Column<string>(maxLength: 38, nullable: false),
                    deliveryAddress = table.Column<string>(maxLength: 50, nullable: true),
                    deliveryDate = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: true),
                    picCustomer = table.Column<string>(maxLength: 30, nullable: false),
                    picInternal = table.Column<string>(maxLength: 30, nullable: false),
                    referenceNumberExternal = table.Column<string>(maxLength: 30, nullable: true),
                    referenceNumberInternal = table.Column<string>(maxLength: 30, nullable: true),
                    salesOrderNumber = table.Column<string>(maxLength: 20, nullable: false),
                    salesOrderStatus = table.Column<int>(nullable: false),
                    salesShipmentNumber = table.Column<string>(nullable: true),
                    soDate = table.Column<DateTime>(nullable: false),
                    top = table.Column<int>(nullable: false),
                    totalDiscountAmount = table.Column<decimal>(nullable: false),
                    totalOrderAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.salesOrderId);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    purchaseOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    deliveryAddress = table.Column<string>(maxLength: 50, nullable: true),
                    deliveryDate = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: true),
                    picInternal = table.Column<string>(maxLength: 30, nullable: false),
                    picVendor = table.Column<string>(maxLength: 30, nullable: false),
                    poDate = table.Column<DateTime>(nullable: false),
                    purchaseOrderNumber = table.Column<string>(maxLength: 20, nullable: false),
                    purchaseOrderStatus = table.Column<int>(nullable: false),
                    purchaseReceiveNumber = table.Column<string>(nullable: true),
                    referenceNumberExternal = table.Column<string>(maxLength: 30, nullable: true),
                    referenceNumberInternal = table.Column<string>(maxLength: 30, nullable: true),
                    top = table.Column<int>(nullable: false),
                    totalDiscountAmount = table.Column<decimal>(nullable: false),
                    totalOrderAmount = table.Column<decimal>(nullable: false),
                    vendorId = table.Column<string>(maxLength: 38, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.purchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Vendor_vendorId",
                        column: x => x.vendorId,
                        principalTable: "Vendor",
                        principalColumn: "vendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorLine",
                columns: table => new
                {
                    vendorLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    fax = table.Column<string>(maxLength: 20, nullable: true),
                    firstName = table.Column<string>(maxLength: 20, nullable: false),
                    gender = table.Column<int>(nullable: false),
                    jobTitle = table.Column<string>(maxLength: 20, nullable: false),
                    lastName = table.Column<string>(maxLength: 20, nullable: false),
                    middleName = table.Column<string>(maxLength: 20, nullable: true),
                    mobilePhone = table.Column<string>(maxLength: 20, nullable: true),
                    nickName = table.Column<string>(maxLength: 20, nullable: true),
                    officePhone = table.Column<string>(maxLength: 20, nullable: true),
                    personalEmail = table.Column<string>(maxLength: 50, nullable: true),
                    salutation = table.Column<int>(nullable: false),
                    vendorId = table.Column<string>(maxLength: 38, nullable: true),
                    workEmail = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorLine", x => x.vendorLineId);
                    table.ForeignKey(
                        name: "FK_VendorLine_Vendor_vendorId",
                        column: x => x.vendorId,
                        principalTable: "Vendor",
                        principalColumn: "vendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferOrder",
                columns: table => new
                {
                    transferOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    branchFrombranchId = table.Column<string>(nullable: true),
                    branchIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    branchIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    branchTobranchId = table.Column<string>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    isIssued = table.Column<bool>(nullable: false),
                    isReceived = table.Column<bool>(nullable: false),
                    picName = table.Column<string>(maxLength: 50, nullable: false),
                    transferOrderDate = table.Column<DateTime>(nullable: false),
                    transferOrderNumber = table.Column<string>(maxLength: 20, nullable: false),
                    transferOrderStatus = table.Column<int>(nullable: false),
                    warehouseFromwarehouseId = table.Column<string>(nullable: true),
                    warehouseIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseTowarehouseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOrder", x => x.transferOrderId);
                    table.ForeignKey(
                        name: "FK_TransferOrder_Branch_branchFrombranchId",
                        column: x => x.branchFrombranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOrder_Branch_branchTobranchId",
                        column: x => x.branchTobranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOrder_Warehouse_warehouseFromwarehouseId",
                        column: x => x.warehouseFromwarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOrder_Warehouse_warehouseTowarehouseId",
                        column: x => x.warehouseTowarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderLine",
                columns: table => new
                {
                    salesOrderLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    discountAmount = table.Column<decimal>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    salesOrderId = table.Column<string>(maxLength: 38, nullable: true),
                    totalAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderLine", x => x.salesOrderLineId);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderLine_SalesOrder_salesOrderId",
                        column: x => x.salesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "salesOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    shipmentId = table.Column<string>(maxLength: 38, nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    customerId = table.Column<string>(maxLength: 38, nullable: true),
                    customerPO = table.Column<string>(maxLength: 50, nullable: true),
                    expeditionMode = table.Column<int>(nullable: false),
                    expeditionType = table.Column<int>(nullable: false),
                    invoice = table.Column<string>(maxLength: 50, nullable: true),
                    salesOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    shipmentDate = table.Column<DateTime>(nullable: false),
                    shipmentNumber = table.Column<string>(maxLength: 20, nullable: false),
                    warehouseId = table.Column<string>(maxLength: 38, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.shipmentId);
                    table.ForeignKey(
                        name: "FK_Shipment_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipment_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipment_SalesOrder_salesOrderId",
                        column: x => x.salesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "salesOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipment_Warehouse_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderLine",
                columns: table => new
                {
                    purchaseOrderLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    discountAmount = table.Column<decimal>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    purchaseOrderId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    totalAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderLine", x => x.purchaseOrderLineId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderLine_PurchaseOrder_purchaseOrderId",
                        column: x => x.purchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "purchaseOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receiving",
                columns: table => new
                {
                    receivingId = table.Column<string>(maxLength: 38, nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    branchId = table.Column<string>(maxLength: 38, nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    purchaseOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    receivingDate = table.Column<DateTime>(nullable: false),
                    receivingNumber = table.Column<string>(maxLength: 20, nullable: false),
                    vendorDO = table.Column<string>(maxLength: 50, nullable: false),
                    vendorId = table.Column<string>(maxLength: 38, nullable: true),
                    vendorInvoice = table.Column<string>(maxLength: 50, nullable: true),
                    warehouseId = table.Column<string>(maxLength: 38, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receiving", x => x.receivingId);
                    table.ForeignKey(
                        name: "FK_Receiving_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiving_PurchaseOrder_purchaseOrderId",
                        column: x => x.purchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "purchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receiving_Vendor_vendorId",
                        column: x => x.vendorId,
                        principalTable: "Vendor",
                        principalColumn: "vendorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receiving_Warehouse_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferIn",
                columns: table => new
                {
                    transferInId = table.Column<string>(maxLength: 38, nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    branchFrombranchId = table.Column<string>(nullable: true),
                    branchIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    branchIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    branchTobranchId = table.Column<string>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    transferInDate = table.Column<DateTime>(nullable: false),
                    transferInNumber = table.Column<string>(maxLength: 20, nullable: false),
                    transferOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    warehouseFromwarehouseId = table.Column<string>(nullable: true),
                    warehouseIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseTowarehouseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferIn", x => x.transferInId);
                    table.ForeignKey(
                        name: "FK_TransferIn_Branch_branchFrombranchId",
                        column: x => x.branchFrombranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferIn_Branch_branchTobranchId",
                        column: x => x.branchTobranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferIn_TransferOrder_transferOrderId",
                        column: x => x.transferOrderId,
                        principalTable: "TransferOrder",
                        principalColumn: "transferOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferIn_Warehouse_warehouseFromwarehouseId",
                        column: x => x.warehouseFromwarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferIn_Warehouse_warehouseTowarehouseId",
                        column: x => x.warehouseTowarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferOrderLine",
                columns: table => new
                {
                    transferOrderLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    transferOrderId = table.Column<string>(maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOrderLine", x => x.transferOrderLineId);
                    table.ForeignKey(
                        name: "FK_TransferOrderLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOrderLine_TransferOrder_transferOrderId",
                        column: x => x.transferOrderId,
                        principalTable: "TransferOrder",
                        principalColumn: "transferOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferOut",
                columns: table => new
                {
                    transferOutId = table.Column<string>(maxLength: 38, nullable: false),
                    HasChild = table.Column<string>(nullable: true),
                    branchFrombranchId = table.Column<string>(nullable: true),
                    branchIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    branchIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    branchTobranchId = table.Column<string>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    transferOrderId = table.Column<string>(maxLength: 38, nullable: false),
                    transferOutDate = table.Column<DateTime>(nullable: false),
                    transferOutNumber = table.Column<string>(maxLength: 20, nullable: false),
                    warehouseFromwarehouseId = table.Column<string>(nullable: true),
                    warehouseIdFrom = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseIdTo = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseTowarehouseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOut", x => x.transferOutId);
                    table.ForeignKey(
                        name: "FK_TransferOut_Branch_branchFrombranchId",
                        column: x => x.branchFrombranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOut_Branch_branchTobranchId",
                        column: x => x.branchTobranchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOut_TransferOrder_transferOrderId",
                        column: x => x.transferOrderId,
                        principalTable: "TransferOrder",
                        principalColumn: "transferOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferOut_Warehouse_warehouseFromwarehouseId",
                        column: x => x.warehouseFromwarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOut_Warehouse_warehouseTowarehouseId",
                        column: x => x.warehouseTowarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentLine",
                columns: table => new
                {
                    shipmentLineId = table.Column<string>(maxLength: 38, nullable: false),
                    branchId = table.Column<string>(maxLength: 38, nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    qtyInventory = table.Column<float>(nullable: false),
                    qtyShipment = table.Column<float>(nullable: false),
                    shipmentId = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseId = table.Column<string>(maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentLine", x => x.shipmentLineId);
                    table.ForeignKey(
                        name: "FK_ShipmentLine_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentLine_Shipment_shipmentId",
                        column: x => x.shipmentId,
                        principalTable: "Shipment",
                        principalColumn: "shipmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentLine_Warehouse_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingLine",
                columns: table => new
                {
                    receivingLineId = table.Column<string>(maxLength: 38, nullable: false),
                    branchId = table.Column<string>(maxLength: 38, nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    qtyInventory = table.Column<float>(nullable: false),
                    qtyReceive = table.Column<float>(nullable: false),
                    receivingId = table.Column<string>(maxLength: 38, nullable: true),
                    warehouseId = table.Column<string>(maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingLine", x => x.receivingLineId);
                    table.ForeignKey(
                        name: "FK_ReceivingLine_Branch_branchId",
                        column: x => x.branchId,
                        principalTable: "Branch",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingLine_Receiving_receivingId",
                        column: x => x.receivingId,
                        principalTable: "Receiving",
                        principalColumn: "receivingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivingLine_Warehouse_warehouseId",
                        column: x => x.warehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "warehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferInLine",
                columns: table => new
                {
                    transferInLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    qtyInventory = table.Column<float>(nullable: false),
                    transferInId = table.Column<string>(maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferInLine", x => x.transferInLineId);
                    table.ForeignKey(
                        name: "FK_TransferInLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferInLine_TransferIn_transferInId",
                        column: x => x.transferInId,
                        principalTable: "TransferIn",
                        principalColumn: "transferInId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferOutLine",
                columns: table => new
                {
                    transferOutLineId = table.Column<string>(maxLength: 38, nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    productId = table.Column<string>(maxLength: 38, nullable: true),
                    qty = table.Column<float>(nullable: false),
                    qtyInventory = table.Column<float>(nullable: false),
                    transferOutId = table.Column<string>(maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOutLine", x => x.transferOutLineId);
                    table.ForeignKey(
                        name: "FK_TransferOutLine_Product_productId",
                        column: x => x.productId,
                        principalTable: "Product",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferOutLine_TransferOut_transferOutId",
                        column: x => x.transferOutId,
                        principalTable: "TransferOut",
                        principalColumn: "transferOutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLine_customerId",
                table: "CustomerLine",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_branchId",
                table: "PurchaseOrder",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_vendorId",
                table: "PurchaseOrder",
                column: "vendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLine_productId",
                table: "PurchaseOrderLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderLine_purchaseOrderId",
                table: "PurchaseOrderLine",
                column: "purchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_branchId",
                table: "Receiving",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_purchaseOrderId",
                table: "Receiving",
                column: "purchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_vendorId",
                table: "Receiving",
                column: "vendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_warehouseId",
                table: "Receiving",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingLine_branchId",
                table: "ReceivingLine",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingLine_productId",
                table: "ReceivingLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingLine_receivingId",
                table: "ReceivingLine",
                column: "receivingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingLine_warehouseId",
                table: "ReceivingLine",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_branchId",
                table: "SalesOrder",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_customerId",
                table: "SalesOrder",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_productId",
                table: "SalesOrderLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderLine_salesOrderId",
                table: "SalesOrderLine",
                column: "salesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_branchId",
                table: "Shipment",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_customerId",
                table: "Shipment",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_salesOrderId",
                table: "Shipment",
                column: "salesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_warehouseId",
                table: "Shipment",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLine_branchId",
                table: "ShipmentLine",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLine_productId",
                table: "ShipmentLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLine_shipmentId",
                table: "ShipmentLine",
                column: "shipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLine_warehouseId",
                table: "ShipmentLine",
                column: "warehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferIn_branchFrombranchId",
                table: "TransferIn",
                column: "branchFrombranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferIn_branchTobranchId",
                table: "TransferIn",
                column: "branchTobranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferIn_transferOrderId",
                table: "TransferIn",
                column: "transferOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferIn_warehouseFromwarehouseId",
                table: "TransferIn",
                column: "warehouseFromwarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferIn_warehouseTowarehouseId",
                table: "TransferIn",
                column: "warehouseTowarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferInLine_productId",
                table: "TransferInLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferInLine_transferInId",
                table: "TransferInLine",
                column: "transferInId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrder_branchFrombranchId",
                table: "TransferOrder",
                column: "branchFrombranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrder_branchTobranchId",
                table: "TransferOrder",
                column: "branchTobranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrder_warehouseFromwarehouseId",
                table: "TransferOrder",
                column: "warehouseFromwarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrder_warehouseTowarehouseId",
                table: "TransferOrder",
                column: "warehouseTowarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrderLine_productId",
                table: "TransferOrderLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrderLine_transferOrderId",
                table: "TransferOrderLine",
                column: "transferOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOut_branchFrombranchId",
                table: "TransferOut",
                column: "branchFrombranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOut_branchTobranchId",
                table: "TransferOut",
                column: "branchTobranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOut_transferOrderId",
                table: "TransferOut",
                column: "transferOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOut_warehouseFromwarehouseId",
                table: "TransferOut",
                column: "warehouseFromwarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOut_warehouseTowarehouseId",
                table: "TransferOut",
                column: "warehouseTowarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOutLine_productId",
                table: "TransferOutLine",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOutLine_transferOutId",
                table: "TransferOutLine",
                column: "transferOutId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorLine_vendorId",
                table: "VendorLine",
                column: "vendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_branchId",
                table: "Warehouse",
                column: "branchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerLine");

            migrationBuilder.DropTable(
                name: "PurchaseOrderLine");

            migrationBuilder.DropTable(
                name: "ReceivingLine");

            migrationBuilder.DropTable(
                name: "SalesOrderLine");

            migrationBuilder.DropTable(
                name: "ShipmentLine");

            migrationBuilder.DropTable(
                name: "TransferInLine");

            migrationBuilder.DropTable(
                name: "TransferOrderLine");

            migrationBuilder.DropTable(
                name: "TransferOutLine");

            migrationBuilder.DropTable(
                name: "VendorLine");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Receiving");

            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropTable(
                name: "TransferIn");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "TransferOut");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "TransferOrder");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
