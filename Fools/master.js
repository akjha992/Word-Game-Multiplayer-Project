var b1 = document.getElementById('Button1');
var b2 = document.getElementById('Button2');
var label = document.getElementById('l1');
var dlist = document.getElementById('DropDownList1');
var b3 = document.getElementById('Button3');
var b4 = document.getElementById('Button4');
var bck1 = document.getElementById('back1');
var bck2 = document.getElementById('back2');
var txtbox = document.getElementById('TextBox1');
var label2 = document.getElementById('l2');
var logo = document.getElementById('logo');
var initq = true;
if (initq)
{
    initq = false;
    init();
}


function getcreatebutton() {
    if (document.getElementById('DropDownList1').value != "Select") {
        b3.style.visibility = 'visible';
    }
    else {
        b3.style.visibility = 'hidden';
    }
}


function init() {
    logo.className = "logovis";
    label.style.visibility = 'hidden';
    dlist.style.visibility = 'hidden';
    b3.style.visibility = 'hidden';
    label2.style.visibility = 'hidden';
    txtbox.style.visibility = 'hidden';
    b4.style.visibility = 'hidden';
    b1.style.visibility = 'visible';
    b2.style.visibility = 'visible';
    clicked = false;
    clicked2 = false;
    bck1.style.visibility = 'hidden';
    bck2.style.visibility = 'hidden';
}

function showme() {
    logo.className = "";
    b1.style.visibility = 'hidden';
    b2.style.visibility = 'hidden';
    label.style.visibility = 'visible';
    dlist.style.visibility = 'visible';
    bck1.style.visibility = 'visible';
}
function showme2() {
    logo.className = "";
    document.getElementById('TextBox1').value = '----';
    b1.style.visibility = 'hidden';
    b2.style.visibility = 'hidden';
    label2.style.visibility = 'visible';
    txtbox.style.visibility = 'visible';
    b4.style.visibility = 'visible';
    bck2.style.visibility = 'visible';
}
