function login_out() {
  //  window.location.assign("http://devrpr-001-site1.itempurl.com/Login/Index");
    window.location.assign("https://localhost:44370/Login/Index");

    sessionStorage.clear()
}


function obtener_nombre() {
    // Valariables de mostrar Valor de Session
    var data = sessionStorage.getItem('user');
        if (data == null)
        {
           // alert("No Funciona")
       // window.location.assign("http://devrpr-001-site1.itempurl.com/Login/Index");
       window.location.assign("https://localhost:44370/Login/Index");

        } else
        {
            
            //alert(data)
    }


}

function calendario() {
    window.localtion.assign("https://localhost:44370/Home/calendar");

}