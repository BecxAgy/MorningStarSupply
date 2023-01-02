using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MorningStarSupply.Context;
using MorningStarSupply.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MorningStarSupply.Services
{
    public class GraficoService
    {
        private readonly AppDbContext _context;

        public GraficoService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Grafico> GetQuantidadeMensalEntrada()
        {

            var cultura = new CultureInfo("pt-BR");
            var entradas = from e in _context.Entradas
                           where e.DataHora.Year >= DateTime.Now.Year
                           group e by new { e.DataHora.Month}
                           into g
                           select new
                           {
                               Data = cultura.DateTimeFormat.GetMonthName(g.Key.Month),
                               QuantidadeMercadoria = g.Sum(a => a.Quantidade)
                           };

            var lista = new List<Grafico>();
            //preenchendo a lista que vai ser retornada
            foreach(var item in entradas)
            {
                var entrada = new Grafico();
                entrada.Mes = item.Data;
                entrada.QuantidadeMercadoria = item.QuantidadeMercadoria;
                lista.Add(entrada);
            }

            return lista;
        }

        public IEnumerable<Grafico> GetQuantidadeMensalSaida()
        {

            var cultura = new CultureInfo("pt-BR");
            var saidas = from e in _context.Saidas
                           where e.DataHora.Year >= DateTime.Now.Year
                           group e by new { e.DataHora.Month }
                           into g
                           select new
                           {
                               Data = cultura.DateTimeFormat.GetMonthName(g.Key.Month),
                               QuantidadeMercadoria = g.Sum(a => a.Quantidade)
                           };

            var lista = new List<Grafico>();
            //preenchendo a lista que vai ser retornada
            foreach (var item in saidas)
            {
                var saida = new Grafico();
                saida.Mes = item.Data;
                saida.QuantidadeMercadoria = item.QuantidadeMercadoria;
                lista.Add(saida);
            }

            return lista;
        }
    }
}
