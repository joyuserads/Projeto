using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string Nome { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public string? Descricao { get; set; }
    }
}