function multipleHoover(){
    for(let element of document.querySelectorAll("path")){
        let a=element.getAttribute("data");
        for(let e of document.querySelectorAll(`[data = ${a}]`)){
            e.onmouseenter = function(){
                for (let ee of document.querySelectorAll(`[data = ${a}]`)){
                    ee.classList.add("highlighted");
                }
            }
            e.onmouseleave = function(){
                for (let ee of document.querySelectorAll(`[data = ${a}]`)){
                    ee.classList.remove("highlighted");
                }
            }
        }
    }  
}
        
       
        





      

    

   


    
