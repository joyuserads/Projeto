using Microsoft.EntityFrameworkCore;
using projeto_webApi.Domains;
using projeto_webApi.Interfaces;

namespace projeto_webApi.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        /// <summary>
        /// Repository for managing Usuario entities
        /// </summary>
        private readonly ApplicationDbContext _context; //   Application database context for database operations

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context; //  Assigning the provided context to the private field
        }

        /// <summary>
        ///     Adds a new Usuario to the database
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Retorna um novo usuario</returns>
        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            // Adiciona novo usuário
            _context.Usuarios.Add(usuario); //   Adiciona o usuário ao contexto do banco de dados
            await _context.SaveChangesAsync(); //   Salva as alterações no banco de dados
            return usuario; //  Retorna o usuário adicionado com sucesso
        }


        /// <summary>
        /// Deletes a Usuario by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Remove um usuario</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            // Remove usuário pelo ID
            var usuario = await _context.Usuarios.FindAsync(id); //     Busca o usuário pelo ID fornecido
            if (usuario == null) //     // Se o usuário não for encontrado, retorna false
                return false; //    Usuário não encontrado, retorna false

            _context.Usuarios.Remove(usuario); //   Remove o usuário do contexto
            await _context.SaveChangesAsync(); //    Salva as alterações no banco de dados
            return true; // Usuário removido com sucesso
        }

        /// <summary>
        /// Retrieves all Usuarios from the database
        /// </summary>
        /// <returns>Retorna todos os usuarios e seu tipo</returns>
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            //Retorna todos os usuários com seus respectivos tipos
            return await _context.Usuarios.Include(u => u.TipoUsuario).ToListAsync(); //    Inclui o TipoUsuario relacionado a cada usuário e retorna a lista completa de usuários
        }


        /// <summary>
        /// Retrieves a Usuario by its ID, including its TipoUsuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o id do usuario e o tipo</returns>
        public async Task<Usuario?> GetByIdAsync(int id)

        {
            // Busca usuário por ID incluindo o tipo
            return await _context.Usuarios.Include(u => u.TipoUsuario) //   Inclui o TipoUsuario relacionado ao usuário
                .FirstOrDefaultAsync(u => u.IdUsuario == id); //    Retorna o primeiro usuário que corresponde ao ID fornecido ou null se não encontrado
        }


        /// <summary>
        /// Updates an existing Usuario in the database
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Atualiza todos os usuarios</returns>
        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            // Atualiza usuário existente
            _context.Usuarios.Update(usuario); //   Atualiza o usuário no contexto
            await _context.SaveChangesAsync();//    Salva as alterações no banco de dados
            return usuario; //  Retorna o usuário atualizado
        }
    }
}
