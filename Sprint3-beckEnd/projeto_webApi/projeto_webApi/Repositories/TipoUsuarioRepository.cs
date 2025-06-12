using Microsoft.EntityFrameworkCore;
using projeto_webApi.Domains;
using projeto_webApi.Interfaces;

namespace projeto_webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {

        private readonly ApplicationDbContext _context;

        public TipoUsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Implementação dos métodos da interface ITipoUsuario
        public async Task<TipoUsuario> AddAsync(TipoUsuario tipo)
        {
            // Verifica se o tipo já existe
            if (tipo == null)
            {
                throw new ArgumentNullException(nameof(tipo), "TipoUsuario cannot be null");
            }
            if (string.IsNullOrWhiteSpace(tipo.NomeTipo))
            {
                throw new ArgumentException("Nome cannot be null or empty", nameof(tipo.NomeTipo));
            }
            // Adiciona o tipo de usuário ao contexto e salva as alterações
            if (_context.TipoUsuarios.Any(t => t.NomeTipo == tipo.NomeTipo))
            {
                throw new InvalidOperationException($"TipoUsuario with name '{tipo.NomeTipo}' already exists.");
            }
            // Adiciona o tipo de usuário ao contexto
            tipo.Usuarios = new List<Usuario>(); // Inicializa a coleção de usuários
                                                 // para evitar NullReferenceException
            _context.TipoUsuarios.Attach(tipo); // Attach the entity to the context
           

            _context.TipoUsuarios.Add(tipo);
            await _context.SaveChangesAsync();
            return tipo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tipo = await _context.TipoUsuarios.FindAsync(id);
            if (tipo == null)
                return false;

            _context.TipoUsuarios.Remove(tipo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TipoUsuario>> GetAllAsync()
        {
            // Retorna todos os tipos de usuário do banco de dados
            if (_context.TipoUsuarios == null)
            {
                throw new InvalidOperationException("TipoUsuarios DbSet is null.");
            }
            // Verifica se existem tipos de usuário no banco de dados
            if (!_context.TipoUsuarios.Any())
            {
                throw new InvalidOperationException("Nenhum TipoUsuario encontrado no banco de dados.");
            }
          

            return await _context.TipoUsuarios.ToListAsync();
        }

        public async Task<TipoUsuario?> GetByIdAsync(int id)
        {
            // Verifica se o id é válido
            if (id <= 0)
            {
                throw new ArgumentException("Id precisa ser maior que zero!!", nameof(id));
            }
            // Busca o tipo de usuário pelo id
            if (id <= 0)
            {
                throw new ArgumentException("Id deve ser maior que zero!!", nameof(id));
            }
            if (!_context.TipoUsuarios.Any(t => t.IdTipoUsuario == id))
            {
                throw new KeyNotFoundException($"TipoUsuario com esse Id {id} não foi encontrado!!.");
            }
            return await _context.TipoUsuarios.FindAsync(id);
        }

        public async Task<TipoUsuario> UpdateAsync(TipoUsuario tipo)
        {
            // Verifica se o tipo existe
            if (tipo == null)
            {
                throw new ArgumentNullException(nameof(tipo), "TipoUsuario cannot be null");
            }
            if (tipo.IdTipoUsuario <= 0)
            {
                throw new ArgumentException("IdTipoUsuario must be greater than zero", nameof(tipo.IdTipoUsuario));
            }
            if (string.IsNullOrWhiteSpace(tipo.NomeTipo))
            {
                throw new ArgumentException("NomeTipo cannot be null or empty", nameof(tipo.NomeTipo));
            }
            // Verifica se o tipo existe no banco de dados
            var existingTipo = await _context.TipoUsuarios.FindAsync(tipo.IdTipoUsuario);
            if (existingTipo == null)
            {
                throw new KeyNotFoundException($"TipoUsuario with Id {tipo.IdTipoUsuario} not found.");
            }
            // Atualiza o tipo de usuário
            if (existingTipo != tipo)
            {
                existingTipo.NomeTipo = tipo.NomeTipo; // Atualiza o nome do tipo de usuário
            }
            // Atualiza a entidade no contexto
            _context.Entry(existingTipo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            // Atualiza a coleção de usuários, se necessário
            if (tipo.Usuarios != null)
            {
                existingTipo.Usuarios = tipo.Usuarios; // Atualiza a coleção de usuários
            }
            _context.TipoUsuarios.Update(tipo);
            await _context.SaveChangesAsync();
            return tipo;

        }
    }
}
