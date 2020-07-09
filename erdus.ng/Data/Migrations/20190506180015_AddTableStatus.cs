using Microsoft.EntityFrameworkCore.Migrations;

namespace erdus.ng.Data.Migrations
{
    public partial class AddTableStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Status_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Status_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestStatusId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "Requests");
        }
    }
}
