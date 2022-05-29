var login = (function () {
    var configs = {
        urls: {
            trocarsenha: ''
        }
    };

    var init = function ($configs) {
        config = $configs
    };


    function verificacaoSenha() {
        model = $('#form-trocarSenha').serializeObject();

        if(model['novaSenha']!=model['repitaSenhaNova']){
            site.toast.error("Senhas diferentes.");
            return;
        } else if(model['novaSenha'].length() < 6){
            site.toast.error("Sua senha deve pussuir no mínimo 6 dígitos.");
            return;
        }
        
        $.post("https://localhost:7054/Login/SenhaTrocada", model).done(function () {
            site.toast.success("Senha trocada com sucesso!");
            $('#modal-trocar-senha').hide();
            $('#form-trocarSenha').find('[name="email"], [name="senhaAtual"], [name="novaSenha"], [name="repitaSenhaNova"]').val('');
        }).fail(function () {
            site.toast.error("Falha ao trocar senha");
        });
    };

    function verificarEmail() {
        model = $('#form-receberEmail').serializeObject();

        if (model.email != '') {
            $.get("https://localhost:7054/Login/enviar", model).done(function () {
                site.toast.success("Email enviado com sucesso!");
                $('#modal-enviar-email').hide();
                $('#form-receberEmail').find('[name="email"]').val('');
            }).fail(function () {
                site.toast.error("Falha ao enviar email");
            });
        } else {
            site.toast.error("Falha ao enviar email");
        }
    };

    function esqueciSenha() {
        model = $('#form-esqueci-senha').serializeObject();
        if(model['senhaNova'].length < 6){
            site.toast.error("Sua senha deve pussuir no mínimo 6 dígitos.");
            $('#form-esqueci-senha').find('[name="senhaNova"], [name="senhaNovaRepetida"]').val('');
        } 
        else if(model['senhaNova'] != model['senhaNovaRepetida']){
            site.toast.error("Senhas precisam ser iguais.");
            $('#form-esqueci-senha').find('[name="senhaNova"], [name="senhaNovaRepetida"]').val('');
        } else {
            $.post("https://localhost:7054/Login/nova-senha", model).done(function () {
                site.toast.success("Senha alterada com sucesso!");
                location.href = "https://localhost:7054/Login";
            }).fail(function () {
                site.toast.error("Falha ao alterar senha");
            });
        }
    };

    function login() {
        model = $('#form-busca').serializeObject();
        if(model['Senha'].length < 6){
            site.toast.error("Sua senha deve pussuir no mínimo 6 dígitos.");
            $('#form-esqueci-senha').find('[name="Email"], [name="Senha"]').val('');
            return;
        } 

        $.post("https://localhost:7054/Login", model).done(function () {
        site.toast.success("Login realizado com sucesso");
        location.href = ("https://localhost:7054")
        
        }).fail(function () {
            site.toast.error("Falha ao logar");
        });
    }

    return {
        init: init,
        verificacaoSenha: verificacaoSenha,
    };

})();
