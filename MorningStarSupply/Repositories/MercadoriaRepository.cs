using Microsoft.EntityFrameworkCore;
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

        public async Task Delete(Mercadoria mercadoria)
        {
            _context.Mercadorias.Remove(mercadoria);
            await _context.SaveChangesAsync();
        }

        public async Task<Mercadoria> FindByIdAsync(int? id)
        {
            var mercadoria = await _context.Mercadorias.FirstOrDefaultAsync(m => m.Id == id);


            return mercadoria;
        }

        public IEnumerable<Mercadoria> GetListMercadorias()
        {
            return _context.Mercadorias.ToList();
        }

        public async Task Update(Mercadoria mercadoria)
        {
          
                _context.Mercadorias.Update(mercadoria);
                await _context.SaveChangesAsync();
        }
    }
}
