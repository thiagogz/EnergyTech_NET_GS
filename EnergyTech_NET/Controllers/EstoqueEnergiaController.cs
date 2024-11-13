using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EstoqueEnergiaController : ControllerBase
    {
        private readonly IEstoqueEnergiaRepository estoqueEnergiaRepository;

        public EstoqueEnergiaController(IEstoqueEnergiaRepository estoqueEnergiaRepository)
        {
            this.estoqueEnergiaRepository = estoqueEnergiaRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de estoques de energia
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAppEstoqueEnergia>>> GetEstoquesEnergia()
        {
            try
            {
                return Ok(await estoqueEnergiaRepository.GetEstoquesEnergia());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna o estoque de energia com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbAppEstoqueEnergia>> GetEstoqueEnergia(decimal id)
        {
            try
            {
                var result = await estoqueEnergiaRepository.GetEstoqueEnergia(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de um novo estoque de energia
        /// </summary>
        /// <response code="201">Retorna o estoque de energia criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbAppEstoqueEnergia>> CreateEstoqueEnergia([FromBody] TbAppEstoqueEnergia estoqueEnergia)
        {
            try
            {
                if (estoqueEnergia == null) return BadRequest();

                var result = await estoqueEnergiaRepository.AddEstoqueEnergia(estoqueEnergia);

                return CreatedAtAction("GetEstoqueEnergia", new { id = estoqueEnergia.EstoqueId }, estoqueEnergia);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar dados no banco de dados: {ex.Message}");
            }
        }

        /// <summary>
        /// Altera o estoque de energia com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbAppEstoqueEnergia>> UpdateEstoqueEnergia(decimal id, [FromBody] TbAppEstoqueEnergia estoqueEnergia)
        {
            try
            {
                if (estoqueEnergia == null || estoqueEnergia.EstoqueId != id) return BadRequest();

                var existingEstoqueEnergia = await estoqueEnergiaRepository.GetEstoqueEnergia(id);
                if (existingEstoqueEnergia == null) return NotFound($"Estoque de energia com id = {id} não encontrado");

                return await estoqueEnergiaRepository.UpdateEstoqueEnergia(estoqueEnergia);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta o estoque de energia com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbAppEstoqueEnergia>> DeleteEstoqueEnergia(decimal id)
        {
            try
            {
                var result = await estoqueEnergiaRepository.GetEstoqueEnergia(id);
                if (result == null) return NotFound($"Estoque de energia com id = {id} não encontrado");

                await estoqueEnergiaRepository.DeleteEstoqueEnergia(id);

                return Ok("Estoque de energia deletado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
