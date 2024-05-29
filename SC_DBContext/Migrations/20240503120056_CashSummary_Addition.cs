using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC_DBContext.Migrations
{
    public partial class CashSummary_Addition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecastCash = table.Column<double>(type: "float", nullable: true),
                    PaverCladCash = table.Column<double>(type: "float", nullable: true),
                    TotalCash = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashSummaries", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "CashSummaries",
                columns: new[] { "Id", "Narration", "PaverCladCash", "PrecastCash", "TotalCash" },
                values: new object[,]
                {
                    { 1, "H.O", 0.0, 0.0, null },
                    { 2, "Factory", 0.0, 0.0, null },
                    { 3, "FSD Shop", 0.0, 0.0, null },
                    { 4, "SGD Shop", 0.0, 0.0, null },
                    { 5, "Bank Balance", null, null, 0.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashSummaries");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36175e83-845e-4ff0-979e-48e8e22155b1",
                column: "ConcurrencyStamp",
                value: "26576a02-366b-48fa-903a-7feeca443e0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "829d3673-9429-44b9-9892-fef3122514c7",
                column: "ConcurrencyStamp",
                value: "90062cba-c0fb-422d-a725-2b77d42512f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "853619ef-752f-48f8-87ca-0af80aa48bbc",
                column: "ConcurrencyStamp",
                value: "72190d34-411a-45d8-bf8a-0176103e73cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1fbf13-dd3c-46df-8e6a-6665022f8783",
                column: "ConcurrencyStamp",
                value: "1e57bace-1c01-4db6-83e8-bf0cfbf376c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa8a879-cf25-4bd8-81d8-847ee6497e69",
                column: "ConcurrencyStamp",
                value: "6a2f9dca-5281-4ec5-8c57-a9e0b1194191");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c970652-13b2-428a-80a0-406d2fc46ce4",
                column: "ConcurrencyStamp",
                value: "cbff7505-d644-44dc-81e5-dac999ac7445");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2af5924-bc31-4efd-9319-0e418c0cfd8b",
                column: "ConcurrencyStamp",
                value: "bf10ce87-0627-4e6a-80ec-9ed2bd84d192");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdcbd510-ed11-45d3-82dc-3e6feb6dbab9",
                column: "ConcurrencyStamp",
                value: "4ec791f1-f8e7-468c-a42b-71957339d5e7");
        }
    }
}
