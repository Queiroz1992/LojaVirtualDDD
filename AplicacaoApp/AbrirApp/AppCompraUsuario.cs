using AplicacaoApp.Interfaces;
using Dominio.Interfaces.InterfaceCompraUsuario;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoApp.AbrirApp
{
    public class AppCompraUsuario : InterfaceCompraUsuarioApp
    {
        private readonly ICompraUsuario _ICompraUsuario;

        private readonly IServicoCompraUsuario _IServicoCompraUsuario;

        public AppCompraUsuario(ICompraUsuario ICompraUsuario, IServicoCompraUsuario IServicoCompraUsuario)
        {
            _ICompraUsuario = ICompraUsuario;
            _IServicoCompraUsuario = IServicoCompraUsuario;
        }

        public async Task<CompraUsuario> CarrinhoCompras(string userId)
        {
            return await _IServicoCompraUsuario.CarrinhoCompras(userId);
        }

        public async Task<CompraUsuario> ProdutosComprados(string userId)
        {
            return await _IServicoCompraUsuario.ProdutosComprados(userId);
        }

        public async Task<bool> ConfirmaCompraCarrinhoUsuario(string userId)
        {
            return await _ICompraUsuario.ConfirmaCompraCarrinhoUsuario(userId);
        }

        public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
        {
            return await _ICompraUsuario.QuantidadeProdutoCarrinhoUsuario(userId);
        }

        public async Task Adicionar(CompraUsuario Objeto)
        {
            await _ICompraUsuario.Adicionar(Objeto);
        }

        public async Task Atualizar(CompraUsuario Objeto)
        {
            await _ICompraUsuario.Atualizar(Objeto);
        }

        public async Task Excluir(CompraUsuario Objeto)
        {
            await _ICompraUsuario.Excluir(Objeto);
        }

        public async Task<List<CompraUsuario>> List()
        {
            return await _ICompraUsuario.List();
        }

        public async Task<CompraUsuario> ObterEntidadePorId(int Id)
        {
            return await _ICompraUsuario.ObterEntidadePorId(Id);
        }
    }
}
