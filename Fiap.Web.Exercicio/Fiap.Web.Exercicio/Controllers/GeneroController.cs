using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Web.Exercicio.Models;
using Fiap.Web.Exercicio.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Exercicio.Controllers
{
    public class GeneroController : Controller
    {
        private IGeneroRepository _generoRepository;

        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Genero genero)
        {
            if (ModelState.IsValid)
            {
                _generoRepository.Cadastrar(genero);
                _generoRepository.Salvar();
                TempData["msg"] = "Cadastrado!";
                return RedirectToAction("Cadastrar");
            }
            return View();
        }
    }
}