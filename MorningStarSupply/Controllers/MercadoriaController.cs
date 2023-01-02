﻿using Microsoft.AspNetCore.Mvc;
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
