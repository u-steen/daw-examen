using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class addedComanda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Comenzi_ComandaId",
                table: "Produse");

            migrationBuilder.DropIndex(
                name: "IX_Produse_ComandaId",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "ComandaId",
                table: "Produse");

            migrationBuilder.AddColumn<string>(
                name: "IdProduse",
                table: "Comenzi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProduse",
                table: "Comenzi");

            migrationBuilder.AddColumn<int>(
                name: "ComandaId",
                table: "Produse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produse_ComandaId",
                table: "Produse",
                column: "ComandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Comenzi_ComandaId",
                table: "Produse",
                column: "ComandaId",
                principalTable: "Comenzi",
                principalColumn: "Id");
        }
    }
}
