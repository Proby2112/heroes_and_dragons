using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesAndDragons.DL.Migrations
{
    public partial class DragonEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentHp",
                table: "Dragons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DragonState",
                table: "Dragons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentHp",
                table: "Dragons");

            migrationBuilder.DropColumn(
                name: "DragonState",
                table: "Dragons");
        }
    }
}
