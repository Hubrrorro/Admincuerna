function ExecuteAjaxModelMensaje(_model,_url, _type, _sync) {

    var isAsync = true;
    if (_sync) isAsync = false;

    $.ajax({
        cache: false,
        type: _type,
        url: _url,
        data: _model,
        async: isAsync,
        success: function (data) {

             ShowMessage(data); return; 
        },
        error: function (jqXHR, status, err) {
            
            console.log(jqXHR);
            console.log(status);
            console.log(err);
            return;
        }
    });
}
function ExecuteAjaxMensaje(_url, _type, funcExe, _sync) {

    var isAsync = true;
    if (_sync) isAsync = false;

    $.ajax({
        cache: false,
        type: _type,
        url: _url,
        async: isAsync,
        success: function (data) {

            if (data.resultado) {
                funcExe(data);
            }
            else { ShowMessage(data); return; }
        },
        error: function (jqXHR, status, err) {
            
            console.log(jqXHR);
            console.log(status);
            console.log(err);
            return;
        }
    });
}
function ExecuteAjax(_url, _type, funcExe, _sync) {
    
    var isAsync = true;
    if (_sync) isAsync = false;

    $.ajax({
        cache: false,
        type: _type,
        url: _url,
        async: isAsync,
        success: function (data) {
                funcExe(data);
        },
        error: function (jqXHR, status, err) {
            
            console.log(jqXHR);
            console.log(status);
            console.log(err);
            return;
        }
    });
}
function ExecuteAjax2(_model,_url, _type, funcExe, _sync) {

    var isAsync = true;
    if (_sync) isAsync = false;

    $.ajax({
        cache: false,
        type: _type,
        url: _url,
        async: isAsync,
        data: _model,
        success: function (data) {
            funcExe(data);
        },
        error: function (jqXHR, status, err) {
           
            console.log(jqXHR);
            console.log(status);
            console.log(err);
            return;
        }
    });
}
function ShowMessage(result) {
    var tipo = "success";
    var _mensajes = [];
    _mensajes = result.mensajes;
    var _text = "";

    for (i = 0; i < _mensajes.length; i++) {
        _text += _mensajes[i] + "\n";
    }

    if (!result.resultado)
        tipo = "error";

    Swal.fire({
        title: "Mensaje",
        type: tipo,
        text: _text,
        showConfirmButton: true,
        allowOutsideClick: false,
        allowEscapeKey: false
    });
}