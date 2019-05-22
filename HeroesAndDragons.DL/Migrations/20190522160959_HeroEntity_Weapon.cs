using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesAndDragons.DL.Migrations
{
    public partial class HeroEntity_Weapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Dragons_DragonId",
                table: "Hits");

            migrationBuilder.DropForeignKey(
                name: "FK_Hits_AspNetUsers_HeroId",
                table: "Hits");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Hits_HeroId_DragonId",
                table: "Hits");

            migrationBuilder.AlterColumn<string>(
                name: "HeroId",
                table: "Hits",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DragonId",
                table: "Hits",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Weapon",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hits_HeroId",
                table: "Hits",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Dragons_DragonId",
                table: "Hits",
                column: "DragonId",
                principalTable: "Dragons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_AspNetUsers_HeroId",
                table: "Hits",
                column: "HeroId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Dragons_DragonId",
                table: "Hits");

            migrationBuilder.DropForeignKey(
                name: "FK_Hits_AspNetUsers_HeroId",
                table: "Hits");

            migrationBuilder.DropIndex(
                name: "IX_Hits_HeroId",
                table: "Hits");

            migrationBuilder.AlterColumn<string>(
                name: "HeroId",
                table: "Hits",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DragonId",
                table: "Hits",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Weapon",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Hits_HeroId_DragonId",
                table: "Hits",
                columns: new[] { "HeroId", "DragonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Dragons_DragonId",
                table: "Hits",
                column: "DragonId",
                principalTable: "Dragons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_AspNetUsers_HeroId",
                table: "Hits",
                column: "HeroId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
