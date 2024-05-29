using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC_DBContext.Migrations
{
    public partial class Roles_Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36175e83-845e-4ff0-979e-48e8e22155b1",
                column: "ConcurrencyStamp",
                value: "05ff8920-7311-4931-972a-fa0d5fc6ff46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "829d3673-9429-44b9-9892-fef3122514c7",
                column: "ConcurrencyStamp",
                value: "96affbe5-a3b4-4d83-8c67-a556de3d43e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1fbf13-dd3c-46df-8e6a-6665022f8783",
                column: "ConcurrencyStamp",
                value: "c0769734-e4cc-4880-9554-54e5083c58df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa8a879-cf25-4bd8-81d8-847ee6497e69",
                column: "ConcurrencyStamp",
                value: "ea8b144a-e617-40e9-ae74-5653a9ff42c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c970652-13b2-428a-80a0-406d2fc46ce4",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6fb592e2-ec6a-4e3e-80ae-0c2f1e71dac0", "Paver (H.O)", "PAVER (H.O)" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2af5924-bc31-4efd-9319-0e418c0cfd8b",
                column: "ConcurrencyStamp",
                value: "46ccc7c4-e5ad-4f3d-afa2-3c85c76e62f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdcbd510-ed11-45d3-82dc-3e6feb6dbab9",
                column: "ConcurrencyStamp",
                value: "01ba7f38-e743-493d-9091-789294384367");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1353c0e1-dca1-44cb-b188-44e1816bb905", "Admin", "ADMIN" });

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
    }
}
