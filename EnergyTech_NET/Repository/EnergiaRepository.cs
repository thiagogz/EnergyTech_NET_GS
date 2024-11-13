using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnergyTech_NET.Data;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Repository
{
    public class EnergiaRepository : IEnergiaRepository
    {
        private readonly DataContext dbContext;

        public EnergiaRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TbAppEnergia> GetEnergia(decimal energiaId)
        {
            return await dbContext.Energia
                .Include(e => e.Fornecedor)
                .FirstOrDefaultAsync(e => e.EnergiaId == energiaId);
        }

        public async Task<IEnumerable<TbAppEnergia>> GetEnergias()
        {
            return await dbContext.Energia
                .Include(e => e.Fornecedor)
                .ToListAsync();
        }

        public async Task<TbAppEnergia> AddEnergia(TbAppEnergia energia)
        {
            var result = await dbContext.Energia.AddAsync(energia);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbAppEnergia> UpdateEnergia(TbAppEnergia energia)
        {
            var result = await dbContext.Energia.FirstOrDefaultAsync(e => e.EnergiaId == energia.EnergiaId);
            if (result != null)
            {
                result.TipoEnergia = energia.TipoEnergia;
                result.QuantidadeDisponivel = energia.QuantidadeDisponivel;
                result.PrecoUnitario = energia.PrecoUnitario;
                result.DataGeracao = energia.DataGeracao;
                result.FornecedorId = energia.FornecedorId;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteEnergia(decimal energiaId)
        {
            var result = await dbContext.Energia.FirstOrDefaultAsync(e => e.EnergiaId == energiaId);
            if (result != null)
            {
                dbContext.Energia.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
