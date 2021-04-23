using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXiecheng.API.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("2e73140d-cabd-4881-afef-cd1df54f3e20"), new DateTime(2021, 4, 23, 3, 52, 8, 936, DateTimeKind.Utc).AddTicks(6701), null, "TestDescription", null, null, null, null, 0m, "TestTitle", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("2e73140d-cabd-4881-afef-cd1df54f3e20"));
        }
    }
}
