function register(){
    const $name = $("#name").val();
    const $emailaddress = $("#emailadd").val();
    const $Password = $("#password").val();
    const $confirmpassword = $("#confirmpass").val();
    const $checkbox = $("#posisicheckbox").prop('checked');

    if($name == "" || $emailaddress == "" || $Password == "" || $confirmpassword == ""){
        alert('data harus diisi!');
        return;
    }
    if(!gmail($emailaddress)){
        alert('email address harus pakai format@email.com')
        return;
    }
    if(!passvalidate($Password)){
        alert('password harus diisi minimal 8 karakter, mengandung setidaknya 1 huruf besar, 1 simbol, dan 1 angka')
        return;
    }
    if($confirmpassword != $Password){
        alert('konfirmasi password tidak sama')
        return;
    }
    if(!$checkbox){
        alert('anda harus menyetujui syarat dan ketentuan yanng berlaku')
        return;
    }

    $.ajax({
        type: 'POST',
        url: apiDomain + '/api/User/Register',
        contentType: 'application/json',
        data: JSON.stringify({
            userName: $name,
            userEmail: $emailaddress,
            userPassword: $Password
        }), 
        success: function () {
            window.location.href = './login.html'
        },
        error: function(){
            alert('add data error');
        }
    })
}

function gmail(a){
    const emailregex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/
    return emailregex.test(a);
}

function passvalidate(b){
    const passregex = /^(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$/
    return passregex.test(b);
}