var errorMsg = document.querySelector('.container-modal-content--error')
var successMsg = document.querySelector('.container-modal-content--success')
var userName = document.querySelector('input[name="userName"]')
var userPassWord = document.querySelector('input[name="userPassword"]')
var loginForm = document.getElementById('form')
var modal = document.querySelector('.container-msg-modal')
var modalContent = document.querySelectorAll('.container-modal-content')

const loginURL = "https://127.0.0.1:5001/publish_Backend/Auth/Login"
const registerURL = "https://127.0.0.1:5001/Auth/Register"

// only using default value for now
const myLogin = {
    userName: 'string',
    password: 'string'
}

requesGet()
function requesGet() {

    const url = 'https://127.0.0.1:5001/publish_Backend/getAllTodoTasks';


    $.ajax({
        accepts: { accept: '*/*' },
        method: "GET",
        url: url
    })
        .done(function (msg) {
            alert("Data Saved: " + msg);
        });
}
aJaxGetRequest()

function aJaxGetRequest() {




    var data = `{
            "userName": "string",
            "password": "string"
          }`;
    $.ajax({
        url: loginURL,
        data: data,
        type: "post",
        headers: {
            "Access-Control-Allow-Origin": "ikakooo.somee.com",
            "accept": "*/*",
            "content-type": "tapplication/json" // Add this line
            // "content-type": "application/json;charset=UTF-8" // Or add this line
        },
        beforeSend: function () {
            console.log("Waiting...");
        },
        error: function () {
            console.log("Error");
        },
        success: function (data) {
            console.log(data);
        }
    });
}

//tryLogin("string","string")

//login request 
function tryLogin(userName, password) {
    console.log("requesting")
    var xhr = new XMLHttpRequest();
    xhr.open("POST", loginURL);
    xhr.setRequestHeader('Access-Control-Allow-Origin', 'http://127.0.0.1:5500');
    xhr.setRequestHeader('accept', '*/*');
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify({
        userName: userName,
        password: password
    }));
    xhr.onload = function () {
        console.log("HELLO")
        console.log(this.responseText);
        var data = JSON.parse(this.responseText);
        console.log(data);
    }
}
tryRejister()
//login request 
function tryRejister() {
    console.log("requesting")
    var xhr = new XMLHttpRequest();
    xhr.open("POST", registerURL);
    xhr.setRequestHeader('Access-Control-Allow-Origin', 'http://127.0.0.1:5500');
    xhr.setRequestHeader('accept', '*/*');
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(`{
        "userName": "string",
        "email": "string@gmail.com",
        "password": "string",
        "fullName": "string"
      }`);
    xhr.onload = function () {
        console.log("HELLO")
        console.log(this.responseText);
        var data = JSON.parse(this.responseText);
        console.log(data);
    }
}
//login request 
function tryLogin2(userName, password) {

    var xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            // Typical action to be performed when the document is ready:
            var response = xhr.responseText;
            fn(response);
            page = 1;
            //console.log("ok" + response);
        }
    };
    xhr.open("POST", loginURL);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify({
        userName: userName,
        password: password
    }));

}





window.onload = init()

function init() {
    loginForm.addEventListener('submit', function (event) {
        event.preventDefault()
        userLogin()
        console.log("ikakoooo login")
    })
}

function userLogin() {
    var nameVal = userName.value,
        passwordVal = userPassWord.value

    var isLogin = true

    tryLogin(nameVal, passwordVal)

    if (nameVal === myLogin.userName && passwordVal === myLogin.password) {
        loginCheck(isLogin)
    } else {
        loginCheck(!isLogin)
    }
}

function loginCheck(isLogin) {
    modal.classList.add('enabled')

    if (isLogin) {
        successMsg.classList.add('enabled')
    } else {
        errorMsg.classList.add('enabled')
    }

    setTimeout(function () {
        modal.classList.remove('enabled')
        loginForm.reset();
        modalContent.forEach(function (content) {
            content.classList.remove('enabled')
        });
    }, 3000)
}


