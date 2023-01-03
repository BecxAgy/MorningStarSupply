using MorningStarSupply.Models;

namespace MorningStarSupply.Repositories.Interfaces
{
    public interface IMercadoriaRepository
    {
        IEnumerable<Mercadoria> Mercadorias { get; }
        void AddToMercadorias(Mercadoria mercadoria);

        IEnumerable<Mercadoria> GetListMercadorias();
        Task<Mercadoria> FindByIdAsync(int? id); 
        Task Update(Mercadoria mercadoria);

        Task Delete(Mercadoria mercadoria); 
    }
}
