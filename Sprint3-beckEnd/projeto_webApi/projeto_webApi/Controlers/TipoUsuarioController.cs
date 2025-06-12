
using Microsoft.AspNetCore.Mvc;
using projeto_webApi.Domains;
using projeto_webApi.Interfaces;
using projeto_webApi.Repositories;

namespace projeto_webApi.Controlers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoUsuarioController : Controller
    {
        private readonly ITipoUsuario _repository;

        public TipoUsuarioController(ITipoUsuario repository)
        {
            _repository = repository;
        }

        //http://localhost:5091/api/tipoUsuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoUsuario>>> GetAll()
        {
            var tipos = await _repository.GetAllAsync();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> GetById(int id)
        {
            var tipo = await _repository.GetByIdAsync(id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }


        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> Post(TipoUsuario tipo)
        {
            var novo = await _repository.AddAsync(tipo);
            return CreatedAtAction(nameof(GetById), new { id = novo.IdTipoUsuario }, novo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TipoUsuario tipo)
        {
            if (id != tipo.IdTipoUsuario) return BadRequest();
            var atualizado = await _repository.UpdateAsync(tipo);
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _repository.DeleteAsync(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }

       
        
    }
}
