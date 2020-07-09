using Microsoft.EntityFrameworkCore.Migrations;

namespace erdus.ng.Data.Migrations
{
    public partial class AddAnswerColumnRequestDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "RequestsDeleted",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "RequestsDeleted");
        }
    }
}
