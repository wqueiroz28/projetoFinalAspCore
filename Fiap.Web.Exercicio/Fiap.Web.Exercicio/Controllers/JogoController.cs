using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Web.Exercicio.Models;
using Fiap.Web.Exercicio.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Exercicio.Controllers
{
    public class JogoController : Controller
    {
        private IJogoRepository _jogoRepository;
        private IGeneroRepository _generoRepository;

        public JogoController(IJogoRepository jogoRepository, IGeneroRepository generoRepository)
        {
            _jogoRepository = jogoRepository;
            _generoRepository = generoRepository;
        }

        [HttpGet]
        public IActionResult Buscar(int termoBusca)
        {
            CarregarGeneros();
            var lista = _jogoRepository.BuscarPor(c => c.GeneroId == termoBusca);
            return View("Listar", lista);
        }

        [HttpGet]
        public IActionResult Pesquisar(string termoBusca)
        {
            CarregarGeneros();
            var lista = _jogoRepository.BuscarPor(c => c.Nome.Contains(termoBusca));
            return View("Listar", lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarGeneros();
            return View();
        }

        private void CarregarGeneros()
        {
            var lista = _generoRepository.Listar();
            ViewBag.generos = new SelectList(lista, "GeneroId", "Nome");
        }

        [HttpPost]
        public IActionResult Cadastrar(Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                _jogoRepository.Cadastrar(jogo);
                _jogoRepository.Salvar();
                TempData["msg"] = "Cadastrado!";
                return RedirectToAction("Listar");
            }
            CarregarGeneros();
            return View();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            CarregarGeneros();
            return View(_jogoRepository.Listar());
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarGeneros();
            return View(_jogoRepository.BuscarPorCodigo(id));
        }

        [HttpPost]
        public IActionResult Editar(Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                _jogoRepository.Atualizar(jogo);
                _jogoRepository.Salvar();
                TempData["msg"] = "Atualizado";
                return RedirectToAction("Listar");
            }
            CarregarGeneros();
            return View();
        }

        [HttpPost]
        public IActionResult Excluir(int codigo)
        {
            _jogoRepository.Remover(codigo);
            _jogoRepository.Salvar();
            TempData["msg"] = "Removido!";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public IActionResult Disponibilizar(int jogoId)
        {
            _jogoRepository.Disponibilizar(jogoId);
            _jogoRepository.Salvar();
            TempData["msg"] = "Jogo disponibilizado";
            return RedirectToAction("Listar");
        }
    }
}