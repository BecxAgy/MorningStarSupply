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

        /// <summary>
        ///Função que retorna o objeto retornado para identificar qual id da mercadoria que irá para tabela Entradas
        /// </summary>
        /// <param name="mercadoriaSelect"></param>
        /// <returns></returns>
        public Mercadoria getEntradaById(Mercadoria mercadoriaSelect) => _context.Mercadorias.FirstOrDefault(m => m.Id == mercadoriaSelect.Id);
    }
}
