using projeto_webApi.Domains;
using projeto_webApi.Interfaces;

namespace projeto_webApi.Repositories
{
    /// <summary>
    /// Implementação da interface ISalaEquipamento para operações CRUD na relação entre Salas e Equipamentos
    /// </summary>
    public class SalaEquipamentoRepository : ISalaEquipamento
    {
        private readonly ApplicationDbContext _context;


        /// <summary>
        /// Construtor que recebe o contexto do banco de dados
        /// </summary>
        /// <param name="context">contexto do banco de dados</param>
        public SalaEquipamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método responsável por criar uma nova relação entre sala e equipamento
        /// </summary>
        /// <param name="salaEquipamento"></param>
        /// <returns>Retorna a relação criada</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<SalaEquipamento> CreateAsync(SalaEquipamento salaEquipamento)
        {
            await _context.SalaEquipamentos.AddAsync(salaEquipamento); // Adiciona a nova relação ao contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            return salaEquipamento; // Retorna a relação criada
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var salaEquipamento = await _context.SalaEquipamentos.FindAsync(id); // Busca a relação pelo ID
            if (salaEquipamento == null) // Verifica se a relação existe
            {
                return false; // Retorna false se a relação não for encontrada
            }
            _context.SalaEquipamentos.Remove(salaEquipamento); // Remove a relação do contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            return true; // Retorna true se o equipamento foi removido com sucesso
        }

        public Task<IEnumerable<SalaEquipamento>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SalaEquipamento> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SalaEquipamento> UpdateAsync(int id, SalaEquipamento salaEquipamento)
        {
            throw new NotImplementedException();
        }
    }
}
