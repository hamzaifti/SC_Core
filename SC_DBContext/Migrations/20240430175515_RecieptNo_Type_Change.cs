using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC_DBContext.Migrations
{
    public partial class RecieptNo_Type_Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RecieptNo",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36175e83-845e-4ff0-979e-48e8e22155b1",
                column: "ConcurrencyStamp",
                value: "98404ee2-01fd-4d7a-bbfb-8055d585829e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "829d3673-9429-44b9-9892-fef3122514c7",
                column: "ConcurrencyStamp",
                value: "154f0535-19d7-4b4a-a4bc-9ad09777563e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1fbf13-dd3c-46df-8e6a-6665022f8783",
                column: "ConcurrencyStamp",
                value: "557f6074-9e61-4642-9bc2-a29a21d9a49f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa8a879-cf25-4bd8-81d8-847ee6497e69",
                column: "ConcurrencyStamp",
                value: "e51ec749-9c8d-4da1-8a51-1ee377c0f53c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c970652-13b2-428a-80a0-406d2fc46ce4",
                column: "ConcurrencyStamp",
                value: "79232d49-36a4-4bc3-ae8d-21f6d9d6fa85");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2af5924-bc31-4efd-9319-0e418c0cfd8b",
                column: "ConcurrencyStamp",
                value: "cbe6acaa-4aa5-4f94-a2ec-aabd007b844d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdcbd510-ed11-45d3-82dc-3e6feb6dbab9",
                column: "ConcurrencyStamp",
                value: "b38fff17-7371-4c09-9cf9-cd17f6926cb9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RecieptNo",
                table: "Transactions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36175e83-845e-4ff0-979e-48e8e22155b1",
                column: "ConcurrencyStamp",
                value: "eee15ee0-de8c-499a-93ea-5e55718f9c37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "829d3673-9429-44b9-9892-fef3122514c7",
                column: "ConcurrencyStamp",
                value: "5f01d45d-ec55-405a-849b-d42e9a33e94c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1fbf13-dd3c-46df-8e6a-6665022f8783",
                column: "ConcurrencyStamp",
                value: "57e89290-60af-49a8-830a-9a2071d41d63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa8a879-cf25-4bd8-81d8-847ee6497e69",
                column: "ConcurrencyStamp",
                value: "b0b0b1a5-affd-4c11-98ad-4d5a5567fa7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c970652-13b2-428a-80a0-406d2fc46ce4",
                column: "ConcurrencyStamp",
                value: "d89e6e17-0762-43a0-b423-0e0b443b0be5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2af5924-bc31-4efd-9319-0e418c0cfd8b",
                column: "ConcurrencyStamp",
                value: "db1a8ef8-3a96-4002-9c40-0d0e240661dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdcbd510-ed11-45d3-82dc-3e6feb6dbab9",
                column: "ConcurrencyStamp",
                value: "dc04015d-21c6-494e-9970-8e65324b6213");
        }
    }
}
