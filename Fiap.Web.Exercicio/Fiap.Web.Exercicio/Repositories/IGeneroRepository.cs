using Fiap.Web.Exercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Web.Exercicio.Repositories
{
    public interface IGeneroRepository
    {
        void Cadastrar(Genero genero);
        void Atualizar(Genero genero);
        void Remover(int id);
        IList<Genero> Listar();
        Genero BuscarPorCodigo(int id);
        IList<Genero> BuscarPor(Expression<Func<Genero, bool>> filtro);
        void Salvar();
    }
}
