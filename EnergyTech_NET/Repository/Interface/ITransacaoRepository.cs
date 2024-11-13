using EnergyTech_NET.Models;

namespace EnergyTech_NET.Repository.Interface
{
    public interface ITransacaoRepository
    {
        Task<IEnumerable<TbAppTransacao>> GetTransacoes();
        Task<TbAppTransacao> GetTransacao(decimal transacaoId);
        Task<TbAppTransacao> AddTransacao(TbAppTransacao transacao);
        Task<TbAppTransacao> UpdateTransacao(TbAppTransacao transacao);
        Task DeleteTransacao(decimal transacaoId);
    }
}
