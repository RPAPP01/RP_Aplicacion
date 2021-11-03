function Validar() {
    $('#user').val();
    $('#pass').val();
    if ($('#user').val()) {
        if ($('#pass').val()) {
            $('#user').css({ 'box-shadow': ' rgb(8, 197, 66) 0px 1px 0px, rgba(0, 0, 0, 0.08) 0px -2px 5px inset' });
            $('#pass').css({ 'box-shadow': 'rgb(8, 197, 66) 0px 1px 0px, rgba(0, 0, 0, 0.08) 0px -2px 5px inset' });
            $.ajax({
                url: '/Login/ValidaLogin',
                type: "POST",
                data: {
                    user: $('#user').val(),//traer datos de HTML 
                     pass: $('#pass').val()
                },
                success: function (data) {
                    if (data != '') {
                        //var fn = moment().format('YYYY-MM-DD')
                        //sessionStorage.setItem('Fecha_Inicial', fn);
                        //sessionStorage.setItem('Fecha_Final', fn);
                        var nombre = '';
                        var email = '';
                        var roll = '';
                        $.each(data, function (key, value) {
                            nombre = value['Nombre_usuario'];
                            email = value['Correo'];
                            roll = value['Permisos'];
                        })
                        // Valariables de Guardar Valor de Session
                        sessionStorage.setItem('user', nombre);
                        sessionStorage.setItem('responsable', email);
                        sessionStorage.setItem('roll', roll);
                       window.location.assign("http://devrpr-001-site1.itempurl.com/Home/Index")

                       // window.location.assign("https://localhost:44370/Home/Index")


                    } else {
                        //Si las credenciales son incorrectas tendremos un mensaje de error
                        window.location.assign("http://devrpr-001-site1.itempurl.com/Login/IndexError")
                       //window.location.assign("https://localhost:44370/Login/IndexError")

                        $('#msg_error').text('Error verifica tus credenciales')
                        $('#user').css({ 'box-shadow': ' 0 1px 0 #dc3545, 0 -2px 5px rgba(0,0,0,0.08) inset' });
                        $('#pass').css({ 'box-shadow': ' 0 1px 0 #dc3545, 0 -2px 5px rgba(0,0,0,0.08) inset' });
                    }


                        //if (roll == 'Responsable') {
                        //    window.location.assign("https://localhost:44399/Home/Avance")

                        //} else if (roll == 'Contabilidad') {
                        //    window.location.assign("https://localhost:44399/Tools/Index")
                        //} 
                }
            });
        }
        else {
            $('#msg_error').text('Error verifica tus credenciales')
            $('#user').css({ 'box-shadow': ' 0 1px 0 #dc3545, 0 -2px 5px rgba(0,0,0,0.08) inset' });
            $('#pass').css({ 'box-shadow': ' 0 1px 0 #dc3545, 0 -2px 5px rgba(0,0,0,0.08) inset' });
        }
    } else {
        $('#msg_error').text('Error verifica tus credenciales')
        $('#user').css({ 'box-shadow': ' 0 1px 0 #dc3545, 0 -2px 5px rgba(0,0,0,0.08) inset' });
        $('#pass').css({ 'box-shadow': ' 0 1px 0 #dc3545, 0 -2px 5px rgba(0,0,0,0.08) inset' });
    }
}

function limpiar_login()
{
    sessionStorage.clear()
    //window.location.assign("http://bi.atgenesis.mx/Login/Index")
}
function login_recuperar_credenciales() {
    $("#modal_recuperar_credenciales").modal("show")
    $("#lbl_login_recuperacion_mensaje").hide()
    $("#txt_login_recuperar_credenciales").val("")
    $("#login_recuperar_credenciales_boton").show(0)


    $("#txt_login_recuperar_credenciales").change((e) => login_recuperar_credenciales_boton_change($(e.target).val()))
    $("#txt_login_recuperar_credenciales").keydown((e) => login_recuperar_credenciales_boton_change($(e.target).val() + e.key))
}
function login_recuperar_credenciales_envia_correo() {
    login_recuperar_credenciales_enviando(true)
    var usuario_correo = $("#txt_login_recuperar_credenciales").val();
    $.get("/Login/RecuperaCredenciales?usuario_correo=" + encodeURIComponent(usuario_correo), function (d) {
        $("#lbl_login_recuperacion_mensaje").text(d.mensaje)
        if (d.valido == 1) {
            if ($("#lbl_login_recuperacion_mensaje").hasClass("bg-danger")) $("#lbl_login_recuperacion_mensaje").removeClass("bg-danger")
            $("#lbl_login_recuperacion_mensaje").addClass("bg-success")
            $("#lbl_login_recuperacion_mensaje").addClass("txt-white")
            $("#lbl_login_recuperacion_mensaje").show("slow").delay(5000).hide("slow")
            $("#login_recuperar_credenciales_boton").hide(50)
            setTimeout(() => $("#modal_recuperar_credenciales").modal("hide"), 3000)
        }
        else {
            $("#lbl_login_recuperacion_mensaje").text(d.mensaje)
            $("#lbl_login_recuperacion_mensaje").addClass("bg-danger")
            $("#lbl_login_recuperacion_mensaje").addClass("txt-white")
            $("#lbl_login_recuperacion_mensaje").show("slow").delay(5000).hide("slow")
        }
    }).always((e) => login_recuperar_credenciales_enviando(false))
}
function login_recuperar_credenciales_boton_change(value) {
    var email_validado = /[a-zA-Z_-]{1,30}@[a-zA-Z_-]{1,30}\.(com|mx|edu)+/.test(value) //Valores que acepta el correo

    if (email_validado == true) {
        $("#login_recuperar_credenciales_boton").removeClass("btn-default")
        $("#login_recuperar_credenciales_boton").addClass("btn-primary")

    } else {
        $("#login_recuperar_credenciales_boton").addClass("btn-default")
        $("#login_recuperar_credenciales_boton").removeClass("btn-primary")
    }
    $("#login_recuperar_credenciales_boton").prop("disabled", !email_validado)

}
function login_recuperar_credenciales_enviando(enviando) {
    $("#login_recuperar_credenciales_boton").prop("disabled", enviando)
    if (enviando) $("#login_recuperar_credenciales_boton").text("Enviando...")
    else $("#login_recuperar_credenciales_boton").text("Recuperar")


}
function mostrarContrasena() {
    var tipo = document.getElementById("pass");
    if (tipo.type == "password") {
        tipo.type = "text";
    } else {
        tipo.type = "password";
    }
}


    //funcion para registrar usuarios
    function registrarse() {
     // window.location.assign("https://localhost:44370/Login/registro");
        window.location.assign("http://devrpr-001-site1.itempurl.com/Login/registro");

}

function capturar() {


}

