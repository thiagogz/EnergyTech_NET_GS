using EnergyTech_NET.Models;

namespace EnergyTech_NET.Repository.Interface
{
    public interface IEstoqueEnergiaRepository
    {
        Task<IEnumerable<TbAppEstoqueEnergia>> GetEstoquesEnergia();
        Task<TbAppEstoqueEnergia> GetEstoqueEnergia(decimal estoqueId);
        Task<TbAppEstoqueEnergia> AddEstoqueEnergia(TbAppEstoqueEnergia estoqueEnergia);
        Task<TbAppEstoqueEnergia> UpdateEstoqueEnergia(TbAppEstoqueEnergia estoqueEnergia);
        Task DeleteEstoqueEnergia(decimal estoqueId);
    }
}