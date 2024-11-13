using EnergyTech_NET.Models;

namespace EnergyTech_NET.Repository.Interface
{
    public interface IFornecedoresRepository
    {
        Task<IEnumerable<TbAppFornecedores>> GetFornecedores();
        Task<TbAppFornecedores> GetFornecedor(decimal fornecedorId);
        Task<TbAppFornecedores> AddFornecedor(TbAppFornecedores fornecedor);
        Task<TbAppFornecedores> UpdateFornecedor(TbAppFornecedores fornecedor);
        Task DeleteFornecedor(decimal fornecedorId);
    }
}
