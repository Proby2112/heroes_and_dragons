using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesAndDragons.DL.Migrations
{
    public partial class HeroEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_AspNetUsers_HeroId",
                table: "Hits");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_AspNetUsers_HeroId",
                table: "Hits",
                column: "HeroId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_AspNetUsers_HeroId",
                table: "Hits");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_AspNetUsers_HeroId",
                table: "Hits",
                column: "HeroId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
