using Dominio.Interfaces.InterfaceCompraUsuario;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using Entidades.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoCompraUsuario : IServicoCompraUsuario
    {
        private readonly ICompraUsuario _ICompraUsuario;
        public ServicoCompraUsuario(ICompraUsuario ICompraUsuario)
        {
            _ICompraUsuario = ICompraUsuario;
        }

        public async Task<CompraUsuario> CarrinhoCompras(string userId)
        {
            return await _ICompraUsuario.ProdutosCompradosPorEstado(userId, EstadoCompra.Produto_Carrinho);
        }

        public async Task<CompraUsuario> ProdutosComprados(string userId)
        {
            return await _ICompraUsuario.ProdutosCompradosPorEstado(userId, EstadoCompra.Produto_Comprado);
        }
    }
}
