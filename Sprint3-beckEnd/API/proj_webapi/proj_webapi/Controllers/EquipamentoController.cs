using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proj_webapi.Data;
using proj_webapi.Models;

namespace proj_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        // 
        private readonly AppDbContext _context;

        // 
        public EquipamentoController(AppDbContext context) 
        {
            _context = context;
            
        }

        /// <summary>
        /// Metódo para buscar equipamentos
        /// </summary>
        /// <returns>retorna todas os equiapmentos status code = 200</returns>
        [HttpGet]
        public ActionResult<List<Equipamento>> GetByEquipamentos()
        {  
            // criando variavel para acessar o contexto
            var equipamentos = _context.Equipamentos.ToList();

            // retorna status code 200
            return Ok(equipamentos);

        }

        /// <summary>
        /// Busca um equipamento através do id
        /// </summary>
        /// <param name="id">id do equipamento</param>
        /// <returns>retorna o equipamento pelo ID</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Equipamento> GetEquipamentoById(int id) 
        {
            //busca equipamentos pelo id
            var equipamentos = _context.Equipamentos.Find(id);

            if (equipamentos == null) 
            {
                return NotFound("Equipamento não encontrado!");         
            }
            return Ok(equipamentos);
        }

        /// <summary>
        /// Cria um novo equipamento
        /// </summary>
        /// <param name="equipamento"></param>
        /// <returns>retorna um novo equipamento criado STATUS CODE 201 (CreatedAtAction) </returns>
        [HttpPost]
        public ActionResult<Equipamento> PostEquipamentos(Equipamento equipamento)
        {
            if (equipamento == null)
            {
                return BadRequest("Equipamento não pode ser nulo!!!");
            }
            //Adicionando equipamentos ao contexto
            _context.Equipamentos.Add(equipamento);

            //Salvando no bd
            _context.SaveChanges();

            //retorna status code 201 buscando o método GetBySalas
            return CreatedAtAction(nameof(GetByEquipamentos), new { id = equipamento.IdEquipamento }, equipamento);

        }

        /// <summary>
        /// Atualiza um equipamento existente
        /// </summary>
        /// <param name="equipamento">equipamento</param>
        /// <param name="id">id do equipamento existente</param>
        /// <returns>Retorna um equipamento existente através do ID</returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult PutEquipamentoById(Equipamento equipamento, int id)
        {
            // Verifica se o id do equipamento é diferente do id passado como parâmetro]
            var equipamentoExistente = _context.Equipamentos.Find(id);

            if (equipamentoExistente == null)
            {
                // Se Equipamento nao existir retorna: Status code 404
                return NotFound("Equipamento não encontrado!");
            }

            // atualizando dados de equipamento existente com novos dados
            equipamentoExistente.Marca = equipamento.Marca;
            equipamentoExistente.Descricao = equipamento.Descricao;
            equipamentoExistente.NumeroPatrimonio = equipamento.NumeroPatrimonio;
            equipamentoExistente.TipoEquipamento = equipamento.TipoEquipamento;
            equipamentoExistente.Disponivel = equipamento.Disponivel;

            // Atualiza equipamentos no contexto
            _context.Equipamentos.Update(equipamentoExistente);

            // Salva no BD
            _context.SaveChanges();


            // Retorna status code 204/ não precisa retornar nenhum conteúdo além do status de sucesso.
            return NoContent();

        }

        /// <summary>
        /// Deleta um equipamento
        /// </summary>
        /// <param name="id">id do equipamento deletado</param>
        /// <returns>retorna um equipamento deletado através do ID</returns>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteEquipamentoById(int id)
        {
            // Buscando equipamento pelo ID
            var equipamentos = _context.Equipamentos.Find(id);

            // Se a equipamento não existir, retorna status code 404 (NotFound)
            if (equipamentos == null)
            {
                return NotFound("Equipamento não encontrado!");
            }

            // Remove o equipamento do contexto
            _context.Equipamentos.Remove(equipamentos);

            // Salva as alterações no BD
            _context.SaveChanges();

            // Retorna status code 204 (NoContent)/ não precisa retornar nenhum conteúdo além do status de sucesso.
            return NoContent();
        }


    }
}
