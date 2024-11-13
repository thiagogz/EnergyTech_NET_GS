using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoRepository transacaoRepository;

        public TransacaoController(ITransacaoRepository transacaoRepository)
        {
            this.transacaoRepository = transacaoRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de transações
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAppTransacao>>> GetTransacoes()
        {
            try
            {
                return Ok(await transacaoRepository.GetTransacoes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna a transação com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbAppTransacao>> GetTransacao(decimal id)
        {
            try
            {
                var result = await transacaoRepository.GetTransacao(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de uma nova transação
        /// </summary>
        /// <response code="201">Retorna a transação criada</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbAppTransacao>> CreateTransacao([FromBody] TbAppTransacao transacao)
        {
            try
            {
                if (transacao == null) return BadRequest();

                var result = await transacaoRepository.AddTransacao(transacao);

                return CreatedAtAction("GetTransacao", new { id = transacao.TransacaoId }, transacao);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar dados no banco de dados: {ex.Message}");
            }
        }

        /// <summary>
        /// Altera a transação com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbAppTransacao>> UpdateTransacao(decimal id, [FromBody] TbAppTransacao transacao)
        {
            try
            {
                if (transacao == null || transacao.TransacaoId != id) return BadRequest();

                var existingTransacao = await transacaoRepository.GetTransacao(id);
                if (existingTransacao == null) return NotFound($"Transação com id = {id} não encontrada");

                return await transacaoRepository.UpdateTransacao(transacao);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta a transação com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbAppTransacao>> DeleteTransacao(decimal id)
        {
            try
            {
                var result = await transacaoRepository.GetTransacao(id);
                if (result == null) return NotFound($"Transação com id = {id} não encontrada");

                await transacaoRepository.DeleteTransacao(id);

                return Ok("Transação deletada com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
