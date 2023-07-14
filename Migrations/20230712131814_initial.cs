using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_Final.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    productShowName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productID);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    propertyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertySort = table.Column<int>(type: "int", nullable: false),
                    productID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.propertyID);
                    table.ForeignKey(
                        name: "FK_Properties_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyDetails",
                columns: table => new
                {
                    propertyDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyDetailCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyDetailDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDetails", x => x.propertyDetailID);
                    table.ForeignKey(
                        name: "FK_PropertyDetails_Properties_propertyID",
                        column: x => x.propertyID,
                        principalTable: "Properties",
                        principalColumn: "propertyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    productDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productDetailName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    sellPrice = table.Column<double>(type: "float", nullable: false),
                    parentID = table.Column<int>(type: "int", nullable: true),
                    propertyDetailID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.productDetailID);
                    table.ForeignKey(
                        name: "FK_ProductDetails_ProductDetails_parentID",
                        column: x => x.parentID,
                        principalTable: "ProductDetails",
                        principalColumn: "productDetailID");
                    table.ForeignKey(
                        name: "FK_ProductDetails_PropertyDetails_propertyDetailID",
                        column: x => x.propertyDetailID,
                        principalTable: "PropertyDetails",
                        principalColumn: "propertyDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetaiPropertyDetails",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false),
                    productDetailID = table.Column<int>(type: "int", nullable: false),
                    propertyDetailID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetaiPropertyDetails", x => new { x.productID, x.productDetailID, x.propertyDetailID });
                    table.ForeignKey(
                        name: "FK_ProductDetaiPropertyDetails_ProductDetails_productDetailID",
                        column: x => x.productDetailID,
                        principalTable: "ProductDetails",
                        principalColumn: "productDetailID");
                    table.ForeignKey(
                        name: "FK_ProductDetaiPropertyDetails_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "productID");
                    table.ForeignKey(
                        name: "FK_ProductDetaiPropertyDetails_PropertyDetails_propertyDetailID",
                        column: x => x.propertyDetailID,
                        principalTable: "PropertyDetails",
                        principalColumn: "propertyDetailID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_parentID",
                table: "ProductDetails",
                column: "parentID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_propertyDetailID",
                table: "ProductDetails",
                column: "propertyDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetaiPropertyDetails_productDetailID",
                table: "ProductDetaiPropertyDetails",
                column: "productDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetaiPropertyDetails_propertyDetailID",
                table: "ProductDetaiPropertyDetails",
                column: "propertyDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_productID",
                table: "Properties",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_propertyID",
                table: "PropertyDetails",
                column: "propertyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetaiPropertyDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "PropertyDetails");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
