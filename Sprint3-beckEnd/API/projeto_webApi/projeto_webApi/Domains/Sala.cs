namespace projeto_webApi.Domains
{
    public class Sala
    {

        public int IdSala { get; set; }
        public int Andar { get; set; }
        public required string Nome { get; set; }
        public int Metragem { get; set; }
        public int? IdUsuario { get; set; }

         //public virtual Usuario IdUsuarioNavigation { get; set; }
        //public virtual ICollection<SalasEquipamento> SalasEquipamentos { get; set; }

    }
}
