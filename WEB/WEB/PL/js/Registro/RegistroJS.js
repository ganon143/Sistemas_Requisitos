
function ValidarEspacio() {

    var cedula = document.getElementById("txtCedula").value;
    var nombre = document.getElementsByName("txtNombre")[0].value;
    var apellido1 = document.getElementsByName("txtPrimerApellido")[0].value;
    var apelido2 = document.getElementsByName("txtSegundoApellido")[0].value;
    var email = document.getElementsByName("txtEmail")[0].value;
    var telefono = document.getElementsByName("txtTelefono1")[0].value;
    var usuario = document.getElementsByName("txtUsuario")[0].value;
    var contrasena = document.getElementsByName("txtContrasenia")[0].value;

    var expr = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;


    if ((cedula == "") || (nombre == "") || (apellido1 == "") || (apelido2 == "") || (email == "")
        || (telefono == "") || (usuario == "") || (contrasena == "")) {  //COMPRUEBA CAMPOS VACIOS
        alert("Los campos no pueden quedar vacios");
        return true;
    }

    if (!expr.test(email)) {                                                            //COMPRUEBA MAIL
        alert("Error: La dirección de correo es incorrecta.");
        return false;
    }
}

function ValidarLetras(e) {
    key = e.keyCode || e.which; // captura la entrada digitada en el teclado // CODIGO ASCCI
    teclado = String.fromCharCode(key).toLowerCase(); // pasa el valor string que 
    letras = "zxcvbnmasdfghjklñqwertyuiopáéíóúABCDEFGHIJKLMNÑOPQRSTUVWXYZ"; // arreglo de letras permitidas
    especiales = "8-37-38-48"; // arreglo de caracteres especiales
    teclado_especiales = false; // variable de controñl o bandera
    // Arreglo 
    for (var i in especiales) {
        if (key == especiales[i]) {
            teclado_especiales = true
            break;
        }
        // [TODO EL IF DE ABAJO ] = digita ejm, un alt64, y busque dentro del arreglo, si lo encuentra, devuelve la posicion sino devuelve -1 
        if ((letras.indexOf(teclado) == -1) && (!teclado_especiales)) // [ indexOf ] = Devuelve la posicion  de una letra 
        {
            alert("No puede dígitar números, espacios o carácteres especiales");
            return false;                                                               // [ innerHTML ] = para buscar dentro del formato de html estandar segun el navegador
        }
        else {
            document.getElementById("formError").innerHTML = "";
            return true;
        }
    }
}

function ValidarNumeros(e) {
    var key = window.event ? e.which : e.keyCode;
    if (key < 48 || key > 57) {
        alert("Solo puede dígitar números");
        e.preventDefault();
    }
}

