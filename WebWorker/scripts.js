var w_counter;
var w_fibonacci;

function startWorker() {
    if(typeof(Worker) !== "undefined") {
        if(typeof(w_counter) == "undefined") {
            w_counter = new Worker("demo_workers.js");// Utwórz wątek roboczy na bazie pliku "demo_workers.js"
			}
        
		//odzytuje przesłane dane
        w_counter.onmessage = function(event) {
            document.getElementById("result").innerHTML = event.data;
        };
    } else {
        document.getElementById("result").innerHTML = "Sorry, your browser does not support Web Workers...";
    }
}

function stopWorker() { 
    w_counter.terminate();//zatrzymanie wątku
	w_fibonacci.terminate();
    w_counter = undefined;//dzięki temu można ponownie użyć kodu
}

function fibonacci(){
    w_fibonacci= new Worker("fibonacci.js");
    w_fibonacci.onmessage = function(event) {
        document.getElementById("index").innerHTML = event.data.index;
		document.getElementById("wynik").innerHTML = event.data.value;
        }
}