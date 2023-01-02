using Microsoft.EntityFrameworkCore;
using MorningStarSupply.Context;
using MorningStarSupply.Models;

namespace MorningStarSupply.Services
{
    public class RelatorioService
    {
        private readonly AppDbContext _context;


        public RelatorioService(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Entrada>>  FindByDateAsync(DateTime? minDate, DateTime?  maxDate)
        {
            //consultando a lista de entradas usando iquery
            var resultado = from obj in _context.Entradas select obj;

            if (minDate.HasValue)
            {
                //refinando entradas que possuem o mês selecionado
                resultado = resultado.Where(e => e.DataHora >= minDate);
            }
            if (maxDate.HasValue)
            {
                //refinando entradas que possuem o mês selecionado
                resultado = resultado.Where(e => e.DataHora <= maxDate);
            }


            return await resultado
                .OrderBy(e=>e.DataHora)
                .ToListAsync();  
        }

        public async Task<IEnumerable<Saida>> FindSaidasByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            //consultando a lista de entradas usando iquery
            var resultado = from obj in _context.Saidas select obj;

            if (minDate.HasValue)
            {
                //refinando entradas que possuem o mês selecionado
                resultado = resultado.Where(e => e.DataHora >= minDate);
            }
            if (maxDate.HasValue)
            {
                //refinando entradas que possuem o mês selecionado
                resultado = resultado.Where(e => e.DataHora <= maxDate);
            }


            return await resultado
                .OrderBy(e => e.Id)
                .ToListAsync();
        }

       
    }
}
