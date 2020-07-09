using Microsoft.EntityFrameworkCore.Migrations;

namespace erdus.ng.Data.Migrations
{
    public partial class AddCategoresRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Categories_RequestCategoryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestsDeleted_Categories_RequestCategoryId",
                table: "RequestsDeleted");

            migrationBuilder.AlterColumn<int>(
                name: "RequestCategoryId",
                table: "RequestsDeleted",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestCategoryId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Categories_RequestCategoryId",
                table: "Requests",
                column: "RequestCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsDeleted_Categories_RequestCategoryId",
                table: "RequestsDeleted",
                column: "RequestCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Categories_RequestCategoryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestsDeleted_Categories_RequestCategoryId",
                table: "RequestsDeleted");

            migrationBuilder.AlterColumn<int>(
                name: "RequestCategoryId",
                table: "RequestsDeleted",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RequestCategoryId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
