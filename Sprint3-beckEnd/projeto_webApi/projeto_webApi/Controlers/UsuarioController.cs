using Microsoft.AspNetCore.Mvc;
using projeto_webApi.Domains;
using projeto_webApi.Interfaces;
using projeto_webApi.Repositories;

namespace projeto_webApi.Controlers
{
    // API/Controllers/UsuarioController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuario _repository; //   Repository interface for Usuario operations


        /// <summary>
        /// Constructor for the UsuarioController
        /// </summary>
        /// <param name="repository"></param>
        public UsuarioController(IUsuario repository)
        {
            _repository = repository; //    Assigning the provided repository to the private field
        }


        /// <summary>
        /// Retrieves all users from the database
        /// </summary>
        /// <returns>Retorna todos os usuarios</returns>
        [HttpGet] //    Retrieves all users
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()                            
        { 
            var usuarios = await _repository.GetAllAsync(); //   // Retrieves all users from the repository asynchronously
            return Ok(usuarios); //   Returns all users with their types

        }

        /// <summary>
        /// Retrieves a user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna todos os usuarios pelo id</returns>
        [HttpGet("{id}")] //    Retrieves a user by ID
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _repository.GetByIdAsync(id); //   Retorna usuario específico pelo ID
            if (usuario == null) //  Se não encontrado retorna not found
            {
                return NotFound(); //       User not found
            }
            return Ok(usuario); //   Returns the user with their type
        }


        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Retorna um novo usuario com verificaões validas</returns>
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            if (usuario == null) //   Se o usuário for nulo, retorna BadRequest
            {
                return BadRequest("Usuário inválido"); // Invalid user
            }
            if (string.IsNullOrWhiteSpace(usuario.Nome) || string.IsNullOrWhiteSpace(usuario.Email) || string.IsNullOrWhiteSpace(usuario.SenhaHash))
            {
                return BadRequest("Nome, Email e Senha são obrigatórios"); //   Nome, Email e Senha são obrigatórios
            }
            if (usuario.IdTipoUsuario <= 0) //   Verifica se o IdTipoUsuario é válido
            {
                return BadRequest("IdTipoUsuario inválido"); //   Invalid user type ID
            }
            //   Verifica se o email já está cadastrado
            var existingUsuario = await _repository.GetByIdAsync(usuario.IdUsuario);
            if (existingUsuario != null)
            {
                return Conflict("Email já cadastrado"); //   Email already registered
            }
            

            var novoUsuario = await _repository.AddAsync(usuario); //   Adiciona o usuário ao repositório
            return CreatedAtAction(nameof(GetUsuario), new { id = novoUsuario.IdUsuario }, novoUsuario); //   Retorna o usuário criado com status 201
        }


        /// <summary>
        /// Updates an existing user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns>Retorna um usuario com status 200 OK</returns>
        [HttpPut("{id}")] //    Atualiza um usuário existente
        public async Task<ActionResult<Usuario>> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario) //   Verifica se o ID do usuário corresponde ao ID fornecido
            {
                return BadRequest("ID do usuário não corresponde ao ID fornecido"); //   User ID does not match provided ID
            }
            if (usuario == null) //   Se o usuário for nulo, retorna BadRequest
            {
                return BadRequest("Usuário inválido"); // Invalid user
            }
            if (string.IsNullOrWhiteSpace(usuario.Nome) || string.IsNullOrWhiteSpace(usuario.Email) || string.IsNullOrWhiteSpace(usuario.SenhaHash))
            {
                return BadRequest("Nome, Email e Senha são obrigatórios"); //   Nome, Email e Senha são obrigatórios
            }
            if (usuario.IdTipoUsuario <= 0) //   Verifica se o IdTipoUsuario é válido
            {
                return BadRequest("IdTipoUsuario inválido"); //   Invalid user type ID
            }
            var usuarioExistente = await _repository.GetByIdAsync(id); //   Busca o usuário existente pelo ID
            if (usuarioExistente == null) //   Se não encontrado, retorna NotFound
            {
                return NotFound(); // User not found
            }
            var usuarioAtualizado = await _repository.UpdateAsync(usuario); //   Atualiza o usuário no repositório
            return Ok(usuarioAtualizado); //   Retorna o usuário atualizado com status 200
        }


        /// <summary>
        /// Deletes a user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um usuario deletado</returns>
        [HttpDelete("{id}")] //    Deleta um usuário pelo ID
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var usuarioExistente = await _repository.GetByIdAsync(id); //   Busca o usuário existente pelo ID
            if (usuarioExistente == null) //   Se não encontrado, retorna NotFound
            {
                return NotFound(); // User not found
            }
            var resultado = await _repository.DeleteAsync(id); //   Deleta o usuário do repositório
            if (!resultado) //   Se a deleção falhar, retorna BadRequest
            {
                return BadRequest("Erro ao deletar usuário"); // Error deleting user
            }
            return NoContent(); //   Retorna NoContent (204) se a deleção for bem-sucedida
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
