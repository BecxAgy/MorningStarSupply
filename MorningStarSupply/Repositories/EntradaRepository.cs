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
        
    

        /// <summary>
        ///Função que retorna o objeto retornado para identificar qual id da mercadoria que irá para tabela Entradas
        /// </summary>
        /// <param name="mercadoriaSelect"></param>
        /// <returns></returns>
        public Mercadoria getEntradaById(Mercadoria mercadoriaSelect) => _context.Mercadorias.FirstOrDefault(m => m.Id == mercadoriaSelect.Id);

    

        
    }
}
