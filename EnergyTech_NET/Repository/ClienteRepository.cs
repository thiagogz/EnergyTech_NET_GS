using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnergyTech_NET.Data;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository.Interface;

namespace EnergyTech_NET.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext dbContext;

        public ClienteRepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TbAppCliente> GetCliente(decimal clienteId)
        {
            return await dbContext.Clientes
                .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
        }

        public async Task<IEnumerable<TbAppCliente>> GetClientes()
        {
            return await dbContext.Clientes
                .ToListAsync();
        }

        public async Task<TbAppCliente> AddCliente(TbAppCliente cliente)
        {
            var result = await dbContext.Clientes.AddAsync(cliente);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TbAppCliente> UpdateCliente(TbAppCliente cliente)
        {
            var result = await dbContext.Clientes.FirstOrDefaultAsync(c => c.ClienteId == cliente.ClienteId);
            if (result != null)
            {
                result.Nome = cliente.Nome;
                result.Email = cliente.Email;
                result.SenhaHash = cliente.SenhaHash;
                result.Telefone = cliente.Telefone;
                result.Endereco = cliente.Endereco;
                result.DataCadastro = cliente.DataCadastro;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task DeleteCliente(decimal clienteId)
        {
            var result = await dbContext.Clientes.FirstOrDefaultAsync(c => c.ClienteId == clienteId);
            if (result != null)
            {
                dbContext.Clientes.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
