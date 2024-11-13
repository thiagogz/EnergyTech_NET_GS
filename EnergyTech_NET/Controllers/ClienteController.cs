using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de clientes
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAppCliente>>> GetClientes()
        {
            try
            {
                return Ok(await clienteRepository.GetClientes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna o cliente com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbAppCliente>> GetCliente(decimal id)
        {
            try
            {
                var result = await clienteRepository.GetCliente(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de um novo cliente
        /// </summary>
        /// <response code="201">Retorna o cliente criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbAppCliente>> CreateCliente([FromBody] TbAppCliente cliente)
        {
            try
            {
                if (cliente == null) return BadRequest();

                var result = await clienteRepository.AddCliente(cliente);

                return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar dados no banco de dados: {ex.Message}");
            }
        }

        /// <summary>
        /// Altera o cliente com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbAppCliente>> UpdateCliente(decimal id, [FromBody] TbAppCliente cliente)
        {
            try
            {
                if (cliente == null || cliente.ClienteId != id) return BadRequest();

                var existingCliente = await clienteRepository.GetCliente(id);
                if (existingCliente == null) return NotFound($"Cliente com id = {id} não encontrado");

                return await clienteRepository.UpdateCliente(cliente);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta o cliente com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult<TbAppCliente>> DeleteCliente(decimal id)
        {
            try
            {
                var result = await clienteRepository.GetCliente(id);
                if (result == null) return NotFound($"Cliente com id = {id} não encontrado");

                await clienteRepository.DeleteCliente(id);

                return Ok("Cliente deletado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
