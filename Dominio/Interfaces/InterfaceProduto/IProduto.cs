using Dominio.Interfaces.Generics;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceProduto
{
    public interface IProduto : IGeneric<Produto>
    {
        Task<List<Produto>> ListarProdutoUsuario(string useId);

        Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto);

        Task<List<Produto>> ListarProdutosCarrinhoUsuario(string useId);

        Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho);
    }
}
