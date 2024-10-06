using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThucTap1.Migrations
{
    /// <inheritdoc />
    public partial class ThucTap2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeTai",
                columns: table => new
                {
                    MaDT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KinhPhi = table.Column<int>(type: "int", nullable: false),
                    NoiThucTap = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeTai", x => x.MaDT);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "GiangVien",
                columns: table => new
                {
                    MaGV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTenGV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Luong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoaMaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangVien", x => x.MaGV);
                    table.ForeignKey(
                        name: "FK_GiangVien_Khoa_KhoaMaKhoa",
                        column: x => x.KhoaMaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTenSV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamSinh = table.Column<int>(type: "int", nullable: true),
                    QueQuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoaMaKhoa = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SinhVien_Khoa_KhoaMaKhoa",
                        column: x => x.KhoaMaKhoa,
                        principalTable: "Khoa",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "HuongDan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSV = table.Column<int>(type: "int", nullable: false),
                    MaGV = table.Column<int>(type: "int", nullable: false),
                    MaDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiangVienMaGV = table.Column<int>(type: "int", nullable: true),
                    SinhVienMaSV = table.Column<int>(type: "int", nullable: true),
                    DeTaiMaDT = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KetQua = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuongDan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HuongDan_DeTai_DeTaiMaDT",
                        column: x => x.DeTaiMaDT,
                        principalTable: "DeTai",
                        principalColumn: "MaDT");
                    table.ForeignKey(
                        name: "FK_HuongDan_GiangVien_GiangVienMaGV",
                        column: x => x.GiangVienMaGV,
                        principalTable: "GiangVien",
                        principalColumn: "MaGV");
                    table.ForeignKey(
                        name: "FK_HuongDan_SinhVien_SinhVienMaSV",
                        column: x => x.SinhVienMaSV,
                        principalTable: "SinhVien",
                        principalColumn: "MaSV");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiangVien_KhoaMaKhoa",
                table: "GiangVien",
                column: "KhoaMaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_HuongDan_DeTaiMaDT",
                table: "HuongDan",
                column: "DeTaiMaDT");

            migrationBuilder.CreateIndex(
                name: "IX_HuongDan_GiangVienMaGV",
                table: "HuongDan",
                column: "GiangVienMaGV");

            migrationBuilder.CreateIndex(
                name: "IX_HuongDan_SinhVienMaSV",
                table: "HuongDan",
                column: "SinhVienMaSV");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_KhoaMaKhoa",
                table: "SinhVien",
                column: "KhoaMaKhoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HuongDan");

            migrationBuilder.DropTable(
                name: "DeTai");

            migrationBuilder.DropTable(
                name: "GiangVien");

            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
