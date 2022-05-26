var trocarSenha = (function () {
    var configs = {
        urls: {
            trocarsenha: ''
        }
    };

    var init = function ($configs) {
        config = $configs
    };


    function verificacaoSenha() {
        model = $('#trocarSenha').serializeObject();

        if(model['novaSenha']!=model['repitaSenhaNova']){
            site.toast.error("Senhas precisam ser iguais");
            return;
        }
        
        $.post("https://localhost:7054/Login/SenhaTrocada", model).done(function () {
            site.toast.success("Senha trocada com sucesso!");
        }).fail(function () {
            site.toast.error("Falha ao trocar senha");
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
        login: login
    };

})();