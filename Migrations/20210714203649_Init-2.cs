using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_PetOwners",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetOwners",
                table: "Pets",
                newName: "PetOwner");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_PetOwners",
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
                newName: "PetOwners");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_PetOwner",
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
