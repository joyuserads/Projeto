using System.ComponentModel.DataAnnotations;

namespace proj_webapi.Models
{
    public class TipoUsuario
    {
         
        [Key] // Chave primária
        public int IdTipoUsuario { get; set; }

        [Required]                      // Campo obrigatório
        public string NomeTipo { get; set; } = string.Empty;

        // Relacionamento com a tabela Usuario (um para muitos)
        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
