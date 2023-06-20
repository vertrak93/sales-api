using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesDAL.Migrations
{
    /// <inheritdoc />
    public partial class newchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_UserId",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "UserdId",
                table: "RefreshToken");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RefreshToken",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 22, 15, 59, 585, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 22, 15, 59, 585, DateTimeKind.Local).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRolId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 22, 15, 59, 585, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_UserId",
                table: "RefreshToken");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RefreshToken",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserdId",
                table: "RefreshToken",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 22, 3, 11, 786, DateTimeKind.Local).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 22, 3, 11, 786, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRolId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 22, 3, 11, 786, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
