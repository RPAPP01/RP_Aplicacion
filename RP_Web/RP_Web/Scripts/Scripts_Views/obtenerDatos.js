function capturar() {

    // Obtenemos los valores que el usuarion haya ingresado
    var nombre = document.getElementById("nombre").value;
    var correo = document.getElementById("correo").value;
    var celular = document.getElementById("celular").value;
    var pass = document.getElementById("pass").value;
    $.ajax({
        url: '/Login/RegistroUsuarios',
        type: "POST",
        data: {
            user: $('#nombre').val(),//traer datos de HTML 
            email: $('#correo').val(),//traer datos de HTML 
            cel: $('#celular').val(),
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
                // window.location.assign("http://devrpr-001-site1.itempurl.com/Home/Index")

                window.location.assign("https://localhost:44370/Home/Index")


            } else {
                //Si las credenciales son incorrectas tendremos un mensaje de error
                // window.location.assign("http://devrpr-001-site1.itempurl.com/Login/IndexError")
                window.location.assign("https://localhost:44370/Login/IndexError")

            }
        }
    });



    //if (nombre.length == 0) {
    //    alert("Ingresa tu nombre porfavor");
    //    return false;
    //} else {
    //    return true;
    //}

    {
        alert(nombre + "\n" + correo + "\n" + celular + "\n" + pass );
    }
}