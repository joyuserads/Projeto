namespace projeto_webApi.Domains
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public int? IdTiposUsuario { get; set; }

        //public virtual TiposUsuario IdTiposUsuarioNavigation { get; set; }
        public virtual required ICollection<Sala> Salas { get; set; }


    }
}
