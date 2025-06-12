using System.ComponentModel.DataAnnotations;

namespace projeto_webApi.Domains
{
    public class Equipamento
    {
        /// <summary>
        ///     Identificador único do equipamento - Domain responsável pela validação do idEquipamento
        /// </summary>
        [Key] //    Atributo que indica que esta propriedade é a chave primária
        public int IdEquipamento { get; set; } // Identificador único do equipamento


        public required string Nome { get; set; } // Nome do equipamento
        public required string Descricao { get; set; } // Descrição do equipamento
        public required string NumeroPatrimonio { get; set; } // Número de patrimônio do equipamento
        public required string Marca { get; set; } //   Marca do equipamento
        public required string Tipo { get; set; } //    Tipo do equipamento (ex: Computador, Projetor, etc.)
        public required string NumeroDeSerie { get; set; }   //   Número de série do equipamento
        public required string Situacao { get; set; }  // Situação do equipamento (ex: Disponível, Em uso, Manutenção, etc.)
        public required ICollection<SalaEquipamento> SalaEquipamentos { get; set; } // Coleção de salas onde o equipamento está alocado
    }
}
