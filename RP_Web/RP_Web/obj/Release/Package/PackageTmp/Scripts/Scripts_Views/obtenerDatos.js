function capturar() {

    // Obtenemos los valores que el usuarion haya ingresado
    var nombre = document.getElementById("nombre").value;
    var correo = document.getElementById("correo").value;
    var pass = document.getElementById("pass").value;

    {
        alert(nombre + "\n" + correo + "\n" + pass);
    }
}