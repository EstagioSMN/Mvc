var usuario = (function () {
    var configs = {
        urls: {
            cadastro: '',
            bloquear: '',
            buscar: '',
            editar: ''
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

    var bloquearUsuario = function(model) {
        model = $('#form-bloquear').serializeObject();
        
        $.post("https://localhost:7054/usuario/bloquear", model).done(function () {
            site.toast.success("Usuário bloqueado com sucesso!");
            $('#modal-bloquear').remove();
            $('#form-busca').submit();
        }).fail(function (msg) {
            site.toast.error(msg);
        });
    };

    var editarUsuario = function(model) {
        model = $('#form-editar').serializeObject();
        
        $.post("https://localhost:7054/usuario/editar", model).done(function () {
            site.toast.success("Usuário editado com sucesso!");
            $('#modal-editar').remove();
            $('#form-busca').submit();
        }).fail(function (msg) {
            site.toast.error(msg);
        });
    };

    var preencheModalBloquear = function(id) {
        $('#form-bloquear').find('#idBloquearUsuario').val(id);
    };

    var preencheModalEditar = function(id, apelido, email, dataBloqueaio) {
        $('#form-editar').find('#idEditarUsuario').val(id);
        $('#form-editar').find('#inputApelido').val(apelido);
        $('#form-editar').find('#inputEmail').val(email)
        $('#form-editar').find('#inputDataBloqueio').val(dataBloqueaio);
    };

    var buscar = function () {
        model = $('#form-busca').serializeArray();
        $.post("https://localhost:7054/usuario/buscar", model).done(function (html) {
            $('#ResultadoPesquisa').html(html);
            $('.consulta').addClass('consultaOver');
        }).fail(function (msg) {
            site.toast.error(msg);
        });
    };

    var consultaFicaClaro = function () {
        $('.consulta').removeClass('consultaOver');
    }

    var ultimoAcesso = function () {
        $.get("https://localhost:7054/usuario/ultimoacesso").done(function (html) {
            $('#UltimoAcesso').html(html);
        });
    };

    var toggleResultadoDiv = function () {
        if ($("input[name='Resultado']:checked").val('ResultadoPesquisa')) {
            $("#ResultadoPesquisa").show();
            $("#UltimoAcesso").hide();
        }

        if ($("input[name='Resultado']:checked").val('UltimoAcesso')) {
            $("#UltimoAcesso").show();
            $("#ResultadoPesquisa").hide();
            ultimoAcesso();
        }
    };

    $("input[name='Resultado']").on('change', function () {
        toggleResultadoDiv();
    });

    $('.uk-input').on('focus', function () {
        $('.consulta').css({ 'z-index': 99 });
        $(this).css({ 'z-index': 99 });
        $('.overlay').fadeIn(100);
        $('.consulta').removeClass('consultaOver');
    });
    
    $('.uk-input').on('blur', function () {
        $('.overlay').fadeOut(100);
        $(this).css({ 'z-index': 1 });
        $('.consulta').css({ 'z-index': 1 });
    });    

    return {
        init: init,
        cadastro: cadastro,
        bloquearUsuario: bloquearUsuario,
        preencheModalBloquear: preencheModalBloquear,
        preencheModalEditar: preencheModalEditar,
        buscar: buscar,
        ultimoAcesso: ultimoAcesso,
        editarUsuario: editarUsuario,
        consultaFicaClaro: consultaFicaClaro
    };

})();
