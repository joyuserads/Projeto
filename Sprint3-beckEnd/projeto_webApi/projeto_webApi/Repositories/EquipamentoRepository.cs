using Microsoft.EntityFrameworkCore;
using projeto_webApi.Domains;
using projeto_webApi.Interfaces;

namespace projeto_webApi.Repositories
{
    /// <summary>
    ///     Classe responsável por implementar os métodos da interface IEquipamentos
    /// </summary>
    /// 
    public class EquipamentoRepository : IEquipamentos
    {
       
        private readonly ApplicationDbContext _context;


        /// <summary>
        /// Construtor que recebe o contexto do banco de dados
        /// </summary>
        /// <param name="context"></param>
        public EquipamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Método responsável por adicionar um novo equipamento ao banco de dados
        /// </summary>
        /// <param name="equipamento"></param>
        /// <returns>Adiciona um novo equipamento</returns>
        public async Task<Equipamento> AddAsync(Equipamento equipamento)
        {
            _context.Equipamentos.Add(equipamento); // Adiciona o equipamento ao contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

            return equipamento; // Retorna o equipamento adicionado

            //// O método AddAsync é responsável por adicionar um novo equipamento ao banco de dados.
            
        }

        /// <summary>
        ///     Método responsável por deletar um equipamento através do seu id
        /// </summary>
        /// <param name="id">id do equipamento deletado</param>
        /// <returns>retorna true se o equipamento foi deletado</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var equipamento = await _context.Equipamentos.FindAsync(id); // Busca o equipamento pelo ID
            if (equipamento == null) // Verifica se o equipamento existe
            {
                return false; // Retorna false se o equipamento não for encontrado
            }
            _context.Equipamentos.Remove(equipamento); // Remove o equipamento do contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            return true; // Retorna true se o equipamento foi removido com sucesso
        }

        /// <summary>
        /// Método responsável por buscar todos os equipamentos cadastrados
        /// </summary>
        /// <returns>retorna todos os equipamentos cadastramentos incluindo as salas</returns>
        public async Task<IEnumerable<Equipamento>> GetAllAsync()
        {
            // Método responsável por buscar todos os equipamentos cadastrados
            return await _context.Equipamentos  // Obtém o DbSet de Equipamentos do contexto
                .Include(e => e.SalaEquipamentos) // Inclui as salas associadas ao equipamento
                .ToListAsync();// Retorna todos os equipamentos cadastrados
        }

        /// <summary>
        /// Método responsável por buscar um equipamento através do seu id
        /// </summary>
        /// <param name="id">id do equipamento que será buscado</param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException">  </exception>
        public async Task<Equipamento> GetByIdAsync(int id)
        {
            // Busca o equipamento pelo ID no contexto do banco de dados
            var equipamento = await _context.Equipamentos.FindAsync(id);

            // Se o equipamento for encontrado, retorna o equipamento
            if (equipamento == null)
                //  Se o equipamento não for encontrado, lança uma exceção com KeyNotFoundException
                throw new KeyNotFoundException($"Equipamento com ID {id} não encontrado.");
            // Caso contrário, retorna o equipamento encontrado
            return equipamento;
        }

        /// <summary>
        /// Método responsável por atualizar um equipamento existente
        /// </summary>
        /// <param name="equipamento"></param>
        /// <returns>Retorna um equipamento existente atualizado</returns>
        public Task<Equipamento> UpdateAsync(Equipamento equipamento)
        {
           _context.Equipamentos.Update(equipamento); // Atualiza o equipamento no contexto
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return Task.FromResult(equipamento); // Retorna o equipamento atualizado
        }
    }
}
