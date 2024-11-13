using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogRepository auditLogRepository;

        public AuditLogController(IAuditLogRepository auditLogRepository)
        {
            this.auditLogRepository = auditLogRepository;
        }

        /// <summary>
        /// Retorna a tabela completa de logs de auditoria
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAuditLog>>> GetAuditLogs()
        {
            try
            {
                var logs = await auditLogRepository.GetAuditLogs();
                return Ok(logs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Retorna o log de auditoria com o id especificado
        /// </summary>
        [HttpGet("{id:decimal}")]
        public async Task<ActionResult<TbAuditLog>> GetAuditLog(decimal id)
        {
            try
            {
                var result = await auditLogRepository.GetAuditLog(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        /// <summary>
        /// Inserção de um novo log de auditoria
        /// </summary>
        /// <response code="201">Retorna o log de auditoria criado</response>
        /// <response code="400">Se o Request for enviado nulo</response>
        /// <response code="500">Se houver algum erro no banco de dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TbAuditLog>> CreateAuditLog([FromBody] TbAuditLog auditLog)
        {
            try
            {
                if (auditLog == null) return BadRequest();

                var result = await auditLogRepository.AddAuditLog(auditLog);

                return CreatedAtAction("GetAuditLog", new { id = auditLog.AuditId }, auditLog);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar dados no banco de dados: {ex.Message}");
            }
        }

        /// <summary>
        /// Altera o log de auditoria com o id especificado
        /// </summary>
        [HttpPut("{id:decimal}")]
        public async Task<ActionResult<TbAuditLog>> UpdateAuditLog(decimal id, [FromBody] TbAuditLog auditLog)
        {
            try
            {
                if (auditLog == null || auditLog.AuditId != id) return BadRequest();

                var existingAuditLog = await auditLogRepository.GetAuditLog(id);
                if (existingAuditLog == null) return NotFound($"Log de auditoria com id = {id} não encontrado");

                return await auditLogRepository.UpdateAuditLog(auditLog);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        /// <summary>
        /// Deleta o log de auditoria com o id especificado
        /// </summary>
        [HttpDelete("{id:decimal}")]
        public async Task<ActionResult> DeleteAuditLog(decimal id)
        {
            try
            {
                var result = await auditLogRepository.GetAuditLog(id);
                if (result == null) return NotFound($"Log de auditoria com id = {id} não encontrado");

                await auditLogRepository.DeleteAuditLog(id);

                return Ok("Log de auditoria deletado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }
    }
}
