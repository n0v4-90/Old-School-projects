/**
Minikalkulator Module
- utviklet av Noman 6.4.17
*/

//1. variabler(private, offentlig)
var MINIKALKULATOR = (function(){
    //2. funksjoner (private, offentlige)
    var multipliser = function(tall1, tall2){
        return tall1 * tall2;
    }
        
    
    //3. publisering av valgte variabler og funksjoner
    return {
        multipliser: multipliser
    }
    
    
}());