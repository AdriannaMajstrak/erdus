using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace erdus.ng.Data.Migrations
{
    public partial class AddTableRequestDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "RequestsDeleted",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    RequesterId = table.Column<string>(nullable: false),
                    ResponsiblePersonId = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    RequestStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsDeleted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestsDeleted_Statuses_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestsDeleted_AspNetUsers_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestsDeleted_AspNetUsers_ResponsiblePersonId",
                        column: x => x.ResponsiblePersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestsDeleted_RequestStatusId",
                table: "RequestsDeleted",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsDeleted_RequesterId",
                table: "RequestsDeleted",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsDeleted_ResponsiblePersonId",
                table: "RequestsDeleted",
                column: "ResponsiblePersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
