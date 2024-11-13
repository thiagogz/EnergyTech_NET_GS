using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnergiaController : ControllerBase
    {
        private readonly IEnergiaRepository energiaRepository;

        public EnergiaController(IEnergiaRepository energiaRepository)
        {
            this.energiaRepository = energiaRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de energias
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAppEnergia>>> GetEnergias()
        {
            try
            {
                return Ok(await energiaRepository.GetEnergias());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna a energia com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbAppEnergia>> GetEnergia(decimal id)
        {
            try
            {
                var result = await energiaRepository.GetEnergia(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de uma nova energia
        /// </summary>
        /// <response code="201">Retorna a energia criada</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbAppEnergia>> CreateEnergia([FromBody] TbAppEnergia energia)
        {
            try
            {
                if (energia == null) return BadRequest();

                var result = await energiaRepository.AddEnergia(energia);

                return CreatedAtAction("GetEnergia", new { id = energia.EnergiaId }, energia);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar dados no banco de dados: {ex.Message}");
            }
        }

        /// <summary>
        /// Altera a energia com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbAppEnergia>> UpdateEnergia(decimal id, [FromBody] TbAppEnergia energia)
        {
            try
            {
                if (energia == null || energia.EnergiaId != id) return BadRequest();

                var existingEnergia = await energiaRepository.GetEnergia(id);
                if (existingEnergia == null) return NotFound($"Energia com id = {id} não encontrada");

                return await energiaRepository.UpdateEnergia(energia);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta a energia com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbAppEnergia>> DeleteEnergia(decimal id)
        {
            try
            {
                var result = await energiaRepository.GetEnergia(id);
                if (result == null) return NotFound($"Energia com id = {id} não encontrada");

                await energiaRepository.DeleteEnergia(id);

                return Ok("Energia deletada com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
