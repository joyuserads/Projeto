using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace projeto_webApi.Domains
{
    public class Sala
    {
        /// <summary>
        ///     Identificador único da sala - Domain responsável pela validação do idSala
        /// </summary>
        [Key]
        public int IdSala { get; set; }     // Identificador único da sala
        public int IdUsuario { get; set; }  // Chave estrangeira para o usuário responsável pela sala
        public required string Andar { get; set; }
        public required string Nome { get; set; }
        public required string Metragem { get; set; } //    Metragem da sala
        public required Usuario Usuario { get; set; } //    Usuário responsável pela sala
        public required ICollection<SalaEquipamento> SalaEquipamentos { get; set; } //  Coleção de equipamentos alocados na sala
    }
}
