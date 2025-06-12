using System.ComponentModel.DataAnnotations;

namespace proj_webapi.Models
{
    /// <summary>
    /// Classe que representa a entidade (TABELA) Sala no domínio da aplicação
    /// </summary>
    public class Sala
    {
        [Key]
        public int IdSala { get; set; }      
        public int Andar { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Metragem { get; set; } = string.Empty;
    }
}
