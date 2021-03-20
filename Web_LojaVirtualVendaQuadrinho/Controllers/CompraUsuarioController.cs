﻿using AplicacaoApp.Interfaces;
using Entidades.Entidades;
using Entidades.Entidades.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_LojaVirtualVendaQuadrinho.Models;

namespace Web_LojaVirtualVendaQuadrinho.Controllers
{
    public class CompraUsuarioController : HelpQrCode
    {

        public readonly UserManager<UsuarioAplicacao> _userManager;
        public readonly InterfaceCompraUsuarioApp _InterfaceCompraUsuarioApp;
        private IWebHostEnvironment _environment;

        public CompraUsuarioController(UserManager<UsuarioAplicacao> userManager, InterfaceCompraUsuarioApp InterfaceCompraUsuarioApp, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _InterfaceCompraUsuarioApp = InterfaceCompraUsuarioApp;
            _environment = environment;
        }

        public async Task<IActionResult> FinalizarCompra()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var compraUsuario = await _InterfaceCompraUsuarioApp.CarrinhoCompras(usuario.Id);
            return View(compraUsuario);
        }

        public async Task<IActionResult> MinhasCompras(bool mensagem = false)
        {
            var usuario = await _userManager.GetUserAsync(User);
            var compraUsuario = await _InterfaceCompraUsuarioApp.ProdutosComprados(usuario.Id);

            if (mensagem)
            {
                ViewBag.Sucesso = true;
                ViewBag.Mensagem = "Compra efetivada com sucesso. Pague o boleto para garantir sua compra!";
            }

            return View(compraUsuario);
        }

        public async Task<IActionResult> ConfirmaCompra()
        {
            var usuario = await _userManager.GetUserAsync(User);

            var sucesso = await _InterfaceCompraUsuarioApp.ConfirmaCompraCarrinhoUsuario(usuario.Id);

            if (sucesso)
            {
                return RedirectToAction("MinhasCompras", new { mensagem = true });
            }
            else
                return RedirectToAction("FinalizarCompra");
        }

        public async Task<IActionResult> Imprimir()
        {
            var usuario = await _userManager.GetUserAsync(User);

            var compraUsuario = await _InterfaceCompraUsuarioApp.ProdutosComprados(usuario.Id);

            return await Download(compraUsuario, _environment);

        }

        [HttpPost("/api/AdicionarProdutoCarrinho")]
        public async Task<JsonResult> AdicionarProdutoCarrinho(string id, string nome, string qtd)
        {
            var usuario = await _userManager.GetUserAsync(User);

            if (usuario != null)
            {
                await _InterfaceCompraUsuarioApp.Adicionar(new CompraUsuario
                {
                    IdProduto = Convert.ToInt32(id),
                    QtdCompra = Convert.ToInt32(qtd),
                    Estado = EstadoCompra.Produto_Carrinho,
                    UserId = usuario.Id
                });
                return Json(new { sucesso = true });
            }

            return Json(new { sucesso = false });

        }

        [HttpGet("/api/QtdProdutosCarrinho")]
        public async Task<JsonResult> QtdProdutosCarrinho()
        {
            var usuario = await _userManager.GetUserAsync(User);

            var qtd = 0;

            if (usuario != null)
            {
                qtd = await _InterfaceCompraUsuarioApp.QuantidadeProdutoCarrinhoUsuario(usuario.Id);

                return Json(new { sucesso = true, qtd = qtd });
            }
            return Json(new { sucesso = false, qtd = qtd });
        }
    }
}
