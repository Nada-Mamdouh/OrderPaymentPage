using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderPaymentPageApi.Migrations
{
    public partial class updateclientmodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 23, 52, 23, 807, DateTimeKind.Local).AddTicks(6531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 17, 13, 40, 10, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 23, 52, 23, 807, DateTimeKind.Local).AddTicks(4522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 17, 13, 40, 10, DateTimeKind.Local).AddTicks(4085));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 17, 13, 40, 10, DateTimeKind.Local).AddTicks(6611),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 23, 52, 23, 807, DateTimeKind.Local).AddTicks(6531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 17, 13, 40, 10, DateTimeKind.Local).AddTicks(4085),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 23, 52, 23, 807, DateTimeKind.Local).AddTicks(4522));
        }
    }
}
