var id = document.getElementById('id');
var pass = document.getElementById('pass');

function loginfun() {
    var check = false;
    if (document.getElementById('id').value == "" || document.getElementById('pass').value == "" || document.getElementById('id').value == "ID?" || document.getElementById('pass').value == "PASS?")
    {
        document.getElementById('error').textContent = "Dont leave them blank!";
    }
    else{
        check = true;
    }
    return check;
}

function outfocus() {
    
    if (document.getElementById('id').value == '')
        document.getElementById('id').value = "ID?";
    else if (document.getElementById('pass').value == '')
        document.getElementById('pass').value = "PASS?";
}
function signupfun() {
    document.getElementById('error').textContent = "Feature not available currently!";
    return false;
}
