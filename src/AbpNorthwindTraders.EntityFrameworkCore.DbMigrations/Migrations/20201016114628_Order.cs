using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpNorthwindTraders.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NWOrders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CustomerID = table.Column<string>(maxLength: 5, nullable: true),
                    EmployeeID = table.Column<int>(nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipVia = table.Column<int>(nullable: true),
                    Freight = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    ShipName = table.Column<string>(maxLength: 40, nullable: true),
                    ShipAddress = table.Column<string>(maxLength: 60, nullable: true),
                    ShipCity = table.Column<string>(maxLength: 15, nullable: true),
                    ShipRegion = table.Column<string>(maxLength: 15, nullable: true),
                    ShipPostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    ShipCountry = table.Column<string>(maxLength: 15, nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWOrders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_NWOrders_NWCustomers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "NWCustomers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NWOrders_NWEmployees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "NWEmployees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Shippers",
                        column: x => x.ShipVia,
                        principalTable: "NWShippers",
                        principalColumn: "ShipperID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NWOrderDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<short>(nullable: false, defaultValueSql: "((1))"),
                    Discount = table.Column<float>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWOrderDetails", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Order_Details_Orders",
                        column: x => x.OrderID,
                        principalTable: "NWOrders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Details_Products",
                        column: x => x.ProductID,
                        principalTable: "NWProducts",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NWOrderDetails_ProductID",
                table: "NWOrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_NWOrders_CustomerID",
                table: "NWOrders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_NWOrders_EmployeeID",
                table: "NWOrders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_NWOrders_ShipVia",
                table: "NWOrders",
                column: "ShipVia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NWOrderDetails");

            migrationBuilder.DropTable(
                name: "NWOrders");
        }
    }
}
