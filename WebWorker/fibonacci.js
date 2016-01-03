function fib(n) {

   return n < 2 ? n : fib(n-1) + fib(n-2);

}
 
for(var i = 0; i < 100; ++i) {

   postMessage({
      index: i,
      value: fib(i)//wysyła dane między procesami
   })
}