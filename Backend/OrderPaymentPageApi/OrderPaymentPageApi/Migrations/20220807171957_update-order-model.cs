using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderPaymentPageApi.Migrations
{
    public partial class updateordermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 7, 19, 19, 57, 733, DateTimeKind.Local).AddTicks(9591),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 23, 52, 23, 807, DateTimeKind.Local).AddTicks(6531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 7, 19, 19, 57, 733, DateTimeKind.Local).AddTicks(5887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 6, 23, 52, 23, 807, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.AddColumn<double>(
                name: "PaidAmount",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 23, 52, 23, 807, DateTimeKind.Local).AddTicks(6531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 7, 19, 19, 57, 733, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 6, 23, 52, 23, 807, DateTimeKind.Local).AddTicks(4522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 7, 19, 19, 57, 733, DateTimeKind.Local).AddTicks(5887));
        }
    }
}
