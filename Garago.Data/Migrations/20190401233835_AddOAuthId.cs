using Microsoft.EntityFrameworkCore.Migrations;

namespace Garago.Data.Migrations
{
    public partial class AddOAuthId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OAuthId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OAuthId",
                table: "AspNetUsers");
        }
    }
}
