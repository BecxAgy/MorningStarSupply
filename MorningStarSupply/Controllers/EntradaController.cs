using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MorningStarSupply.Models;
using MorningStarSupply.Repositories.Interfaces;

using System.Security.Cryptography;

namespace MorningStarSupply.Controllers
{
    public class EntradaController : Controller
    {
        private readonly IEntradaRepository repository;
        private readonly IWebHostEnvironment _webHostEnv;

   

        public EntradaController(IEntradaRepository repository, IWebHostEnvironment webHostEnv)
        {
            this.repository = repository;
            _webHostEnv = webHostEnv;
        }

        public IActionResult List()
        {
            var listaEntradas = repository.Entradas;
            return View(listaEntradas);
        }

        public IActionResult Create()
        {
            ViewBag.Mercadorias = repository.GetListMercadorias().Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.NumeroRegistro.ToString() }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Entrada novaEntrada)
        {
            //valida?

            if (ModelState.IsValid)
            {
                
                repository.AddToEntradas(novaEntrada);
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
        public async Task<IActionResult> Edit(int id, Entrada entrada)
        {
            if (id != entrada.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await repository.Update(entrada);
            }

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)

                return NotFound();
            var entrada = await repository.FindByIdAsync(id);

            if (entrada == null)
                return NotFound();

            return View(entrada);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {

            var entrada = await repository.FindByIdAsync(id);
            await repository.Delete(entrada);


            return RedirectToAction("List");
        }


    }
}
