using Microsoft.EntityFrameworkCore;
using projeto_webApi.Domains;
using projeto_webApi.Interfaces;

namespace projeto_webApi.Repositories
{
    /// <summary>
    ///     Classe responsável por implementar as operações de CRUD para a entidade Sala
    /// </summary>
    public class SalaRepository : ISala
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados
        /// </summary>
        /// <param name="context"></param>
        public SalaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sala> AddAsync(Sala sala)
        {
            _context.Salas.Add(sala); // Adiciona a sala ao contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            return sala; // Retorna a sala adicionada
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sala = await _context.Salas.FindAsync(id); // Busca a sala pelo ID
            if (sala == null) // Verifica se a sala existe
            {
                return false; // Retorna false se a sala não for encontrada
            }
            _context.Salas.Remove(sala); // Remove a sala do contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            return true; // Retorna true se o equipamento foi removido com sucesso
        }

        public async Task<IEnumerable<Sala>> GetAllAsync()
        {
           return await _context.Salas
                .Include(s => s.Usuario) // Inclui o usuário responsável pela sala
                .Include(s => s.SalaEquipamentos) // Inclui os equipamentos alocados na sala
                .ToListAsync(); // Retorna a lista de salas com os dados relacionados
        }

        public async Task<Sala> GetByIdAsync(int id)
        {
              var sala = await _context.Salas.FindAsync(id); // Busca a sala pelo ID
            if (sala == null) // Verifica se a sala existe
            {
                throw new KeyNotFoundException($"Sala com ID {id} NÃO encontrada"); // Lança exceção se não encontrar
            }
            return sala; // Retorna a sala encontrada
        }

        public async Task<Sala> UpdateAsync(Sala sala)
        {
            _context.Salas.Update(sala); // Atualiza a sala no contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            return sala; // Retorna a sala atualizada
        }
    }
}
