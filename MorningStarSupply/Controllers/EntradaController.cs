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

      
    }
}
