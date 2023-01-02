using MorningStarSupply.Context;
using MorningStarSupply.Models;
using MorningStarSupply.Repositories.Interfaces;

namespace MorningStarSupply.Repositories
{
    public class MercadoriaRepository : IMercadoriaRepository
    {
        private readonly AppDbContext _context;

        public MercadoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Mercadoria> Mercadorias => _context.Mercadorias;
        public void AddToMercadorias(Mercadoria mercadoria) 
        { 
            _context.Mercadorias.Add(mercadoria);
            _context.SaveChanges();
        }

        public IEnumerable<Mercadoria> GetListMercadorias()
        {
            return _context.Mercadorias.ToList();
        }
    }
}
