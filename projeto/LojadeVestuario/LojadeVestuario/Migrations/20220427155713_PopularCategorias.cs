using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojadeVestuario.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaName, Descricao) " +
                "VALUES('Camisas_Eportivas','Camisas de times esportivos')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaName,Descricao) " +
                "VALUES('Camisas_Basicas','Camisas que não tem nenhum detalhe, apenas cor')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");

        }
    }
}
