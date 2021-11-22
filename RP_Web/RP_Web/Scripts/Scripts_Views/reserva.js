function prueba() {

    alert('Entra la funcion');
    //var nombre = document.getElementById("nombre").value;
    //var lugar = document.getElementById("lugar").value;
    //var personas = document.getElementById("personas").value;
    //var hora = document.getElementById("hora").value;
    //var fecha = document.getElementById("fecha").value;

    $.ajax({
        url: '/Login/NuevaReservacion',
        type: "POST",
        data: {
            nombre: $('#nombre').val(),//traer datos de HTML 
            //lugar: $('#lugar').val(),//traer datos de HTML 
            personas: $('#personas').val(),//traer datos de HTML 
            hora: $('#hora').val(),
            fecha: $('#fecha').val()
        },
        success: function (data) {

        }
    });


}