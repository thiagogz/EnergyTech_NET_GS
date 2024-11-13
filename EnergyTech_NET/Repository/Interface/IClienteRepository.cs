using EnergyTech_NET.Models;

namespace EnergyTech_NET.Repository.Interface
{
    public interface IClienteRepository
    {
        Task<IEnumerable<TbAppCliente>> GetClientes();
        Task<TbAppCliente> GetCliente(decimal clienteId);
        Task<TbAppCliente> AddCliente(TbAppCliente cliente);
        Task<TbAppCliente> UpdateCliente(TbAppCliente cliente);
        Task DeleteCliente(decimal clienteId);
    }
}
