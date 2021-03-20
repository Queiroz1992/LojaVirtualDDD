using Dominio.Interfaces.Generics;
using Entidades.Entidades;
using Entidades.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceCompraUsuario
{
    public interface ICompraUsuario : IGeneric<CompraUsuario>
    {
        public Task<int> QuantidadeProdutoCarrinhoUsuario(string userId);

        public Task<CompraUsuario> ProdutosCompradosPorEstado(string userId, EstadoCompra estado);

        public Task<bool> ConfirmaCompraCarrinhoUsuario(string useId);
    }
}
