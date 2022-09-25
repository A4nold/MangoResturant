using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Services.ShoppingCartAPI.Migrations
{
    public partial class _AddedCountFieldToCartdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "CartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "CartDetails");
        }
    }
}
