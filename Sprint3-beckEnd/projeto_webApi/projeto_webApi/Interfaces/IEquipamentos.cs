using Microsoft.Build.Utilities;
using projeto_webApi.Domains;

namespace projeto_webApi.Interfaces
{
    public interface IEquipamentos 
    {
        /// <summary>
        /// Método responsável por buscar todos os equipamentos cadastrados
        /// </summary>
        /// <returns>retorna todos os equipamentos cadastrados</returns>
        Task<IEnumerable<Equipamento>> GetAllAsync();

        /// <summary>
        /// Método responsável por buscar um equipamento através do seu id
        /// </summary>
        /// <param name="id">id dos equipamentos</param>
        /// <returns>retorna o equipamento através do id</returns>
        Task<Equipamento> GetByIdAsync(int id);

        /// <summary>
        ///     Método responsavel por adicionar um novo equipamento
        /// </summary>
        /// <param name="equipamento"></param>
        /// <returns>adiciona  um novo equipamento </returns>
        Task<Equipamento> AddAsync(Equipamento equipamento);

        /// <summary>
        /// Método responsável por atualizar um equipamento existente
        /// </summary>
        /// <param name="equipamento"></param>
        /// <returns>atualiza um equipamento existente</returns>
        Task<Equipamento> UpdateAsync(Equipamento equipamento);

        /// <summary>
        /// Método responsável por deletar um equipamento através do seu id
        /// </summary>
        /// <param name="id">id do equipamento que vai ser deletado</param>
        /// <returns>deleta um equipamento existente </returns>
        Task<bool> DeleteAsync(int id);

    }
}
