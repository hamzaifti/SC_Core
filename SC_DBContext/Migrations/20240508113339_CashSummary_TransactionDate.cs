using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC_DBContext.Migrations
{
    public partial class CashSummary_TransactionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "CashSummaries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36175e83-845e-4ff0-979e-48e8e22155b1",
                column: "ConcurrencyStamp",
                value: "14bee90e-fa2b-4502-adcf-31ab3cf196ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "829d3673-9429-44b9-9892-fef3122514c7",
                column: "ConcurrencyStamp",
                value: "f0068c5d-4ab7-4e07-9860-8131118b2f46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "853619ef-752f-48f8-87ca-0af80aa48bbc",
                column: "ConcurrencyStamp",
                value: "af4cdc5d-c319-4a33-a651-821a5746507d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1fbf13-dd3c-46df-8e6a-6665022f8783",
                column: "ConcurrencyStamp",
                value: "97e226cb-0ac4-4ea1-b388-e4bcc032e5f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa8a879-cf25-4bd8-81d8-847ee6497e69",
                column: "ConcurrencyStamp",
                value: "08cb2c1b-c1fa-499c-9c20-ae7ff4059604");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c970652-13b2-428a-80a0-406d2fc46ce4",
                column: "ConcurrencyStamp",
                value: "332e3f4c-abc4-4fef-be17-2aa093197860");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2af5924-bc31-4efd-9319-0e418c0cfd8b",
                column: "ConcurrencyStamp",
                value: "7cd09b86-f8ef-46f8-b4b4-3859cf28fdbb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdcbd510-ed11-45d3-82dc-3e6feb6dbab9",
                column: "ConcurrencyStamp",
                value: "ae3148bc-d210-4520-9062-58ad7a892a82");

            migrationBuilder.UpdateData(
                table: "CashSummaries",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalCash",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "CashSummaries",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalCash",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "CashSummaries",
                keyColumn: "Id",
                keyValue: 3,
                column: "TotalCash",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "CashSummaries",
                keyColumn: "Id",
                keyValue: 4,
                column: "TotalCash",
                value: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "CashSummaries");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36175e83-845e-4ff0-979e-48e8e22155b1",
                column: "ConcurrencyStamp",
                value: "acd8446f-28d5-45a4-8964-53ee0170e1bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "829d3673-9429-44b9-9892-fef3122514c7",
                column: "ConcurrencyStamp",
                value: "8fcc960c-94f2-4113-a848-5ca8e00e2114");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "853619ef-752f-48f8-87ca-0af80aa48bbc",
                column: "ConcurrencyStamp",
                value: "dbe9bb3a-89cf-42e1-8b1e-846aba9bfaba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1fbf13-dd3c-46df-8e6a-6665022f8783",
                column: "ConcurrencyStamp",
                value: "1bf60e7d-4743-4b61-ba86-d42a58dee188");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa8a879-cf25-4bd8-81d8-847ee6497e69",
                column: "ConcurrencyStamp",
                value: "20b71ffd-ea04-4734-a177-6e5b6c5db463");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c970652-13b2-428a-80a0-406d2fc46ce4",
                column: "ConcurrencyStamp",
                value: "edec9e6d-ccd0-4cc0-bae0-e0fb45bdb367");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2af5924-bc31-4efd-9319-0e418c0cfd8b",
                column: "ConcurrencyStamp",
                value: "25c410b0-1760-4d55-aa01-56b497130a7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdcbd510-ed11-45d3-82dc-3e6feb6dbab9",
                column: "ConcurrencyStamp",
                value: "bd0315b0-d500-4083-ac75-20efe5c855c8");

            migrationBuilder.UpdateData(
                table: "CashSummaries",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalCash",
                value: null);

            migrationBuilder.UpdateData(
                table: "CashSummaries",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalCash",
                value: null);

            migrationBuilder.UpdateData(
                table: "CashSummaries",
                keyColumn: "Id",
                keyValue: 3,
                column: "TotalCash",
                value: null);

            migrationBuilder.UpdateData(
                table: "CashSummaries",
                keyColumn: "Id",
                keyValue: 4,
                column: "TotalCash",
                value: null);
        }
    }
}
