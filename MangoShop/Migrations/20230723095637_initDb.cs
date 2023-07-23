using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MangoShop.Services.CouponApi.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    Code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, comment: "优惠券代码"),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false, comment: "优惠金额"),
                    MinAmount = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "CreationTime", "DiscountAmount", "MinAmount", "UpdateTime" },
                values: new object[,]
                {
                    { "72c301623f494aee956fdb404f256fcf", "AB4FE", new DateTime(2023, 7, 23, 17, 56, 37, 919, DateTimeKind.Local).AddTicks(753), 10.0, 100, null },
                    { "f0a142abc3df41b3928e7139d3dfedb6", "Fk778", new DateTime(2023, 7, 23, 17, 56, 37, 919, DateTimeKind.Local).AddTicks(765), 6.5999999999999996, 88, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
