using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeHub.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbc3a2c7-7e4a-42a2-9ef3-a75363d24297", "AQAAAAIAAYagAAAAEBaNMUUO3fba/aBRFTlreaI0l5VwXxtgwVZjtcLpISJ98LoT/YOMjO21C8/xhYYONQ==", "be01d9ee-b79d-4620-aaf7-1a17db81d930" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46bf6489-a937-4051-9ae0-ec8555b1b564", "AQAAAAIAAYagAAAAEN5koNvEnWBoVdQx8qAU2HQJGuxC7WHRl6TKyqlfQrbin1zDXrbFyvnC6cdQkdfeaw==", "f8bf7dbc-1a92-4348-95a4-ae83b7c5ebd1" });
        }
    }
}
