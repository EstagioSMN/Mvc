const form = document.getElementById("id-form");

const email = document.getElementById('email');
const senhaNova = document.getElementById('senhaNova');
const senhaNovaRepetida = document.getElementById('senhaNovaRepetida');
var pattern = /^[^ ]+@[^ ]+.[a-z]{2,3}$/;

function verificacaoEmail(){
    if(email.value.matches(pattern)){
        document.getElementById("spanEmail").innerHTML = "E-mail inválido."
        document.getElementById("spanEmail").style.color = 'red'
    }
}

function verificacaoSenha(){
    if(senhaNova.value != senhaNovaRepetida.value){
        document.getElementById("spanSenha").innerHTML = "Senhas diferentes.";
        document.getElementById("spanSenha").style.color = 'red';
    } else {
        document.getElementById("spanSenha").innerHTML = "";
    }
}
