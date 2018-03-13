using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PVT.Money.Data.Migrations
{
    public partial class changeWall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "USD_Value",
                table: "UserUSDWallets",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "UserUSDWallets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WalletName",
                table: "UserUSDWallets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "UserUSDWallets");

            migrationBuilder.DropColumn(
                name: "WalletName",
                table: "UserUSDWallets");

            migrationBuilder.AlterColumn<string>(
                name: "USD_Value",
                table: "UserUSDWallets",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
