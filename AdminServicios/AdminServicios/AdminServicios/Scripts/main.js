function ExecuteAjaxMensaje(_url, _type, funcExe, _sync) {

    var isAsync = true;
    if (_sync) isAsync = false;

    $.ajax({
        cache: false,
        type: _type,
        url: url_,
        async: isAsync,
        success: function (data) {

            if (data.resultado) {
                funcExe(data);
            }
            else { ShowMessage(data); return; }
        },
        error: function (jqXHR, status, err) {
            if (jqXHR.status === 401) {
                redirectLogin();
                return;
            }
            ShowMessage("Error : " + err);
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
            if (jqXHR.status === 401) {
                redirectLogin();
                return;
            }
            ShowMessage("Error : " + err);
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

    Swal({
        title: "Mensaje KMS",
        type: tipo,
        html: "<div class='row' style='margin-bottom:10px !important;'>" + _text + "</div><div class='row'><a id='btnAceptarMsg' class='waves-effect waves-light btn-small btnKriosoft teal darken-1' onClick='javascript:Swal.close();'><i class='material-icons left'>check</i>" + _acceptText + "</a></div>",
        showConfirmButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false
    });
}