using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using proj_webapi.Data;
using proj_webapi.Models;

namespace proj_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context; // Atribui o contexto ao campo privado
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Todos os usuarios listados existentes</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuario()
        {
            var usuarios = _context.Usuarios
                .Include(u => u.IdTipoUsuarioNavigation)
                .Include(u => u.Salas)
                .ToList();

            return Ok(usuarios);
        
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Usuario> GetUsuarioById(int id) 
        {
            var usuario = _context.Usuarios                     // Acessa a tabela Usuarios
            .Include(u => u.IdTipoUsuarioNavigation)        // Inclui tipo de usuário
            .Include(u => u.Salas)                          // Inclui salas
            .FirstOrDefault(u => u.IdUsuario == id);        // Busca pelo ID
            if (usuario == null) { 
            
                return NotFound("Usuario não encontrado!!");
            
            }
            return Ok(usuario);     

        }

        // POST: api/Usuario
        [HttpPost] // Mapeia requisições HTTP POST
        public IActionResult Login( Usuario usuario)
        {
            // Verifica se o usuário existe no banco
            var usuarios = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email && u.Senha == usuario.Senha);

            if (usuarios == null )
            {
                return Unauthorized("E-mail ou senha inválidos!");
            }

            // Cria o TOKEN
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarios.Email),
                new Claim(ClaimTypes.Role, usuarios.IdTipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha_chave_super_secreta_que_tem_32_ou_mais_chars"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: "webapi",
                audience: "webapi",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")] // Mapeia requisições HTTP PUT com ID
        public IActionResult Update(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.IdUsuario)                          // Verifica se o ID da URL bate com o do corpo
                return BadRequest("ID não corresponde.");       // Retorna HTTP 400

            if (!ModelState.IsValid)                            // Verifica se o modelo é válido
                return BadRequest(ModelState);                  // Retorna HTTP 400 com os erros

            _context.Entry(usuario).State = EntityState.Modified; // Marca o objeto como modificado

            try
            {
                _context.SaveChanges();                         // Salva as alterações no banco
            }
            catch (DbUpdateConcurrencyException)                // Captura erros de concorrência
            {
                if (!_context.Usuarios.Any(u => u.IdUsuario == id)) // Verifica se o usuário ainda existe
                    return NotFound();                          // Retorna HTTP 404

                throw;                                          // Rethrow se for outro tipo de erro
            }

            return NoContent();                                 // Retorna HTTP 204: atualizado com sucesso
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")] // Mapeia requisições HTTP DELETE com ID
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);           // Busca o usuário pelo ID

            if (usuario == null)                                // Se não encontrar
                return NotFound();                              // Retorna HTTP 404

            _context.Usuarios.Remove(usuario);                  // Remove do contexto
            _context.SaveChanges();                             // Salva no banco

            return NoContent();                                 // Retorna HTTP 204: excluído com sucesso
        }

    }
}
