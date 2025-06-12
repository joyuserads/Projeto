using Microsoft.AspNetCore.Mvc;
using projeto_webApi.Domains;
using projeto_webApi.Interfaces;
using projeto_webApi.Repositories;

namespace projeto_webApi.Controlers
{
    /// <summary>
    /// Controller responsável por gerenciar as operações relacionadas aos equipamentos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController] 
    public class EquipamentoController : Controller
    {
        private readonly IEquipamentos _equipamentoRepository; // Repositório de equipamentos

        /// <summary>
        /// Construtor que recebe o repositório de equipamentos
        /// </summary>
        /// <param name="repository"></param>
        public EquipamentoController(IEquipamentos repository)
        {
            _equipamentoRepository = repository; // Inicializa o repositório de equipamentos
        }

        /// <summary>
        /// Método responsável por adicionar um novo equipamento
        /// </summary>
        /// <returns>Adiciona um novo equipamento</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipamentos = await _equipamentoRepository.GetAllAsync(); // Busca todos os equipamentos
            return Ok(equipamentos); // Retorna a lista de equipamentos
        }

        /// <summary>
        /// Método responsável por buscar um equipamento pelo ID
        /// </summary>
        /// <param name="id">id do equipamento</param>
        /// <returns>busca um equipamento através do ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var equipamento = await _equipamentoRepository.GetByIdAsync(id); // Busca o equipamento pelo ID
            if (equipamento == null)
            {
                return NotFound(); // Retorna 404 se o equipamento não for encontrado
            }
            return Ok(equipamento); // Retorna o equipamento encontrado
        }

        [HttpPost]
        public async Task<IActionResult> Post(Equipamento equipamento)
        {
            if (equipamento == null)
            {
                return BadRequest("Equipamento não pode ser nulo."); // Retorna 400 se o equipamento for nulo
            }
            var novoEquipamento = await _equipamentoRepository.AddAsync(equipamento); // Adiciona o novo equipamento
            return CreatedAtAction(nameof(GetById), new { id = novoEquipamento.IdEquipamento }, novoEquipamento); // Retorna 201 com o novo equipamento
        }

        [HttpPut]
        public async Task<IActionResult> Put(Equipamento equipamento)
        {
            if (equipamento == null)
            {
                return BadRequest("Equipamento não pode ser nulo."); // Retorna 400 se o equipamento for nulo
            }
            var equipamentoAtualizado = await _equipamentoRepository.UpdateAsync(equipamento); // Atualiza o equipamento
            if (equipamentoAtualizado == null)
            {
                return NotFound(); // Retorna 404 se o equipamento não for encontrado
            }
            return Ok(equipamentoAtualizado); // Retorna o equipamento atualizado
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var equipamento = await _equipamentoRepository.DeleteAsync(id);
            if (!equipamento) return NotFound("Equipamento não encontrado!!"); // Retorna 404 se o equipamento não for encontrado
            return NoContent(); // Retorna 204 No Content se o equipamento foi deletado com sucesso
        }


       
    }
}
