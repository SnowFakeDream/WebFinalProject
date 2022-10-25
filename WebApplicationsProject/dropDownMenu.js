 btn = document.getElementById("drop-rightButton");
 dr = document.getElementById("drop-right");
 drUL=dr.querySelector("ul");
 mapContainer=document.getElementById("container");
 allPaths=document.getElementsByClassName("part");

    for(let path of allPaths){
        path.addEventListener('click', function(){
            let a=path.getAttribute("dataid");
            creatingDropRight();
            getAnimalByID(a);  
        })
    
    }
    



function addListForDr(){
        let names=[];
        for(let element of allPaths){
            let a=element.getAttribute("data");
            names.push(a);
        }
        uniqNames= names.filter((x,i)=> names.indexOf(x)===i);


        uniqNames.sort();

        for(i=0;i<uniqNames.length;i++){
        item = document.createElement('li');
        item.classList.add('textInList');
            for(let element of allPaths){
                let a=element.getAttribute("data");
                if(uniqNames[i]==a){
                    let b=element.getAttribute("dataid");
                    item.setAttribute("dataid",b );
                    item.appendChild(document.createTextNode(uniqNames[i]));
                    drUL.appendChild(item);
                    break;
                }
            }
        }
        names=[];
        uniqNames=[];     
}



dr.addEventListener('mouseover', function(e){
    if(e.target.classList.contains('textInList')){
        e.target.style.backgroundColor="rgb(15, 130, 175)";
        e.target.style.borderRadius="1vh";

    }
})
dr.addEventListener('mouseout', function(e){
    if(e.target.classList.contains('textInList')){
        e.target.style.backgroundColor="rgb(255, 208, 0)";
        e.target.style.borderRadius="0vh";
    }
})

dr.addEventListener('click', function(e){
    if(e.target.hasAttribute('dataid')){
        let a=e.target.getAttribute("dataid");
        getAnimalByID(a);
        
    }
})


function deleteListForDr(){

    drLI=drUL.querySelectorAll("li");
    for(let element of drLI){
        element.remove();
    }


}

function creatingDropRight(){
    if(btn.getAttribute("pressed")==1){
        deleteListForDr();
        dr.style.zIndex="4";
        dr.style.display="table-row";
        dr.style.marginLeft="19%"
        dr.style.opacity="1"
        btn.setAttribute("pressed","0")
        addListForDr();
        
    }

}

btn.onclick=function(){
    creatingDropRight() ;  
}


mapContainer.addEventListener('click', function(e){
    if(btn.getAttribute('pressed')==1){  
        dr.style.zIndex="0";
        dr.style.display="table-row";
        dr.style.marginLeft="100%"
        dr.style.opacity="0.1";
        
        btn.setAttribute("pressed","1"); 
        
        
    }
    else{
        dr.onclick=function(){  
            dr.style.zIndex="4";
            dr.style.display="table-row";
            btn.setAttribute("pressed","0");
            
        }
    }
    btn.setAttribute("pressed","1");
});

const apiUrl='https://localhost:44332/api/AnimalsTables/';
const apiImageUrl='https://localhost:44332/api/AnimalsImage/';

async function getAnimalByID(id){

    const response=await fetch(apiUrl+id);
    const responseImage=await fetch(apiImageUrl+id);
    const data= await response.json();
    const dataImage= await responseImage.blob();
    imageObjectURL = URL.createObjectURL(dataImage);
    

    let htmlElements=`<div style="float:right;width:50%;height:50%"><img src="${imageObjectURL}" style="width:100%;height:100%;"></img></div>`;
    htmlElements+='<p>Name:</p> ';
    htmlElements+=`<p>${data.animalName}</p><hr>`;
    htmlElements+='<p>Count:</p>';
    htmlElements+=`<p>${data.animalCount}</p><hr>`;
    htmlElements+='<p>Description:</p>';
    htmlElements+=`<p>${data.animalDescription}</p><hr>`;
   

    document.getElementById("drop_info").innerHTML=htmlElements;
}



