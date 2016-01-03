var i = 0;

function timedCount() {
    i = i + 1;
    postMessage(i);//wysłanie komunikatu z wątku głównego do strony
    setTimeout("timedCount()",500);
}

timedCount();