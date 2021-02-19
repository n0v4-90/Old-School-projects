$(function(){
   //HTML objects
    var $tall1Text, $tall2Text;
    var $multipliserBtn;
    var $resultatP;
    
    var init = function(){
        
        var setHTMLObjects = function(){
            $tall1Text = $("#tall1Text");
            $tall2Text = $("#tall2Text");
            $multipliserBtn = $("#multipliserBtn");
            $resultatP = $("#resultatP");
        }();
        
        var SetEvents = function(){
            $multipliserBtn.click(multipliser);
            
        }();
        
    }();// end init
    
    
    //applikasjonslogikk
    function multipliser(){
        var tall1 = $tall1Text.val();
        var tall2 = $tall2Text.val();
        var resultat = MINIKALKULATOR.multipliser(tall1, tall2);
        
        $tall1Text
            .add($tall2Text)
            .val("");
        
        $resultatP.text(resultat);
    }
}());