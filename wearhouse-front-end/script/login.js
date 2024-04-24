function doLogin(){
    const email = $("#username").val();
    const password = $("#password").val(); 

    if(email == "" || password == "") {
        alert('data harus diisi');
        return;
    }

    if(!emailvalidate(email)){
        alert('isi pakai format@email.com');
        return;
    }

    $.ajax({
        type: 'post',
        url: apiDomain + '/api/User/Login',
        contentType: 'application/json',
        data: JSON.stringify({
            userEmail: email,
            userPassword: password
        }),
        success: function(data){
            if(data != null){
                localStorage.setItem('userID', data.userID);
                localStorage.setItem('userName', data.userName);
                window.location.href = './home.html'
                return;
            }else { 
                alert("User not found");
            }
        },
        error: function(){
            alert("Login Error");
        }
    })

}

function emailvalidate(a){
    const emailreg = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/
    return emailreg.test(a);
}

