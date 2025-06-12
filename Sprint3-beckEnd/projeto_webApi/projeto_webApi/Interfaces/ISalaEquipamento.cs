using projeto_webApi.Domains;

namespace projeto_webApi.Interfaces
{
    /// <summary>
    /// Interface para operações CRUD na relação entre Salas e Equipamentos
    /// </summary>
    public interface ISalaEquipamento
    {
        Task<IEnumerable<SalaEquipamento>> GetAllAsync(); // Retorna todas as relações entre salas e equipamentos

        Task<SalaEquipamento> GetByIdAsync(int id); // Retorna uma relação entre sala e equipamento por ID
        Task<SalaEquipamento> CreateAsync(SalaEquipamento salaEquipamento); // Cria uma nova relação entre sala e equipamento
        Task<SalaEquipamento> UpdateAsync(int id, SalaEquipamento salaEquipamento); // Atualiza a relação entre sala e equipamento
        Task<bool> DeleteAsync(int id);
    }
}
