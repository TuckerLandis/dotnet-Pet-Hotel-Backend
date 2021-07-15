using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class thisOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_PetOwner",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetOwner",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetOwner",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PetOwners",
                newName: "petOwnerid");

            migrationBuilder.AddColumn<int>(
                name: "petOwnerid",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_petOwnerid",
                table: "Pets",
                column: "petOwnerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets",
                column: "petOwnerid",
                principalTable: "PetOwners",
                principalColumn: "petOwnerid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_petOwnerid",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "petOwnerid",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "petOwnerid",
                table: "PetOwners",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "PetOwner",
                table: "Pets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetOwner",
                table: "Pets",
                column: "PetOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_PetOwner",
                table: "Pets",
                column: "PetOwner",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
