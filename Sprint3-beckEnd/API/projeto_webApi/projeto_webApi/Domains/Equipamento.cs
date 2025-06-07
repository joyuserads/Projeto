using Microsoft.AspNetCore.Authentication;
using System;

namespace projeto_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (TABELA) Equipamento no domínio da aplicação.
    /// </summary>
    public class Equipamento
    {
        public int IdEquipamento { get; set; }

        //com required eu torno este campo obrigatório
        public required string Marca { get; set; }

        // bool representa um valor lógico (true ou false)
        public bool Disponivel { get; set; }
        public required string Tipo { get; set; }
        public required string NumeroSerie { get; set; }
        public required string Descricao { get; set; }
        public required string NumeroPatrimonio { get; set; }

    }
}
