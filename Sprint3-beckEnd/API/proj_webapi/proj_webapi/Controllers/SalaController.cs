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
    }
}
