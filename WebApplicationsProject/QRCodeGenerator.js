btn = document.getElementById("buyTicketsButton");
img = document.getElementById("qrcode");
btn.onclick=function(){
    img.style.opacity="1";
    btn.parentNode.replaceChild(img, btn);
}