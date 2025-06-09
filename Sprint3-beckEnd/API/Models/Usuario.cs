using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string SenhaHash { get; set; }

        [Required(ErrorMessage = "O papel do usuário é obrigatório.")]
        public string Papel { get; set; }
    }
}