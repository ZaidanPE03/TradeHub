using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TradeHub.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class kevin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5da587b5-fd70-49ac-acc6-0f63fa878e9a", "AQAAAAIAAYagAAAAEM2Lc/pmsiPUeD9ueGx9ImCGVb8I5Oz5hL9NO+mETMruSWy/DOkij2WJSFJ5o5kAiw==", "b0988405-bb7d-4781-ace9-afcf32dcb0ef" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Quantity", "SellId", "SellOrderId", "TradeId", "TradeOrderId", "Type" },
                values: new object[,]
                {
                    { 1, "Liquid Retina HD display.", "Iphone 11", 1600f, 25, 0, null, 0, null, "Mobile Phone" },
                    { 2, null, "Asus VivoBook", 2300f, 15, 0, null, 0, null, "Laptop" },
                    { 3, null, "Asus Ultra Thin", 1000f, 15, 0, null, 0, null, "Laptop" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b611a5cc-6828-472f-a022-0363a07c2f9c", "AQAAAAIAAYagAAAAEEhNyN4jVsaVlEiz6J2vt+/55rF2ny7OUvgGcCXYMowpq/79EZIXc2KhntfofceC2w==", "16644489-58c7-4ac1-bfd7-6913ba3765af" });
        }
    }
}
