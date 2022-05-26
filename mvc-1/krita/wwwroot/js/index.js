const form = document.getElementById("id-form");
const email = document.getElementById('email');

function verificacaoEmail(){
    if(email.value.matches(pattern)){
        document.getElementById("spanEmail").innerHTML = "E-mail inválido."
        document.getElementById("spanEmail").style.color = 'red'
    }
}
