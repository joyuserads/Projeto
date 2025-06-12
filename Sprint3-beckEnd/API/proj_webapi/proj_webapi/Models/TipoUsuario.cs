using System.ComponentModel.DataAnnotations;

namespace proj_webapi.Models
{
    public class TipoUsuario
    {

        [Key]
        public int IdTipoUsuario { get; set; }
        public string NomeTipo { get; set; } = string.Empty;
        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
