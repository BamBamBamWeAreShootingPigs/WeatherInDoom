using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Work : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Buyer_id = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Patronymic = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Passport = table.Column<int>(type: "int", nullable: false),
                    Home_address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone_number = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Покупатели", x => x.Buyer_id);
                });

            migrationBuilder.CreateTable(
                name: "Product_categories",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    Parent_categoty_id = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Категории", x => x.Category_Id);
                    table.ForeignKey(
                        name: "FK_Product_categories_Product_categories",
                        column: x => x.Parent_categoty_id,
                        principalTable: "Product_categories",
                        principalColumn: "Category_Id");
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Seller_id = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Patronymic = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Job_title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Home_address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone_number = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Продавцы", x => x.Seller_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Quanity_in_stock = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Товар", x => x.Product_id);
                    table.ForeignKey(
                        name: "FK_Категории_Товар",
                        column: x => x.Category_Id,
                        principalTable: "Product_categories",
                        principalColumn: "Category_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buys",
                columns: table => new
                {
                    Purchase_id = table.Column<int>(type: "int", nullable: false),
                    Purchase_date = table.Column<DateTime>(type: "date", nullable: false),
                    Buyer_id = table.Column<int>(type: "int", nullable: false),
                    Seller_id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('InProcess')"),
                    Delivery_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Покупки", x => x.Purchase_id);
                    table.ForeignKey(
                        name: "FK_Покупки_Покупатель",
                        column: x => x.Buyer_id,
                        principalTable: "Buyers",
                        principalColumn: "Buyer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Покупки_Продавец",
                        column: x => x.Seller_id,
                        principalTable: "Sellers",
                        principalColumn: "Seller_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_content",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false),
                    Purchase_id = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Содержание", x => new { x.Product_id, x.Purchase_id });
                    table.ForeignKey(
                        name: "FK_Содержание_Товар",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Содержимое_Покупки",
                        column: x => x.Purchase_id,
                        principalTable: "Buys",
                        principalColumn: "Purchase_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buys_Buyer_id",
                table: "Buys",
                column: "Buyer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Buys_Seller_id",
                table: "Buys",
                column: "Seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_categories_Parent_categoty_id",
                table: "Product_categories",
                column: "Parent_categoty_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_Id",
                table: "Products",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_content_Purchase_id",
                table: "Purchase_content",
                column: "Purchase_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase_content");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Buys");

            migrationBuilder.DropTable(
                name: "Product_categories");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
