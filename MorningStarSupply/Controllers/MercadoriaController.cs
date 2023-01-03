using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MorningStarSupply.Models;
using MorningStarSupply.Repositories;
using MorningStarSupply.Repositories.Interfaces;

namespace MorningStarSupply.Controllers
{
    public class MercadoriaController : Controller
    {
        private readonly IMercadoriaRepository _repository;

        public MercadoriaController(IMercadoriaRepository repository)
        {
            _repository = repository;
        }

        public IActionResult List()
        {
            var listaMercadorias = _repository.Mercadorias;
            return View(listaMercadorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            
                return NotFound();
            

            var mercadoria = await _repository.FindByIdAsync(id);

            if (mercadoria == null)
                return NotFound();

            return View(mercadoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Mercadoria mercadoria)
        {
            if(id != mercadoria.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _repository.Update(mercadoria);
            }

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)

                return NotFound();


            var mercadoria = await _repository.FindByIdAsync(id);

            if (mercadoria == null)
                return NotFound();

            return View(mercadoria);
        }

        [HttpPost,ActionName("Delete")] 
        public async Task<IActionResult> Delete(int id)
        {
   
            var mercadoria = await _repository.FindByIdAsync(id);
            await _repository.Delete(mercadoria);


            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Create(Mercadoria novaMercadoria)
        {
            //valida?
            if (ModelState.IsValid)
            {
                

                //existe igual?
                var igual = _repository.Mercadorias.FirstOrDefault(m => m.NumeroRegistro == novaMercadoria.NumeroRegistro);
                if (igual != null)
                
                    return RedirectToAction("Create");

                _repository.AddToMercadorias(novaMercadoria);
                return RedirectToAction("Create");
            }
            else
            {
                return View(novaMercadoria);
            }
        }

      
    }
}
