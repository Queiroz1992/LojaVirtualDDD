using AplicacaoApp.Interfaces;
using Dominio.Interfaces.InterfaceProduto;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoApp.AbrirApp
{
    public class AppProduto : InterfaceProdutoApp
    {
        IProduto _IProduto;
        IServicoProduto _IServicoProduto;

        public AppProduto(IProduto IProduto, IServicoProduto IServicoProduto)
        {
            _IProduto = IProduto;
            _IServicoProduto = IServicoProduto;
        }

        public async Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId)
        {
            return await _IProduto.ListarProdutosCarrinhoUsuario(userId);
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            return await _IProduto.ObterProdutoCarrinho(idProdutoCarrinho);
        }

        public async Task AdicionarProduto(Produto produto)
        {
            await _IServicoProduto.AdicionarProduto(produto);
        }

        public async Task AtualizarProduto(Produto produto)
        {
            await _IServicoProduto.AtualizarProduto(produto);
        }

        public async Task<List<Produto>> ListarProdutosUsuario(string userId)
        {
            return await _IProduto.ListarProdutoUsuario(userId);
        }

        public async Task Adicionar(Produto Objeto)
        {
            await _IProduto.Adicionar(Objeto);
        }

        public async Task Atualizar(Produto Objeto)
        {
            await _IProduto.Atualizar(Objeto);
        }

        public async Task Excluir(Produto Objeto)
        {
            await _IProduto.Excluir(Objeto);
        }

        public async Task<List<Produto>> List()
        {
            return await _IProduto.List();
        }

        public async Task<Produto> ObterEntidadePorId(int Id)
        {
            return await _IProduto.ObterEntidadePorId(Id);
        }

        public async Task<List<Produto>> ListarProdutosComEstoque()
        {
            return await _IServicoProduto.ListarProdutosComEstoque();
        }
    }
}
