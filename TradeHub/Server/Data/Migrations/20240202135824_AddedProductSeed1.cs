using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TradeHub.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductSeed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46bf6489-a937-4051-9ae0-ec8555b1b564", "AQAAAAIAAYagAAAAEN5koNvEnWBoVdQx8qAU2HQJGuxC7WHRl6TKyqlfQrbin1zDXrbFyvnC6cdQkdfeaw==", "f8bf7dbc-1a92-4348-95a4-ae83b7c5ebd1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Quantity", "SellId", "SellOrderId", "TradeId", "TradeOrderId", "Type" },
                values: new object[,]
                {
                    { 1, "Mini Electric Toaster", "Toaster", 30.5f, 1, 0, null, 0, null, "Electronics" },
                    { 2, "Fast and lightweight road bike", "Carbon Fiber Road Bicycle", 2000f, 1, 0, null, 0, null, "Bicycles" }
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b611a5cc-6828-472f-a022-0363a07c2f9c", "AQAAAAIAAYagAAAAEEhNyN4jVsaVlEiz6J2vt+/55rF2ny7OUvgGcCXYMowpq/79EZIXc2KhntfofceC2w==", "16644489-58c7-4ac1-bfd7-6913ba3765af" });
        }
    }
}
