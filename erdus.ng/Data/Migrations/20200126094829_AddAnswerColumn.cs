using Microsoft.EntityFrameworkCore.Migrations;

namespace erdus.ng.Data.Migrations
{
    public partial class AddAnswerColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Requests");
        }
    }
}
