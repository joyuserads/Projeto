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

        [Required] // Chave estrangeira obrigatória
        public int IdTipoUsuario { get; set; }

        // Navegação para o tipo de usuário (relacionamento N:1)
        public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }

        // Lista de salas atribuídas a este usuário (relacionamento 1:N)
        public virtual ICollection<Sala>? Salas { get; set; }
    }
}
