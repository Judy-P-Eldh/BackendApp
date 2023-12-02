using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeletedProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_Account_id1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_Account_id1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Account_id1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Account_id1",
                table: "Transactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Accounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Account_id1",
                table: "Transactions",
                column: "Account_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_Account_id1",
                table: "Transactions",
                column: "Account_id1",
                principalTable: "Accounts",
                principalColumn: "Account_id");
        }
    }
}
