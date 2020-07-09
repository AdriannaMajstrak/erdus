using Microsoft.EntityFrameworkCore.Migrations;

namespace erdus.ng.Data.Migrations
{
    public partial class AddCategores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<int>(
                name: "RequestCategoryId",
                table: "RequestsDeleted",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestCategoryId",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestsDeleted_RequestCategoryId",
                table: "RequestsDeleted",
                column: "RequestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestCategoryId",
                table: "Requests",
                column: "RequestCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Categories_RequestCategoryId",
                table: "Requests",
                column: "RequestCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsDeleted_Categories_RequestCategoryId",
                table: "RequestsDeleted",
                column: "RequestCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Categories_RequestCategoryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestsDeleted_Categories_RequestCategoryId",
                table: "RequestsDeleted");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_RequestsDeleted_RequestCategoryId",
                table: "RequestsDeleted");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestCategoryId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestCategoryId",
                table: "RequestsDeleted");

            migrationBuilder.DropColumn(
                name: "RequestCategoryId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RequestsDeleted",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
