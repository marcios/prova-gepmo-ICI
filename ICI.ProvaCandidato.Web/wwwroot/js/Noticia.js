var Noticia = {
    iniciar: function () {
        //Listernes de eventos;
        $('.btnRemove').on('click', Noticia.remover);
        //$('.chckTag').on('click', Noticia.selecionarTag);

        $('form[name=formCadastro]').on('submit', Noticia.salvar)
    },

    salvar: function (event) {

        var erros = [];
        var titulo = $("#txtTitulo").val();
        var texto = $("#txtTexto").val();

        var tags = [];

        function obterTagsSelecionadas() {

            $('.chckTag:checked').each(function (index, tag) {
                tags.push({
                    id: $(tag).val(),
                    descricao: $(tag).data('nome')
                })
            })

            if (tags && tags.length) {
                $('#hdfTags').val(JSON.stringify(tags));
            }

        }

        if (Sistema.validacao.ehVazio(titulo)) {
            erros.push('Informe o título');
        }

        if (Sistema.validacao.ehVazio(texto)) {
            erros.push('Informe o texto');
        }


        if (erros && erros.length) {
            Sistema.notificacao.erro(erros);
            event.preventDefault();
            return;
        }
        
        obterTagsSelecionadas();


    },
    remover: function () {
        var urlExclusao = $(this).data("url");

        function excluirNoticia() {
            Sistema.ajax.get(urlExclusao, function (result) {

                if (result.sucesso) {
                    Sistema.notificacao.sucesso(result.mensagem, function () {
                        window.location.reload();
                    });
                } else {
                    Sistema.notificacao.erro(result.erros);
                }


            });

        }

        Sistema.notificacao.confirmacao("Deseja excluir esta notícia?", excluirNoticia, function () {
            console.log('cancelar')
        });



    }
}


$(document).ready(function () {
    Noticia.iniciar();
})