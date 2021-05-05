using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Auth.Data.Account.Migrations
{
    public partial class AddCustomerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "account",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56b4ca14-43a0-4281-b5b7-6e73e400cf82");

            migrationBuilder.DeleteData(
                schema: "account",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3864a4f-1607-4c2f-8360-833047575c1b");

            migrationBuilder.InsertData(
                schema: "account",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "Descriptor" },
                values: new object[] { "1c3fe362-b31e-4c73-9161-b24d5eb8f3de", "ca4436e7-6470-4adc-ba34-313061149fae", "AppRole", "Admin", "ADMIN", "ThAmCo Administrators" });

            migrationBuilder.InsertData(
                schema: "account",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "Descriptor" },
                values: new object[] { "036a70e8-ea8e-4425-88a3-9057c9f7b050", "5fe58522-e629-4f6f-885e-bb2be84777f8", "AppRole", "Staff", "STAFF", "ThAmCo Staff Members" });

            migrationBuilder.InsertData(
                schema: "account",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "Descriptor" },
                values: new object[] { "fdc67704-c5c0-4399-884b-b4de20afe561", "27d90cd5-de1e-44f0-9814-799dc1659d29", "AppRole", "Customer", "CUSTOMER", "ThAmCo Customers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "account",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "036a70e8-ea8e-4425-88a3-9057c9f7b050");

            migrationBuilder.DeleteData(
                schema: "account",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c3fe362-b31e-4c73-9161-b24d5eb8f3de");

            migrationBuilder.DeleteData(
                schema: "account",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdc67704-c5c0-4399-884b-b4de20afe561");

            migrationBuilder.InsertData(
                schema: "account",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "Descriptor" },
                values: new object[] { "d3864a4f-1607-4c2f-8360-833047575c1b", "28cc5c9f-90b9-44c3-9450-5dd0335d7bc7", "AppRole", "Admin", "ADMIN", "ThAmCo Administrators" });

            migrationBuilder.InsertData(
                schema: "account",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "Descriptor" },
                values: new object[] { "56b4ca14-43a0-4281-b5b7-6e73e400cf82", "438580ab-bb4a-4f5c-bb00-49729fef9966", "AppRole", "Staff", "STAFF", "ThAmCo Staff Members" });
        }
    }
}
