using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class petowneridagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_PetOwners",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetOwners",
                table: "Pets",
                newName: "PetOwnerid");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_PetOwners",
                table: "Pets",
                newName: "IX_Pets_PetOwnerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_PetOwnerid",
                table: "Pets",
                column: "PetOwnerid",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_PetOwnerid",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetOwnerid",
                table: "Pets",
                newName: "PetOwners");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_PetOwnerid",
                table: "Pets",
                newName: "IX_Pets_PetOwners");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_PetOwners",
                table: "Pets",
                column: "PetOwners",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
