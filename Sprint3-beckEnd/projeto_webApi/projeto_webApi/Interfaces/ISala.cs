using projeto_webApi.Domains;

namespace projeto_webApi.Interfaces
{
    public interface ISala
    {
        Task<IEnumerable<Sala>> GetAllAsync();

        Task<Sala> GetByIdAsync(int id);

        Task<Sala> AddAsync(Sala sala);

        Task<Sala> UpdateAsync(Sala sala);

        Task<bool> DeleteAsync(int id);
    }
}
