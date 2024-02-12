var Tag = {
    iniciar: function () {
        //Listernes de eventos;
        $('.btnRemove').on('click', Tag.remover);

        $('form[name=formCadastro]').on('submit',Tag.salvar)
    },
    salvar: function (event) {
        
        var erros = [];        
        var nome = $("#txtNome").val();
   

        if (Sistema.validacao.ehVazio(nome))
            erros.push("Informe o nome");


        if (erros && erros.length) {
            Sistema.notificacao.erro(erros);
            event.preventDefault();
            return;
        }

       
    },
    remover: function () {


        //obter id da tag clicada
        var urlExclusao = $(this).data("url");

        function excluirTag() {
            Sistema.ajax.get(urlExclusao, function (result) {

                if (result.sucesso) {
                    Sistema.notificacao.sucesso(result.mensagem, function () {
                        window.location.reload();
                    })
                } else {
                    Sistema.notificacao.erro(result.erros);
                }


            });

        }

        Sistema.notificacao.confirmacao("Deseja excluir esta tag?", excluirTag, function () {
            console.log('cancelar')
        });

   
   
    }
}


$(document).ready(function () {
    Tag.iniciar();
})