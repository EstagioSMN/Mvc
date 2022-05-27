var login = (function () {
    var configs = {
        urls: {
            login: '',
            trocarsenha: '',
            esquecisenha: ''
        }
    };

    var init = function ($configs) {
        config = $configs
    };


    function verificacaoSenha() {
        model = $('#form-trocarSenha').serializeObject();

        if(model['novaSenha']!=model['repitaSenhaNova']){
            site.toast.error("Senhas precisam ser iguais");
            return;
        }
        
        $.post("https://localhost:7054/Login/SenhaTrocada", model).done(function () {
            site.toast.success("Senha trocada com sucesso!");
            $('#modal-center').hide();
        }).fail(function () {
            site.toast.error("Falha ao trocar senha");
        });
    };

    function verificarEmail() {
        model = $('#form-receberEmail').serializeObject();
        
        $.get("https://localhost:7054/Login/enviar", model).done(function () {
            site.toast.success("Email enviado com sucesso!");
            $('#modal-center').hide();
        }).fail(function () {
            site.toast.error("Falha ao enviar email");
        });
    };

    function login() {
        model = $('#form-busca').serializeObject();
        
        if(model == null)
            return;

            $.post("https://localhost:7054/Login", model).done(function () {
            site.toast.success("Login realizado com sucesso");
            location.href = "https://localhost:7054";
        }).fail(function () {
            site.toast.error("Falha ao logar");
        });
    }

    return {
        init: init,
        verificacaoSenha: verificacaoSenha,
        verificarEmail: verificarEmail,
        login: login
    };

})();
