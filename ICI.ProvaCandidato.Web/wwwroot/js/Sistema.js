var Sistema = {
    iniciar: function () {
        console.log('Iniciou sistema');
        Sistema.aplicarDataTable();
    },
    aplicarDataTable: function () {
        $('.filter-datatable').DataTable({
            language: {
                url: '//cdn.datatables.net/plug-ins/1.13.7/i18n/pt-PT.json',
            }
        });

    },
    ajax: {
        get: function (url, callback) {


            $.ajax({
                url: url,
                success: function (result) {
                    callback && typeof (callback) == "function" && callback(result);
                },
                error: function (error) {
                    callback && typeof (callback) == "function" && callback({ Sucesso: false, Mensagem: "Falha na requisição", Error: error });
                }
            });

        }
    },
    validacao: {
        ehVazio: function (valor) {
            valor = valor.replace(/\s/gm, '');
            return !valor.length
            
        }
    },
    notificacao: {
        sucesso: function (mensagem, callback) {
            alert(mensagem);
            callback && typeof (callback) == "function" && callback();
        },
        erro: function (arrErros, callback) {

            var mensagem = "";
            if (Array.isArray(arrErros)) {

                arrErros.forEach(erro => mensagem += erro + "\n");

            } else {
                mensagem = arrErros;
            }

            alert(mensagem);
            callback && typeof (callback) == "function" && callback();
        },
        confirmacao: function (mensagem, callbackOk, callbackCancelar) {
            var confirmado = window.confirm(mensagem);

            if (confirmado) {
                callbackOk && callbackOk();
                return;
            }

            callbackCancelar && callbackCancelar();
            return;
        }
    }
}


$(document).ready(function () {
    Sistema.iniciar();
})