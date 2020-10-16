using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpNorthwindTraders.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NWProducts",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 40, nullable: false),
                    SupplierID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true),
                    QuantityPerUnit = table.Column<string>(maxLength: 40, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
                    UnitsInStock = table.Column<short>(nullable: true, defaultValueSql: "((0))"),
                    UnitsOnOrder = table.Column<short>(nullable: true, defaultValueSql: "((0))"),
                    ReorderLevel = table.Column<short>(nullable: true, defaultValueSql: "((0))"),
                    Discontinued = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWProducts", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_NWProducts_NWCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "NWCategories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NWProducts_NWSuppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "NWSuppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NWProducts_CategoryID",
                table: "NWProducts",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_NWProducts_SupplierID",
                table: "NWProducts",
                column: "SupplierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NWProducts");
        }
    }
}
