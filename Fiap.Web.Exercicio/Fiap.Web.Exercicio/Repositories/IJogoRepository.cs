using Fiap.Web.Exercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Web.Exercicio.Repositories
{
    public interface IJogoRepository
    {
        void Cadastrar(Jogo jogo);
        void Atualizar(Jogo Jogo);
        void Remover(int id);
        IList<Jogo> Listar();
        Jogo BuscarPorCodigo(int id);
        IList<Jogo> BuscarPor(Expression<Func<Jogo, bool>> filtro);
        void Salvar();

        void Disponibilizar(int id);
    }
}
