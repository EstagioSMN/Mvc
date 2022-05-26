using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojadeVestuario.Migrations
{
    public partial class DeletandoRegistros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Camisas WHERE CamisasId = 1");
            migrationBuilder.Sql("DELETE FROM Camisas WHERE CamisasId = 2");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Camisas ");
        }
    }
}
