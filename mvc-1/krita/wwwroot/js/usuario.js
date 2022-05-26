var usuario = (function () {
    var configs = {
        urls: {
            cadastro: ''
        }
    };

    var init = function ($configs) {
        config = $configs
    };

    function cadastro() {
        model = $('#form-cadastro').serializeObject();
        
        $.post("https://localhost:7054/usuario/cadastrar", model).done(function () {
            site.toast.success("Usuário cadastrado com sucesso!");
        }).fail(function (msg) {
            site.toast.error(msg);
        });
    };

    return {
        init: init,
        cadastro: cadastro
    };

})();
