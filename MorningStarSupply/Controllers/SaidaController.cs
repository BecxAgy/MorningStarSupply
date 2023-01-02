
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MorningStarSupply.Models;
using MorningStarSupply.Repositories.Interfaces;

namespace MorningStarSupply.Controllers
{
    public class SaidaController : Controller
    {
        private readonly ISaidaRepository repository;

        public SaidaController(ISaidaRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult List()
        {
            var listaSaidas = repository.Saidas;
            return View(listaSaidas);
        }

        public IActionResult Create()
        {
            ViewBag.Mercadorias = repository.GetListMercadorias().Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.NumeroRegistro.ToString() }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Saida novaSaida)
        {
            //valida?

            if (ModelState.IsValid)
            {

                repository.AddToSaidas(novaSaida);
                return RedirectToAction("Create");


            }
            else

                return RedirectToAction("Create");



        }


    }
}
