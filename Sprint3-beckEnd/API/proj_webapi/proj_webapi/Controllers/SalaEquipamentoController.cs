using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proj_webapi.Data;
using proj_webapi.Models;

namespace proj_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaEquipamentoController : ControllerBase
    {

        private readonly AppDbContext _context;

        public SalaEquipamentoController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: api/SalaEquipamento
        /// </summary>
        /// <returns> Retorna todos os registros de SalaEquipamento</returns>
        [HttpGet]
        public ActionResult<IEnumerable<SalaEquipamento>> GetSalaEquipamento()
        {
            var lista = _context.SalaEquipamentos
            // Carrega os dados de navegação (relacionamentos)
            .Include(se => se.IdSalaNavigation)
            .Include(se => se.IdEquipamentoNavigation)
            .ToList();

            // status code 200
            return Ok(lista);

        }

        /// <summary>
        /// GET: api/SalaEquipamento/5
        /// </summary>
        /// <param name="id">id buscada</param>
        /// <returns>Retorna um registro específico por ID</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<SalaEquipamento> GetById(int id)
        {
            // Busca o item pelo ID, incluindo os relacionamentos
            var item = _context.SalaEquipamentos
            .Include(se => se.IdSalaNavigation)
            .Include(se => se.IdEquipamentoNavigation)
            .FirstOrDefault(se => se.IdSalaEquipamento == id);


            //condição se item for null 
            if (item == null)
            {
                // return 404 Não encontrado!
                return NotFound("Erro! Não encontrado!");

            }

            //retorna status code 200!
            return Ok(item);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult PutSalaEquipamentoById(SalaEquipamento salaEquipamento, int id)
        {
            // se id for diferente da URL retorna true
            if (id != salaEquipamento.IdEquipamento)
            {
                // Retorna HTTP 400 se forem diferentes
                return BadRequest("ID não corresponde!"); // Garante que o ID da URL bate com o do corpo 
            }

            if (!ModelState.IsValid) // Verifica se o modelo passado é válido
            {
                // Retorna HTTP 400 com erros de validação
                return BadRequest(ModelState);
            }

            _context.Entry(salaEquipamento).State = EntityState.Modified;  // Marca o objeto como "modificado"

            try
            {
                _context.SaveChanges(); // Tenta salvar as alterações no banco de dados
            }
            catch (DbUpdateConcurrencyException)  // Captura exceções de concorrência (ex: registro foi excluído antes da atualização)
            {
                // Verifica se o registro realmente existe no banco
                if (!_context.SalaEquipamentos.Any(se => se.IdSalaEquipamento == id))
                {
                    return NotFound("Registro não encontrado!");   // Se não existir, retorna status 404

                    throw;   // Se for outro erro, relança a exceção
                }

            }

            return NoContent();                    // Retorna HTTP 204 No Content (atualização feita com sucesso)
        }


        [HttpPost]
        public ActionResult<SalaEquipamento> PostSalaEquipamentos(SalaEquipamento salaEquipamento)
        {
            if (!ModelState.IsValid)   // Verifica se o modelo é válido (validações de DataAnnotations)
            {
                return BadRequest(ModelState); // Se inválido, retorna HTTP 400 com os erros
            }

            _context.SalaEquipamentos.Add(salaEquipamento); // Adiciona ao contexto (ainda na memória)

            //Adiciona ao BD
            _context.SaveChanges();

            return CreatedAtAction(  // Retorna HTTP 201 Created
                nameof(GetById),  // Informa que o recurso pode ser acessado via GetById
                new { id = salaEquipamento.IdSalaEquipamento }, salaEquipamento // Passa o ID recém-criado e retorna o proprio objeto criado (salaEquipamento)

            );
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteSalaEquipameto(int id)
        {
            var salaEquipamento = _context.SalaEquipamentos.Find(id); // Busca o item pelo ID
            if (salaEquipamento == null)
            {
                return NotFound("Registro não encontrado!");
            }

            _context.SalaEquipamentos.Remove(salaEquipamento); // Remove o item do contexto
            _context.SaveChanges();                 // Salva a exclusão no banco

            return NoContent();                     // Retorna HTTP 204 No Content

        }





    }
}
