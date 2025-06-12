using System.ComponentModel.DataAnnotations;

namespace proj_webapi.Models
{
    public class SalaEquipamento
    {
        [Key]
        public int IdSalaEquipamento { get; set; }
        public int IdSala { get; set; }
        public int IdEquipamento { get; set; }
        public virtual Equipamento? IdEquipamentoNavigation { get; set; }
        public virtual Sala? IdSalaNavigation { get; set; }
    }
}
