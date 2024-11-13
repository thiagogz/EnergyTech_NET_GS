using EnergyTech_NET.Models;

namespace EnergyTech_NET.Repository.Interface
{
    public interface IAuditLogRepository
    {
        Task<IEnumerable<TbAuditLog>> GetAuditLogs();
        Task<TbAuditLog> GetAuditLog(decimal auditId);
        Task<TbAuditLog> AddAuditLog(TbAuditLog auditLog);
        Task<TbAuditLog> UpdateAuditLog(TbAuditLog auditLog);
        Task DeleteAuditLog(decimal auditId);
    }
}
