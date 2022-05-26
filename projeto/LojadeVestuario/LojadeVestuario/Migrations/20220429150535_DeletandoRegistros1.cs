using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojadeVestuario.Migrations
{
    public partial class DeletandoRegistros1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Camisas WHERE CamisasId = 5");
            migrationBuilder.Sql("DELETE FROM Camisas WHERE CamisasId = 6");
            migrationBuilder.Sql("DELETE FROM Camisas WHERE CamisasId = 7");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Camisas ");

        }
    }
}
