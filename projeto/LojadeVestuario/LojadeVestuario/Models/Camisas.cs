using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojadeVestuario.Models
{
    [Table("Camisas")]
    public class Camisas
    {
        [Key]   
        public int CamisasId { get; set; }

        [Required(ErrorMessage = "O nome da camisa deve ser informado")]
        [Display(Name = "Nome da Camisa")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string CamisasName { get; set; }

        [Required(ErrorMessage = "A descrição da Camisa deve ser informada")]
        [Display(Name = "Descrição da Camisa")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O descrição detalhada da Camisa deve ser informada")]
        [Display(Name = "Descrição detalhada da Camisa")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço da Camisa")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Mais Vendida(Preferida)?")]
        public bool IsCamisamaisVendida { get; set; }

        [Display(Name = "Tamanho da Camisa")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public char Tamanho { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        //Definição de relacionamento 
        //Foregin key
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
