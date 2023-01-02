using Microsoft.AspNetCore.Mvc;
using MorningStarSupply.Models;
using MorningStarSupply.Services;

namespace MorningStarSupply.Controllers
{
    public class GraficoController : Controller
    {
        private readonly GraficoService _grafico;

        public GraficoController(GraficoService grafico)
        {
            _grafico = grafico ?? throw new ArgumentNullException(nameof(grafico));
        }




        [HttpGet]
        public IActionResult Index()
        {
            var mes = new List<string>();
            var quantidade = new List<int>();

            var mesSaida = new List<string>();
            var quantidadeSaida = new List<int>();


            var entradas = _grafico.GetQuantidadeMensalEntrada();
            var saidas = _grafico.GetQuantidadeMensalSaida();

            foreach (var n in entradas)
            {
                quantidade.Add(n.QuantidadeMercadoria);
                mes.Add(n.Mes);
            }

            ViewBag.QuantidadeEnt = quantidade;
            ViewBag.MesEnt = mes;

            foreach (var n in saidas)
            {
                quantidadeSaida.Add(n.QuantidadeMercadoria);
                mesSaida.Add(n.Mes);

            }

            ViewBag.QuantidadeSai = quantidadeSaida;
            ViewBag.MesSai = mesSaida;


            return View();
        }
    }
}
