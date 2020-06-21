using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcPhone.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    idLSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenloai = table.Column<string>(nullable: true),
                    maloai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.idLSP);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    idUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tendangnhap = table.Column<string>(nullable: false),
                    matkhau = table.Column<string>(maxLength: 100, nullable: false),
                    matkhaunhaplai = table.Column<string>(nullable: false),
                    hoten = table.Column<string>(nullable: false),
                    gmail = table.Column<string>(nullable: false),
                    sdt = table.Column<string>(maxLength: 10, nullable: false),
                    diachi = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    idSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLSP = table.Column<int>(nullable: false),
                    tenSP = table.Column<string>(nullable: true),
                    mota = table.Column<string>(nullable: true),
                    gia = table.Column<float>(nullable: false),
                    hinhanh = table.Column<string>(nullable: true),
                    CategorysidLSP = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.idSP);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategorysidLSP",
                        column: x => x.CategorysidLSP,
                        principalTable: "Categorys",
                        principalColumn: "idLSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    idHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(nullable: false),
                    hoten_user = table.Column<string>(nullable: true),
                    gmail_user = table.Column<string>(nullable: true),
                    phone_user = table.Column<string>(nullable: true),
                    diachi_user = table.Column<string>(nullable: true),
                    tongtien = table.Column<float>(nullable: false),
                    payment = table.Column<string>(nullable: true),
                    ngaytao = table.Column<DateTime>(nullable: false),
                    trangthai = table.Column<int>(nullable: false),
                    CustomersidUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.idHD);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomersidUser",
                        column: x => x.CustomersidUser,
                        principalTable: "Customers",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    idCTHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idHD = table.Column<int>(nullable: false),
                    idSP = table.Column<int>(nullable: false),
                    soluong = table.Column<int>(nullable: false),
                    dongia = table.Column<float>(nullable: false),
                    thanhtien = table.Column<float>(nullable: false),
                    khuyenmai = table.Column<float>(nullable: false),
                    OrdersidHD = table.Column<int>(nullable: true),
                    ProductsidSP = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.idCTHD);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrdersidHD",
                        column: x => x.OrdersidHD,
                        principalTable: "Orders",
                        principalColumn: "idHD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductsidSP",
                        column: x => x.ProductsidSP,
                        principalTable: "Products",
                        principalColumn: "idSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    STT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idNV = table.Column<string>(nullable: true),
                    hoten = table.Column<string>(nullable: true),
                    sdt = table.Column<string>(nullable: true),
                    diachi = table.Column<string>(nullable: true),
                    ngaysinh = table.Column<DateTime>(nullable: false),
                    gioitinh = table.Column<string>(nullable: true),
                    luong = table.Column<int>(nullable: false),
                    pass = table.Column<string>(nullable: true),
                    trangthai = table.Column<string>(nullable: true),
                    phanquyen = table.Column<string>(nullable: true),
                    CategorysidLSP = table.Column<int>(nullable: true),
                    ProductsidSP = table.Column<int>(nullable: true),
                    OrdersidHD = table.Column<int>(nullable: true),
                    OrderDetailsidCTHD = table.Column<int>(nullable: true),
                    CustomersidUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.STT);
                    table.ForeignKey(
                        name: "FK_Workers_Categorys_CategorysidLSP",
                        column: x => x.CategorysidLSP,
                        principalTable: "Categorys",
                        principalColumn: "idLSP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workers_Customers_CustomersidUser",
                        column: x => x.CustomersidUser,
                        principalTable: "Customers",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workers_OrderDetails_OrderDetailsidCTHD",
                        column: x => x.OrderDetailsidCTHD,
                        principalTable: "OrderDetails",
                        principalColumn: "idCTHD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workers_Orders_OrdersidHD",
                        column: x => x.OrdersidHD,
                        principalTable: "Orders",
                        principalColumn: "idHD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workers_Products_ProductsidSP",
                        column: x => x.ProductsidSP,
                        principalTable: "Products",
                        principalColumn: "idSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrdersidHD",
                table: "OrderDetails",
                column: "OrdersidHD");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductsidSP",
                table: "OrderDetails",
                column: "ProductsidSP");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomersidUser",
                table: "Orders",
                column: "CustomersidUser");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategorysidLSP",
                table: "Products",
                column: "CategorysidLSP");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CategorysidLSP",
                table: "Workers",
                column: "CategorysidLSP");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CustomersidUser",
                table: "Workers",
                column: "CustomersidUser");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_OrderDetailsidCTHD",
                table: "Workers",
                column: "OrderDetailsidCTHD");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_OrdersidHD",
                table: "Workers",
                column: "OrdersidHD");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ProductsidSP",
                table: "Workers",
                column: "ProductsidSP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
