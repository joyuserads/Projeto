using System.ComponentModel.DataAnnotations;

namespace proj_webapi.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty; 
        public int IdTipoUsuario { get; set; }

        public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Sala>? Salas { get; set; }
    }
}
