namespace projeto_webApi.Domains
{
    public class TipoUsuario
    {
        public int IdTiposUsuario { get; set; }
        public required string Nome { get; set; }

        public virtual required ICollection<Usuario> Usuarios { get; set; }
    }
}
