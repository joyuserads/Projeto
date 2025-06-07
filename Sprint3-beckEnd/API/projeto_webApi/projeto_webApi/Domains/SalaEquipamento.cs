namespace projeto_webApi.Domains
{
    public class SalaEquipamento
    {
        public int IdSalasEquipamento { get; set; }
        public int? IdSala { get; set; }
        public int? IdEquipamento { get; set; }

       // public virtual Equipamento IdEquipamentoNavigation { get; set; }
       // public virtual Sala IdSalaNavigation { get; set; }
    }
}
