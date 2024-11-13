using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnergyTech_NET.Data;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Repository
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly DataContext dbContext;

        public AuditLogRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TbAuditLog> GetAuditLog(decimal auditId)
        {
            return await dbContext.AuditLogs
                .FirstOrDefaultAsync(a => a.AuditId == auditId);
        }

        public async Task<IEnumerable<TbAuditLog>> GetAuditLogs()
        {
            return await dbContext.AuditLogs
                .ToListAsync();
        }

        public async Task<TbAuditLog> AddAuditLog(TbAuditLog auditLog)
        {
            var result = await dbContext.AuditLogs.AddAsync(auditLog);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbAuditLog> UpdateAuditLog(TbAuditLog auditLog)
        {
            var result = await dbContext.AuditLogs.FirstOrDefaultAsync(a => a.AuditId == auditLog.AuditId);
            if (result != null)
            {
                result.TableName = auditLog.TableName;
                result.ActionType = auditLog.ActionType;
                result.RecordId = auditLog.RecordId;
                result.ActionDate = auditLog.ActionDate;
                result.UserName = auditLog.UserName;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteAuditLog(decimal auditId)
        {
            var result = await dbContext.AuditLogs.FirstOrDefaultAsync(a => a.AuditId == auditId);
            if (result != null)
            {
                dbContext.AuditLogs.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
