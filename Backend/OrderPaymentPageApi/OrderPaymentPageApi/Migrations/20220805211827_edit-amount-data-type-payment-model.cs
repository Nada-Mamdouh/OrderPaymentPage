using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderPaymentPageApi.Migrations
{
    public partial class editamountdatatypepaymentmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 23, 18, 26, 722, DateTimeKind.Local).AddTicks(1719),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 23, 6, 8, 320, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.AlterColumn<double>(
                name: "AmountPaid",
                table: "Payments",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 23, 18, 26, 721, DateTimeKind.Local).AddTicks(9133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 23, 6, 8, 320, DateTimeKind.Local).AddTicks(719));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 23, 6, 8, 320, DateTimeKind.Local).AddTicks(2395),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 23, 18, 26, 722, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.AlterColumn<int>(
                name: "AmountPaid",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 23, 6, 8, 320, DateTimeKind.Local).AddTicks(719),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 23, 18, 26, 721, DateTimeKind.Local).AddTicks(9133));
        }
    }
}
