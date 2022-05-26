using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojadeVestuario.Migrations
{
    public partial class PopularCamisas1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tamanho",
                table: "Camisas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tamanho",
                table: "Camisas");
        }
    }
}
