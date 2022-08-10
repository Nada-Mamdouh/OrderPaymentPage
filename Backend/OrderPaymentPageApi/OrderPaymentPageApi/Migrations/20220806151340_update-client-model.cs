using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderPaymentPageApi.Migrations
{
    public partial class updateclientmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 17, 13, 40, 10, DateTimeKind.Local).AddTicks(6611),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 23, 18, 26, 722, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 17, 13, 40, 10, DateTimeKind.Local).AddTicks(4085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 5, 23, 18, 26, 721, DateTimeKind.Local).AddTicks(9133));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 23, 18, 26, 722, DateTimeKind.Local).AddTicks(1719),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 17, 13, 40, 10, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 5, 23, 18, 26, 721, DateTimeKind.Local).AddTicks(9133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 17, 13, 40, 10, DateTimeKind.Local).AddTicks(4085));
        }
    }
}
