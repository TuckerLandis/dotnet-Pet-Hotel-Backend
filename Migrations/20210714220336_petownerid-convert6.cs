using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class petowneridconvert6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_{id}",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "{id}",
                table: "Pets",
                newName: "PetOwner");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_{id}",
                table: "Pets",
                newName: "IX_Pets_PetOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_PetOwner",
                table: "Pets",
                column: "PetOwner",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_PetOwner",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetOwner",
                table: "Pets",
                newName: "{id}");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_PetOwner",
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
    }
}
