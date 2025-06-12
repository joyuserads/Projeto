using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projeto_webApi.Domains
{
    public class Usuario
    {
        /// <summary>
        ///     Identificador único do usuário - Domain resposavel pela validação do idUsuario
        /// </summary>

        [Key]
        public int IdUsuario { get; set; } // Identificador único do usuário


        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'Senha' é obrigatório.")]
        public string SenhaHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'IdTipoUsuario' é obrigatório.")]
        public int IdTipoUsuario { get; set; }

       // [JsonIgnore] // Impede erro de desserialização
        public required TipoUsuario TipoUsuario { get; set; } // <<< IMPORTANTE: Nullable e JsonIgnore
    }
}
