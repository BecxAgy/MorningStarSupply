using MorningStarSupply.Models;

namespace MorningStarSupply.Repositories.Interfaces
{
    public interface ISaidaRepository
    {
        IEnumerable<Saida> Saidas { get; }

        IEnumerable<Mercadoria> Mercadorias { get; }

        IEnumerable<Mercadoria> GetListMercadorias();

        void AddToSaidas(Saida saida);

        Task<Saida> FindByIdAsync(int? id);
        Task Update(Saida saida);

        Task Delete(Saida saida);
    }
}
