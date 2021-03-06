var ObjetoVenda = new Object();

ObjetoVenda.AdicionarCarrinho = function (idProduto) {

    var nome = $("#nome_" + idProduto).val();
    var qtd = $("#qtd_" + idProduto).val();

    $.ajax({
        type: 'POST',
        url: "/api/AdicionarProdutoCarrinho",
        dataType: "JSON",
        cache: false,
        async: true,
        data: {
            "id": idProduto, "nome": nome, "qtd": qtd
        },
        success: function (data) {

            if (data.sucesso) {
                // 1 alert-success// 2 alert-warning// 3 alert-danger
                ObjetoAlerta.AlertarTela(1, "Produto adicionado no carrinho!");
            }
            else {
                // 1 alert-success// 2 alert-warning// 3 alert-danger
                ObjetoAlerta.AlertarTela(2, "Necessário efetuar o login!");
            }

        }
    });


}


ObjetoVenda.CarregaProdutos = function () {

    $.ajax({
        type: 'GET',
        url: "/api/ListarProdutosComEstoque",
        dataType: "JSON",
        cache: false,
        async: true,
        success: function (data) {

            var htmlConteudo = "";

            data.forEach(function (Entidade) {

                htmlConteudo += " <div class='col-xs-12 col-sm-4 col-md-4 col-lg-4'>";

                var idNome = "nome_" + Entidade.id;
                var idQtd = "qtd_" + Entidade.id;

                htmlConteudo += "<br/><label id='" + idNome + "' > Quadrinho: " + Entidade.nome + "</label></br>";                

                if (Entidade.url != null && Entidade.url != "" && Entidade.url != undefined) {

                    htmlConteudo += "<img widh='200' heigh='100' src'" + Entidade.url + "'/></br>";
                }

                htmlConteudo += "<label>  Valor: " + Entidade.valor + "</label></br>";

                htmlConteudo += "Quantidade : <input type'number' value='1' id='" + idQtd + "'>";

                htmlConteudo += "<input type='button' onclick='ObjetoVenda.AdicionarCarrinho(" + Entidade.id + ")' value ='Comprar'> </br> ";

                htmlConteudo += " </div>";

            });

            $("#DivVenda").html(htmlConteudo);
        }
    });

}


ObjetoVenda.CarregaQtdCarrinho = function () {

    $("#qtdCarrinho").text("(0)");

    $.ajax({
        type: 'GET',
        url: "/api/QtdProdutosCarrinho",
        dataType: "JSON",
        cache: false,
        async: true,
        success: function (data) {

            if (data.sucesso) {
                $("#qtdCarrinho").text("(" + data.qtd + ")");
            }

        }
    });


    setTimeout(ObjetoVenda.CarregaQtdCarrinho, 10000);
}

$(function () {
    ObjetoVenda.CarregaProdutos();
    ObjetoVenda.CarregaQtdCarrinho();
});