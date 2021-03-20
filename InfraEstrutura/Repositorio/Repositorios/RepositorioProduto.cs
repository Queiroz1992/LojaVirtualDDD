using Dominio.Interfaces.InterfaceProduto;
using Entidades.Entidades;
using Entidades.Entidades.Enums;
using InfraEstrutura.Configuracoes;
using InfraEstrutura.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Repositorio.Repositorios
{
    public class RepositorioProduto : RepositorioGenerico<Produto>, IProduto
    {
        private readonly DbContextOptions<ContextBase> _optionsbuilder;

        public RepositorioProduto()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }

        //Método customizado para listar produtos 
        public async Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Produto.Where(exProduto).AsNoTracking().ToListAsync();
            }
        }

        
        public async Task<List<Produto>> ListarProdutoUsuario(string useId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                //Listar os produtos somente do usuario logado (select join)
                return await banco.Produto.Where(p => p.UserId == useId).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var produtosCarrinhoUsuario = await (from p in banco.Produto
                                                     join c in banco.CompraUsuario on p.Id equals c.IdProduto
                                                     where c.UserId.Equals(userId) && c.Estado == EstadoCompra.Produto_Carrinho
                                                     select new Produto
                                                     {
                                                         Id = p.Id,
                                                         Nome = p.Nome,
                                                         Descricao = p.Descricao,
                                                         Observacao = p.Observacao,
                                                         Valor = p.Valor,
                                                         QtdCompra = c.QtdCompra,
                                                         IdProdutoCarrinho = c.Id,
                                                         Url = p.Url

                                                     }).AsNoTracking().ToListAsync();

                return produtosCarrinhoUsuario;

            }
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var produtosCarrinhoUsuario = await (from p in banco.Produto
                                                     join c in banco.CompraUsuario on p.Id equals c.IdProduto
                                                     where c.Id.Equals(idProdutoCarrinho) && c.Estado == EstadoCompra.Produto_Carrinho
                                                     select new Produto
                                                     {
                                                         Id = p.Id,
                                                         Nome = p.Nome,
                                                         Descricao = p.Descricao,
                                                         Observacao = p.Observacao,
                                                         Valor = p.Valor,
                                                         QtdCompra = c.QtdCompra,
                                                         IdProdutoCarrinho = c.Id,
                                                         Url = p.Url
                                                     }).AsNoTracking().FirstOrDefaultAsync();

                return produtosCarrinhoUsuario;

            }
        }

    }
}
