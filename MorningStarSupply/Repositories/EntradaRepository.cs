using Microsoft.EntityFrameworkCore;
using MorningStarSupply.Context;
using MorningStarSupply.Models;
using MorningStarSupply.Repositories.Interfaces;

namespace MorningStarSupply.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly AppDbContext _context;

        public EntradaRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Entrada> Entradas => _context.Entradas;

        public IEnumerable<Mercadoria> Mercadorias => _context.Mercadorias;

        public IEnumerable<Mercadoria> GetListMercadorias()
        {
            return _context.Mercadorias.ToList();
        }

        public void AddToEntradas(Entrada entrada)
        {
            
            _context.Entradas.Add(entrada);
            _context.SaveChanges();
        }

        public async Task Delete(Entrada entrada)
        {
            _context.Entradas.Remove(entrada);
            await _context.SaveChangesAsync();
        }

        public async Task<Entrada> FindByIdAsync(int? id)
        {
            var entrada = await _context.Entradas.FirstOrDefaultAsync(m => m.Id == id);


            return entrada;
        }

        public async Task Update(Entrada entrada)
        {

            _context.Entradas.Update(entrada);
            await _context.SaveChangesAsync();
        }



   
       

    

        
    }
}
