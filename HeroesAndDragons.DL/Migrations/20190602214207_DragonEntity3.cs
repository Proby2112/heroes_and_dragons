using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesAndDragons.DL.Migrations
{
    public partial class DragonEntity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Dragons_DragonId",
                table: "Hits");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Dragons_DragonId",
                table: "Hits",
                column: "DragonId",
                principalTable: "Dragons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Dragons_DragonId",
                table: "Hits");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Dragons_DragonId",
                table: "Hits",
                column: "DragonId",
                principalTable: "Dragons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
