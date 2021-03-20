using Dominio.Interfaces.InterfaceCompraUsuario;
using Entidades.Entidades;
using Entidades.Entidades.Enums;
using InfraEstrutura.Configuracoes;
using InfraEstrutura.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Repositorio.Repositorios
{    
    public class RepositorioCompraUsuario : RepositorioGenerico<CompraUsuario>, ICompraUsuario
    {
        public readonly DbContextOptions<ContextBase> _optionsbuilder;

        public RepositorioCompraUsuario()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();  
        }

        public async Task<bool> ConfirmaCarrinhoUsuario(string userId)
        {
            try
            {
                using (var banco = new ContextBase(_optionsbuilder))
                {
                    var compraUsuario = new CompraUsuario();
                    compraUsuario.ListaProdutos = new List<Produto>();

                    var produtosCarrinhoUsuario = await(from p in banco.Produto
                                                        join c in banco.CompraUsuario on p.Id equals c.IdProduto
                                                        where c.UserId.Equals(userId) && c.Estado == EstadoCompra.Produto_Carrinho
                                                        select c).AsNoTracking().ToListAsync();

                    produtosCarrinhoUsuario.ForEach(p =>
                    {
                        p.Estado = EstadoCompra.Produto_Caminho;
                    });

                    banco.UpdateRange(produtosCarrinhoUsuario);
                    await banco.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception erro)
            {
                return false;
            }
        }

        public async Task<bool> ConfirmaCompraCarrinhoUsuario(string userId)
        {
            try
            {
                using (var banco = new ContextBase(_optionsbuilder))
                {
                    var compraUsuario = new CompraUsuario();
                    compraUsuario.ListaProdutos = new List<Produto>();

                    var produtosCarrinhoUsuario = await(from p in banco.Produto
                                                        join c in banco.CompraUsuario on p.Id equals c.IdProduto
                                                        where c.UserId.Equals(userId) && c.Estado == EstadoCompra.Produto_Carrinho
                                                        select c).AsNoTracking().ToListAsync();

                    produtosCarrinhoUsuario.ForEach(p =>
                    {
                        p.Estado = EstadoCompra.Produto_Comprado;
                    });

                    banco.UpdateRange(produtosCarrinhoUsuario);
                    await banco.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception erro)
            {
                return false;
            }
        }

        public async Task<CompraUsuario> ProdutosCompradosPorEstado(string userId, EstadoCompra estado)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var compraUsuario = new CompraUsuario();
                compraUsuario.ListaProdutos = new List<Produto>();

                var produtosCarrinhoUsuario = await(from p in banco.Produto
                                                    join c in banco.CompraUsuario on p.Id equals c.IdProduto
                                                    where c.UserId.Equals(userId) && c.Estado == estado
                                                    select new Produto
                                                    {
                                                        Id = p.Id,
                                                        Nome = p.Nome,
                                                        Descricao = p.Descricao,
                                                        Observacao = p.Observacao,
                                                        Valor = p.Valor,
                                                        QtdCompra = c.QtdCompra,
                                                        IdProdutoCarrinho = c.Id,
                                                        Url = p.Url,
                                                    }).AsNoTracking().ToListAsync();

                compraUsuario.ListaProdutos = produtosCarrinhoUsuario;
                compraUsuario.UsuarioAplicacao = await banco.UsuarioAplicacao.FirstOrDefaultAsync(u => u.Id.Equals(userId));
                compraUsuario.QuantidadeProdutos = produtosCarrinhoUsuario.Count();
                compraUsuario.EnderecoCompleto = string.Concat(compraUsuario.UsuarioAplicacao.Endereco, " - ", compraUsuario.UsuarioAplicacao    .ComplementoEndereco, " - CEP: ", compraUsuario.UsuarioAplicacao.CEP);
                compraUsuario.ValorTotal = produtosCarrinhoUsuario.Sum(v => v.Valor);
                compraUsuario.Estado = estado;
                return compraUsuario;
            }
        }

        public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
        {
            //Aqui estou contando todos produtos que o usuario tem no carrinho e trazendo 
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.CompraUsuario.CountAsync(c => c.UserId.Equals(userId) && c.Estado == EstadoCompra.Produto_Carrinho);
            }
        }
    }
}
