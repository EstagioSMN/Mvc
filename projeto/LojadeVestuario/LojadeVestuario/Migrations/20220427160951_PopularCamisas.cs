using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojadeVestuario.Migrations
{
    public partial class PopularCamisas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Camisas(CategoriaId,CamisasName, DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl, ImagemThumbnailUrl,IsCamisamaisVendida,Tamanho,EmEstoque) " +
                "VALUES(1,'Camisa Flamengo','Camisa Flamengo Rubro-Negra 2022','Camisa do Time de Flamengo Vermelha e Preta para a temporada do ano 2022',180.00, 'https://flamengo.vteximg.com.br/arquivos/ids/164240-1000-1000/Auth_1-removebg-preview.png?v=637835748106270000','https://flamengo.vteximg.com.br/arquivos/ids/164240-1000-1000/Auth_1-removebg-preview.png?v=637835748106270000', 1 ,'M', 1)");
            
            migrationBuilder.Sql("INSERT INTO Camisas(CategoriaId,CamisasName, DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl, ImagemThumbnailUrl,IsCamisamaisVendida,Tamanho, EmEstoque) " +
                "VALUES(1,'Camisa Seahawks','Camisa Jersey Seattle Seahawks','Camisa Jersey Azul da fraquia de Futebol Americano Seattle Seahawks, com o nome do atleta DK Metacalf e número 14 .',200.00,'https://fanatics.frgimages.com/FFImage/thumb.aspx?i=/productimages/_3533000/altimages/ff_3533176-c57a03fdd1b7ffa9767calt1_full.jpg&w=900','https://fanatics.frgimages.com/FFImage/thumb.aspx?i=/productimages/_3533000/altimages/ff_3533176-c57a03fdd1b7ffa9767calt1_full.jpg&w=900',0,'M', 1)");
           
            migrationBuilder.Sql("INSERT INTO Camisas(CategoriaId,CamisasName, DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl, ImagemThumbnailUrl,IsCamisamaisVendida,EmEstoque) " +
                            "VALUES(2,'Camisa Preta','Camisa Basica Cor Preta','Camisa Basica da cor preta,sem nenhum detalhe',80.00,'https://img.elo7.com.br/product/zoom/36F76BB/camiseta-masculina-basica-nelville-streetwear-algodao-100.jpg','https://img.elo7.com.br/product/zoom/36F76BB/camiseta-masculina-basica-nelville-streetwear-algodao-100.jpg',0,'M', 1)");

        }

        //Falta COLOCAR O DA CATEGORIA 2 e fazer o update-database
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Camisas");

        }
    }
}
