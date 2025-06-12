using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proj_webapi.Data;
using proj_webapi.Models;

namespace proj_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SalaController : ControllerBase
    {
        private readonly AppDbContext _context;
        //aplicando uma injeção de dependencia para trazr o DbContext
        public SalaController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metódo para buscar salas
        /// </summary>
        /// <returns>retorna todas as salas statu code = 200</returns>
        [HttpGet]
        public ActionResult<List<Sala>> GetBySalas()
        {
            //criando variavel de salas para acessar o contexto
            var salas = _context.Salas.ToList();

            // retorna status code 200
            return Ok(salas);

        }

        /// <summary>
        /// Método para buscar uma sala pelo id
        /// </summary>
        /// <param name="id">id da sala</param>
        /// <returns>Retorna a sala buscada pelo ID</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Sala> GetBySalasId(int id)
        {
            //busca a sala pelo id
            var sala = _context.Salas.Find(id);
            //se a sala for igual a nulo
            if (sala == null)
            {
                //retorna status code 404
                return NotFound("Sala não encontrada");
            }
            //retorna status code 200
            return Ok(sala);
        }

        [HttpPost]
        public ActionResult<Sala> PostSala(Sala sala)
        {
            // se sala for igual a nulo
            if (sala == null)
            {
                //retorna status code 404
                return BadRequest("Sala não pode ser nula");
            }

            //adiciona a sala
            _context.Salas.Add(sala);

            //Salva as alterações no BD
            _context.SaveChanges();

            //retorna status code 201 buscando o método GetBySalas
            return CreatedAtAction(nameof(GetBySalas), new { id = sala.IdSala }, sala);


        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult PutSalas(Sala sala, int id)
        {
            // Verifica se o id da sala é diferente do id passado como parâmetro
            var salaExistente = _context.Salas.Find(id);

            if (salaExistente == null)
            {
                // Se a sala não existir, retorna status code 404
                return NotFound("Sala não encontrada");
            }

            // Atualiza os dados da sala existente com os novos dados
            salaExistente.Andar = sala.Andar;
            salaExistente.Metragem = sala.Metragem;
            salaExistente.Nome = sala.Nome;

            // Atualiza a sala no contexto
            _context.Salas.Update(salaExistente);

            // Salva as alterações no BD
            _context.SaveChanges();

            // Retorna status code 204/ não precisa retornar nenhum conteúdo além do status de sucesso.
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteSala(int id)
        {
            // Busca a sala pelo id
            var sala = _context.Salas.Find(id);
            // Se a sala não existir, retorna status code 404
            if (sala == null)
            {
                return NotFound("Sala não encontrada");
            }

            // Remove a sala do contexto
            _context.Salas.Remove(sala);

            // Salva as alterações no BD
            _context.SaveChanges();

            // Retorna status code 204/ não precisa retornar nenhum conteúdo além do status de sucesso.
            return NoContent();
        }
    }
}

        
