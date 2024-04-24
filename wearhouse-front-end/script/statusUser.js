$('#boxHomeLogin').hide();

$(document).ready(function(){
    if(localStorage.getItem('userID') == null){
        if (window.location.href.indexOf('home.html') === -1 && window.location.href.indexOf('login.html') === -1 && window.location.href.indexOf('register.html') === -1) {
            window.location.href = 'home.html';
        }
        $('#boxHomeLogin').hide();
    }else { 
        $('#UserName').text(localStorage.getItem('userName'));
        $('.loginReq').hide();
        $('#boxHomeLogin').show();
        $('#dropdownBtn').show();
        $('#btnLogOut').show();
        $('#UserName').show();
        $('#UserName').css('margin-left', '50px');
        $('#btnLogOut').css('margin-left', '10px');
    }
});

$('#usercheckbox').on("change", function() {
    if ($(this).is(":checked")) {
        $('#btnLogOut').show();
    } else {
        $('#btnLogOut').hide();
    }
});

function LogOut(){
    $('#UserName').text(null);
    $('.loginReq').show();
    $('#boxHomeLogin').hide();
    $('#dropdownBtn').hide();
    $('#UserName').hide();
    $('#btnLogOut').hide();
    $('#btnLogOut').val("notchecked");
    localStorage.removeItem('userID');
    localStorage.removeItem ('userName');
    location.reload();
}