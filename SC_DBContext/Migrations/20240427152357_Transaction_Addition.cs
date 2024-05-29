using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC_DBContext.Migrations
{
    public partial class Transaction_Addition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Particular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieptNo = table.Column<long>(type: "bigint", nullable: false),
                    Reciept = table.Column<double>(type: "float", nullable: true),
                    Payment = table.Column<double>(type: "float", nullable: true),
                    Balance = table.Column<double>(type: "float", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36175e83-845e-4ff0-979e-48e8e22155b1",
                column: "ConcurrencyStamp",
                value: "2e5a900d-5cbb-44ed-9640-e4814e786e18");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "829d3673-9429-44b9-9892-fef3122514c7",
                column: "ConcurrencyStamp",
                value: "5dd669a7-0972-4164-9110-ddf0dedbaab5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1fbf13-dd3c-46df-8e6a-6665022f8783",
                column: "ConcurrencyStamp",
                value: "4d1c3a18-79ab-4484-89f2-963f36cca13f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa8a879-cf25-4bd8-81d8-847ee6497e69",
                column: "ConcurrencyStamp",
                value: "53588b30-4b06-4c25-ad05-bdd9551f0180");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c970652-13b2-428a-80a0-406d2fc46ce4",
                column: "ConcurrencyStamp",
                value: "1353c0e1-dca1-44cb-b188-44e1816bb905");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2af5924-bc31-4efd-9319-0e418c0cfd8b",
                column: "ConcurrencyStamp",
                value: "e8588a00-bce8-4b78-8fb8-1491b3473f92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdcbd510-ed11-45d3-82dc-3e6feb6dbab9",
                column: "ConcurrencyStamp",
                value: "fa61a2ed-1239-456d-8c41-effb09f9faaf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36175e83-845e-4ff0-979e-48e8e22155b1",
                column: "ConcurrencyStamp",
                value: "bc12ff76-cadd-46e6-b033-9e6ca7e398d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "829d3673-9429-44b9-9892-fef3122514c7",
                column: "ConcurrencyStamp",
                value: "2f5d8b15-45c6-4c47-aeb7-7ddea66a776e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1fbf13-dd3c-46df-8e6a-6665022f8783",
                column: "ConcurrencyStamp",
                value: "203d6561-c9b0-4d6b-b139-263b51dcc915");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa8a879-cf25-4bd8-81d8-847ee6497e69",
                column: "ConcurrencyStamp",
                value: "8daef0cc-2d5f-4f65-844e-9eca912dded2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c970652-13b2-428a-80a0-406d2fc46ce4",
                column: "ConcurrencyStamp",
                value: "d5bcc55e-73bd-4f9f-ab8f-f7bf7e0e3034");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2af5924-bc31-4efd-9319-0e418c0cfd8b",
                column: "ConcurrencyStamp",
                value: "7c22f03b-5441-4465-83b5-9004c45b1fdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdcbd510-ed11-45d3-82dc-3e6feb6dbab9",
                column: "ConcurrencyStamp",
                value: "d7867a00-09b2-49e1-be23-b47ffd7c9380");
        }
    }
}
