using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface IServicoProduto
    {
        Task AdicionarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);

        Task<List<Produto>> ListarProdutosComEstoque();
    }
}
