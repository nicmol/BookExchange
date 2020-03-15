using Microsoft.EntityFrameworkCore.Migrations;

namespace BookExchange.Data.Migrations
{
    public partial class Book7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Conversations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Conversations");
        }
    }
}
