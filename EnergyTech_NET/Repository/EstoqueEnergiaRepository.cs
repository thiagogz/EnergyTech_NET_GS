using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnergyTech_NET.Data;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Repository
{
    public class EstoqueEnergiaRepository : IEstoqueEnergiaRepository
    {
        private readonly DataContext dbContext;

        public EstoqueEnergiaRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TbAppEstoqueEnergia> GetEstoqueEnergia(decimal estoqueId)
        {
            return await dbContext.EstoqueEnergia
                .Include(ee => ee.Energia)
                .Include(ee => ee.Energia.Fornecedor)
                .FirstOrDefaultAsync(ee => ee.EstoqueId == estoqueId);
        }

        public async Task<IEnumerable<TbAppEstoqueEnergia>> GetEstoquesEnergia()
        {
            return await dbContext.EstoqueEnergia
                .Include(ee => ee.Energia)
                .Include(ee => ee.Energia.Fornecedor)
                .ToListAsync();
        }

        public async Task<TbAppEstoqueEnergia> AddEstoqueEnergia(TbAppEstoqueEnergia estoqueEnergia)
        {
            var result = await dbContext.EstoqueEnergia.AddAsync(estoqueEnergia);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbAppEstoqueEnergia> UpdateEstoqueEnergia(TbAppEstoqueEnergia estoqueEnergia)
        {
            var result = await dbContext.EstoqueEnergia.FirstOrDefaultAsync(ee => ee.EstoqueId == estoqueEnergia.EstoqueId);
            if (result != null)
            {
                result.EnergiaId = estoqueEnergia.EnergiaId;
                result.DispositivoId = estoqueEnergia.DispositivoId;
                result.QuantidadeArmazenada = estoqueEnergia.QuantidadeArmazenada;
                result.DataAtualizacao = estoqueEnergia.DataAtualizacao;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteEstoqueEnergia(decimal estoqueId)
        {
            var result = await dbContext.EstoqueEnergia.FirstOrDefaultAsync(ee => ee.EstoqueId == estoqueId);
            if (result != null)
            {
                dbContext.EstoqueEnergia.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
