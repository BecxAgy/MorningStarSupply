
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

        public async Task<IActionResult> Edit(int? id)
        {


            if (id == null)

                return NotFound();
            var mercadoria = await repository.FindByIdAsync(id);

            if (mercadoria == null)
                return NotFound();

            ViewBag.Mercadorias = repository.GetListMercadorias().Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.NumeroRegistro.ToString() }).ToList();

            return View(mercadoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Saida saida)
        {
            if (id != saida.Id)
                return NotFound();

            if (ModelState.IsValid)
            
                await repository.Update(saida);
            

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)

                return NotFound();
            var saida = await repository.FindByIdAsync(id);

            if (saida == null)
                return NotFound();

            return View(saida);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {

            var saida = await repository.FindByIdAsync(id);
            await repository.Delete(saida);


            return RedirectToAction("List");
        }


    }
}
