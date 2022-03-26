using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb_4___API.Migrations
{
    public partial class weblinkfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_Persons_PersonID",
                table: "Hobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_WebLink_Hobbies_HobbyID",
                table: "WebLink");

            migrationBuilder.AlterColumn<int>(
                name: "HobbyID",
                table: "WebLink",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Hobbies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_Persons_PersonID",
                table: "Hobbies",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WebLink_Hobbies_HobbyID",
                table: "WebLink",
                column: "HobbyID",
                principalTable: "Hobbies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_Persons_PersonID",
                table: "Hobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_WebLink_Hobbies_HobbyID",
                table: "WebLink");

            migrationBuilder.AlterColumn<int>(
                name: "HobbyID",
                table: "WebLink",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Hobbies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_Persons_PersonID",
                table: "Hobbies",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WebLink_Hobbies_HobbyID",
                table: "WebLink",
                column: "HobbyID",
                principalTable: "Hobbies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
