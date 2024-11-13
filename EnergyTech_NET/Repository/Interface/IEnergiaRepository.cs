using EnergyTech_NET.Models;

namespace EnergyTech_NET.Repository.Interface
{
    public interface IEnergiaRepository
    {
        Task<IEnumerable<TbAppEnergia>> GetEnergias();
        Task<TbAppEnergia> GetEnergia(decimal energiaId);
        Task<TbAppEnergia> AddEnergia(TbAppEnergia energia);
        Task<TbAppEnergia> UpdateEnergia(TbAppEnergia energia);
        Task DeleteEnergia(decimal energiaId);
    }
}
