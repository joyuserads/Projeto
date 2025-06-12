using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projeto_webApi.Domains
{
    public class TipoUsuario
    {
        /// <summary>
        /// Identificador único do tipo de usuário - Domain responsável pela validação do idTipoUsuario
        /// </summary>

        [Key]
        public int IdTipoUsuario { get; set; }
        public required string NomeTipo { get; set; } = string.Empty; // Nome do tipo de usuário (Administrador, Comum, etc.)

        public required ICollection<Usuario> Usuarios { get; set; }  // Coleção de usuários associados a este tipo de usuário                     
    }

}
