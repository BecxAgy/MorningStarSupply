using Microsoft.EntityFrameworkCore;
using MorningStarSupply.Context;
using MorningStarSupply.Models;
using MorningStarSupply.Repositories.Interfaces;

namespace MorningStarSupply.Repositories
{
    public class SaidaRepository : ISaidaRepository
    {
        private readonly AppDbContext _context;

        public SaidaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Saida> Saidas => _context.Saidas;
        public IEnumerable<Mercadoria> Mercadorias => _context.Mercadorias;

        public IEnumerable<Mercadoria> GetListMercadorias()
        {
            return _context.Mercadorias.ToList();
        }

        public void AddToSaidas(Saida saida)
        {

            _context.Saidas.Add(saida);
            _context.SaveChanges();
        }

        public async Task Delete(Saida saida)
        {
            _context.Saidas.Remove(saida);
            await _context.SaveChangesAsync();
        }

        public async Task<Saida> FindByIdAsync(int? id)
        {
            var saida = await _context.Saidas.FirstOrDefaultAsync(m => m.Id == id);


            return saida;
        }

        public async Task Update(Saida saida)
        {

            _context.Saidas.Update(saida);
            await _context.SaveChangesAsync();
        }

    }
}
