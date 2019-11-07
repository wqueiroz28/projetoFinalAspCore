using Fiap.Web.Exercicio.Contexts;
using Fiap.Web.Exercicio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Web.Exercicio.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private GameStoreContext _context;

        public JogoRepository(GameStoreContext context)
        {
            _context = context;
        }

        public void Atualizar(Jogo jogo)
        {
            _context.Jogos.Update(jogo);
        }

        public IList<Jogo> BuscarPor(Expression<Func<Jogo, bool>> filtro)
        {
            return _context.Jogos.Where(filtro).Include(c => c.Genero).ToList();
        }

        public Jogo BuscarPorCodigo(int id)
        {
            return _context.Jogos.Find(id);
        }

        public void Cadastrar(Jogo jogo)
        {
            _context.Jogos.Add(jogo);
        }

        public void Disponibilizar(int id)
        {
            var jogo = _context.Jogos.Find(id);
            jogo.Disponivel = true;
            _context.Jogos.Update(jogo);
        }

        public IList<Jogo> Listar()
        {
            return _context.Jogos.Include(c => c.Genero).ToList();
        }

        public void Remover(int id)
        {
            var jogo = _context.Jogos.Find(id);
            _context.Jogos.Remove(jogo);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
