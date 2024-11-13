using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedoresRepository fornecedoresRepository;

        public FornecedoresController(IFornecedoresRepository fornecedoresRepository)
        {
            this.fornecedoresRepository = fornecedoresRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de fornecedores
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAppFornecedores>>> GetFornecedores()
        {
            try
            {
                return Ok(await fornecedoresRepository.GetFornecedores());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna o fornecedor com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbAppFornecedores>> GetFornecedor(decimal id)
        {
            try
            {
                var result = await fornecedoresRepository.GetFornecedor(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de um novo fornecedor
        /// </summary>
        /// <response code="201">Retorna o fornecedor criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbAppFornecedores>> CreateFornecedor([FromBody] TbAppFornecedores fornecedor)
        {
            try
            {
                if (fornecedor == null) return BadRequest();

                var result = await fornecedoresRepository.AddFornecedor(fornecedor);

                return CreatedAtAction("GetFornecedor", new { id = fornecedor.FornecedorId }, fornecedor);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar dados no banco de dados: {ex.Message}");
            }
        }

        /// <summary>
        /// Altera o fornecedor com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbAppFornecedores>> UpdateFornecedor(decimal id, [FromBody] TbAppFornecedores fornecedor)
        {
            try
            {
                if (fornecedor == null || fornecedor.FornecedorId != id) return BadRequest();

                var existingFornecedor = await fornecedoresRepository.GetFornecedor(id);
                if (existingFornecedor == null) return NotFound($"Fornecedor com id = {id} não encontrado");

                return await fornecedoresRepository.UpdateFornecedor(fornecedor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta o fornecedor com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbAppFornecedores>> DeleteFornecedor(decimal id)
        {
            try
            {
                var result = await fornecedoresRepository.GetFornecedor(id);
                if (result == null) return NotFound($"Fornecedor com id = {id} não encontrado");

                await fornecedoresRepository.DeleteFornecedor(id);

                return Ok("Fornecedor deletado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
