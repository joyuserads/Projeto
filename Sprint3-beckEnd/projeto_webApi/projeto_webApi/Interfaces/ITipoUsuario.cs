using projeto_webApi.Domains;

namespace projeto_webApi.Interfaces
{
    public interface ITipoUsuario
    {
        Task<IEnumerable<TipoUsuario>> GetAllAsync();       // Retorna todos os tipos
        Task<TipoUsuario> GetByIdAsync(int id);            // Retorna tipo por ID
        Task<TipoUsuario> AddAsync(TipoUsuario tipo);       // Adiciona novo tipo
        Task<TipoUsuario> UpdateAsync(TipoUsuario tipo);    // Atualiza tipo existente
        Task<bool> DeleteAsync(int id);                     // Remove tipo por ID

    }
}
