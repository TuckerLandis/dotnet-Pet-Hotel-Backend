using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class petowneridconvert3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_PetOwnerid",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetOwnerid",
                table: "Pets",
                newName: "{id}");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_PetOwnerid",
                table: "Pets",
                newName: "IX_Pets_{id}");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_{id}",
                table: "Pets",
                column: "{id}",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_{id}",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "{id}",
                table: "Pets",
                newName: "PetOwnerid");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_{id}",
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
    }
}
