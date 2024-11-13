using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnergyTech_NET.Data;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Repository
{
    public class FornecedoresRepository : IFornecedoresRepository
    {
        private readonly DataContext dbContext;

        public FornecedoresRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TbAppFornecedores> GetFornecedor(decimal fornecedorId)
        {
            return await dbContext.Fornecedores
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }

        public async Task<IEnumerable<TbAppFornecedores>> GetFornecedores()
        {
            return await dbContext.Fornecedores
                .ToListAsync();
        }

        public async Task<TbAppFornecedores> AddFornecedor(TbAppFornecedores fornecedor)
        {
            var result = await dbContext.Fornecedores.AddAsync(fornecedor);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbAppFornecedores> UpdateFornecedor(TbAppFornecedores fornecedor)
        {
            var result = await dbContext.Fornecedores.FirstOrDefaultAsync(f => f.FornecedorId == fornecedor.FornecedorId);
            if (result != null)
            {
                result.Nome = fornecedor.Nome;
                result.Email = fornecedor.Email;
                result.SenhaHash = fornecedor.SenhaHash;
                result.Telefone = fornecedor.Telefone;
                result.Endereco = fornecedor.Endereco;
                result.DataCadastro = fornecedor.DataCadastro;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteFornecedor(decimal fornecedorId)
        {
            var result = await dbContext.Fornecedores.FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
            if (result != null)
            {
                dbContext.Fornecedores.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}