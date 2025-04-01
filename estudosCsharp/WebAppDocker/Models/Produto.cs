using System.ComponentModel.DataAnnotations;

namespace WebAppDocker.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        // Exemplo de propriedade adicional
        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres")]
        public string Descricao { get; set; }

        // Exemplo de relacionamento (se tiver categorias)
        // public int CategoriaId { get; set; }
        // public Categoria Categoria { get; set; }
    }
}