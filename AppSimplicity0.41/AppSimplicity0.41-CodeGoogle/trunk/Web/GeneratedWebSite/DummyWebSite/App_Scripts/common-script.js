

var cal = Calendar.setup({
          onSelect: function(cal) { cal.hide() },
          showTime: true
      });
      



function Slide (ElementSelector) {    
    
    var options = {};
    
    $(ElementSelector).show('slide', options, 500);    

}

 function Hide (ElementSelector) {
    
    $(ElementSelector).hide(); 
    
}
							

function raiseconfirmation(message, displayoverlay) {

    if (confirm (message)) {
        
        if (displayoverlay) {        
            block();
        }  
        
        return true;        
    }    
    else return false     
        
}
