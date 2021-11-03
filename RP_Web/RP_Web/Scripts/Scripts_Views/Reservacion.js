function reserva() {

    var nombre = document.getElementById("nombre").value;
    var personas = document.getElementById("personas").value;
    var hora = document.getElementById("hora").value;
    var fecha = document.getElementById("fecha").value;

    $.ajax({
        url: '/Login/NuevaReservacion',
        type: "POST",
        data: {
            nombre: $('#nombre').val(),//traer datos de HTML 
            personas: $('#personas').val(),//traer datos de HTML 
            hora: $('#hora').val(),
            fecha: $('#fecha').val()
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

                //window.location.assign("https://localhost:44370/Home/Index")


            } else {
                //Si las credenciales son incorrectas tendremos un mensaje de error
                // window.location.assign("http://devrpr-001-site1.itempurl.com/Login/IndexError")
              //  window.location.assign("https://localhost:44370/Login/IndexError")

            }
        }
    });

    {
        alert(nombre + "\n" + personas + "\n" + hora + "\n" + fecha);
    }

    //$('#timepicker').datetimepicker({
    //    format: 'LT'
    //})

    ////Date picker
    //$('#reservationdate').datetimepicker({
    //    format: 'L'
    //});
}
        
    
        