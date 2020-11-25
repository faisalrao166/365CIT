using Microsoft.EntityFrameworkCore.Migrations;

namespace MyScriptureJournal.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Scripture");

            migrationBuilder.DropColumn(
                name: "Verse",
                table: "Scripture");

            migrationBuilder.AlterColumn<int>(
                name: "Chapter",
                table: "Scripture",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Scripture",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Verses",
                table: "Scripture",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Scripture");

            migrationBuilder.DropColumn(
                name: "Verses",
                table: "Scripture");

            migrationBuilder.AlterColumn<string>(
                name: "Chapter",
                table: "Scripture",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Scripture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Verse",
                table: "Scripture",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
