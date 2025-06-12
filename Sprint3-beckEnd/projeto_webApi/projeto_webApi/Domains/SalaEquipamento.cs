using System.ComponentModel.DataAnnotations;

namespace projeto_webApi.Domains
{
    public class SalaEquipamento
    {
        /// <summary>
        /// Identificador único da relação entre sala e equipamento - Domain responsável pela validação do idSalaEquipamentos
        /// </summary>

        [Key]
        public int IdSalaEquipamentos { get; set; }  // Identificador único da relação entre sala e equipamento
        public int IdSala { get; set; }          // Chave estrangeira para a sala onde o equipamento está alocado
        public int IdEquipamento { get; set; }   // Chave estrangeira para o equipamento alocado na sala
        public required Sala Sala { get; set; }   // Sala onde o equipamento está alocado
        public required Equipamento Equipamento { get; set; }    // Equipamento alocado na sala
    }
}
