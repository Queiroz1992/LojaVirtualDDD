using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Generics
{
    public interface IGeneric<T> where T  : class
    {
        Task Adicionar(T Objeto);
        Task Atualizar(T Objeto);
        Task Excluir(T Objeto);
        Task<T> ObterEntidadePorId(int Id);
        Task<List<T>> List();
    }
}
