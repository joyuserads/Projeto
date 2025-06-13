using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proj_webapi.Data;
using proj_webapi.Models;

namespace proj_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {

        private readonly AppDbContext _context;

        public TipoUsuarioController(AppDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Lista todos os tipos usuarios
        /// </summary>
        /// <returns>Retorna todos os tipos usuarios existentes</returns>
       // [Authorize(Roles = "1")]
        [HttpGet]
        public ActionResult<IEnumerable<TipoUsuario>> GetTipoUsuarios() 
        {
            var lista = _context.TipoUsuarios  // Acessa a tabela TiposUsuario do banco
            .Include(t => t.Usuarios) // Carrega também os usuários relacionados (pode remover se não precisar)
            .ToList();      // Executa a consulta e converte em lista

            return Ok(lista); // Status code 200 com lista de TipoUsuarios
        
        }

        /// <summary>
        /// Lista todos os tipo usuario pelo ID
        /// </summary>
        /// <param name="id">id do tipo usuario</param>
        /// <returns>retorna o TipoUsuario pelo id com status 200</returns>
        // [Authorize(Roles = "1")]
        [HttpGet]
        [Route("{id}")]
        public ActionResult<TipoUsuario> GetTipoUsuarioById(int id)
        {
            var tipo = _context.TipoUsuarios              // Acessa a tabela TiposUsuario
           .Include(t => t.Usuarios)                 // Carrega os usuários relacionados (opcional)
           .FirstOrDefault(t => t.IdTipoUsuario == id); // Busca o primeiro tipo com o ID informado

            if (tipo == null)  // Verifica se não foi encontrado
            {
                return NotFound("Este tipo de usuario não foi encontrado!");   // Retorna status 404
            }

            return Ok(tipo); // retorna status 200

        }

        /// <summary>
        /// Cadastra um novo tipoUsuario 
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>Retorna um novo tipoUsuario</returns>
        //[Authorize(Roles = "1")]
        [HttpPost] // Mapeia requisições POST para criação de novos registros]
        public ActionResult<TipoUsuario> PostTipoUsuario(TipoUsuario tipo) 
        {
            if (!ModelState.IsValid)   // Verifica se os dados são válidos (baseado nas validações do modelo)
            {
                return BadRequest(ModelState);            // Retorna status 400 com erros de validação
            }
            _context.TipoUsuarios.Add(tipo);             // Adiciona o novo tipo ao contexto
            _context.SaveChanges();                       // Salva no banco de dados           

            return CreatedAtAction(                       // Retorna status 201 Created
          nameof(GetTipoUsuarioById),              // Indica o método onde o recurso pode ser acessado
          new { id = tipo.IdTipoUsuario },         // Passa o ID recém-criado como parâmetro da rota
          tipo);                                   // Retorna o objeto criado
        }

        /// <summary>
        /// Atualiza um tipoUsuario através do ID
        /// </summary>
        /// <param name="id">id do tipo usuario atualizado</param>
        /// <param name="tipo">tipo Usuario</param>
        /// <returns>Retorna a atualizacao do tipo usuario pelo ID</returns>
        
        //[Authorize(Roles = "1")]
        // PUT: api/TipoUsuario/5
        [HttpPut("{id}")] // Mapeia requisições PUT com parâmetro {id} para atualização
        public IActionResult Update(int id, [FromBody] TipoUsuario tipo) // Recebe o ID e o novo modelo a ser atualizado
        {
            if (id != tipo.IdTipoUsuario)                // Verifica se o ID da URL é igual ao do objeto recebido
                return BadRequest("ID não corresponde."); // Retorna status 400 se não corresponder

            if (!ModelState.IsValid)                      // Verifica se o modelo é válido
                return BadRequest(ModelState);            // Retorna status 400 com os erros

            _context.Entry(tipo).State = EntityState.Modified; // Marca o objeto como modificado (pronto para update)

            try
            {
                _context.SaveChanges();                  // Tenta salvar as alterações no banco
            }
            catch (DbUpdateConcurrencyException)         // Captura erros de concorrência (ex: se alguém excluiu o registro)
            {
                if (!_context.TipoUsuarios.Any(t => t.IdTipoUsuario == id)) // Verifica se o registro ainda existe
                    return NotFound();                   // Retorna status 404 se não existir

                throw;                                   // Se for outro tipo de erro, relança a exceção
            }

            return NoContent();                          // Retorna status 204: atualizado com sucesso, sem conteúdo
        }

        /// <summary>
        /// Deleta um TipoUsuario Existente
        /// </summary>
        /// <param name="id">id do tipo usuario existente</param>
        /// <returns>deleta um tipo usuario com status code 204</returns>
        [HttpDelete("{id}")] // Mapeia requisições DELETE com parâmetro {id}
        public IActionResult Delete(int id)
        {
            var tipo = _context.TipoUsuarios.Find(id);   // Tenta encontrar o tipo de usuário pelo ID

            if (tipo == null)                            // Se não encontrar
                return NotFound();                       // Retorna status 404

            _context.TipoUsuarios.Remove(tipo);          // Remove o item do contexto
            _context.SaveChanges();                      // Salva as mudanças no banco de dados

            return NoContent();                          // Retorna status 204: item excluído com sucesso
        }

    }
}
