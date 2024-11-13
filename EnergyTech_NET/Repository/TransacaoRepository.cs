using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnergyTech_NET.Data;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly DataContext dbContext;

        public TransacaoRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TbAppTransacao> GetTransacao(decimal transacaoId)
        {
            return await dbContext.Transacoes
                .Include(t => t.Cliente)
                .Include(t => t.Energia)
                .Include(t => t.Energia.Fornecedor)
                .FirstOrDefaultAsync(t => t.TransacaoId == transacaoId);
        }

        public async Task<IEnumerable<TbAppTransacao>> GetTransacoes()
        {
            return await dbContext.Transacoes
                .Include(t => t.Cliente)
                .Include(t => t.Energia)
                .ToListAsync();
        }

        public async Task<TbAppTransacao> AddTransacao(TbAppTransacao transacao)
        {
            var result = await dbContext.Transacoes.AddAsync(transacao);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbAppTransacao> UpdateTransacao(TbAppTransacao transacao)
        {
            var result = await dbContext.Transacoes.FirstOrDefaultAsync(t => t.TransacaoId == transacao.TransacaoId);
            if (result != null)
            {
                result.TipoTransacao = transacao.TipoTransacao;
                result.Quantidade = transacao.Quantidade;
                result.ValorTotal = transacao.ValorTotal;
                result.DataTransacao = transacao.DataTransacao;
                result.ClienteId = transacao.ClienteId;
                result.EnergiaId = transacao.EnergiaId;
                result.BlockchainHash = transacao.BlockchainHash;
                result.StatusBlockchain = transacao.StatusBlockchain;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteTransacao(decimal transacaoId)
        {
            var result = await dbContext.Transacoes.FirstOrDefaultAsync(t => t.TransacaoId == transacaoId);
            if (result != null)
            {
                dbContext.Transacoes.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
