using System.ComponentModel.DataAnnotations;

namespace proj_webapi.Models
{
    /// <summary>
    ///  Classe que representa a entidade (TABELA) Equipamento no domínio da aplicação.
    /// </summary>
    public class Equipamento
    {
        [Key]
        public int IdEquipamento { get; set; } 
        public string Marca { get; set; } = string.Empty;
        public string TipoEquipamento { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string NumeroPatrimonio { get; set; } = string.Empty;

        // bool representa um valor lógico (true ou false)
        public bool Disponivel { get; set; }
    }
}
