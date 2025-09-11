// document.getElementById("dbInput").addEventListener("input", generateBoxes);

// function generateBoxes() {
//     let db = parseInt(document.getElementById("dbInput").value);
//     const boxes = document.getElementById("boxes");

//     boxes.innerHTML = "";

//     for (let i = 0; i < db; i++) {
//         const box = document.createElement("div");
//         box.innerHTML = i + 1; 
//         boxes.appendChild(box);
//     }
// }



//2.Feladat
// document.getElementById("dbInput").addEventListener("input", generateBoxes);

// function generateBoxes() {
//     let db = parseInt(document.getElementById("dbInput").value);
//     const boxes = document.getElementById("boxes");

    
//     const currentBoxes = boxes.children;
//     const currentBoxCount = currentBoxes.length;

    
//     if (db < currentBoxCount+1) {
//         boxes.removeChild(currentBoxes[currentBoxCount-1]);
//     }
   
//     else if (db > currentBoxCount) {
//         const box = document.createElement("div");
//         box.innerHTML = db; 
//         boxes.appendChild(box);
//     }
// }

//2.Feladat
// let a = 0;
// function boxGeneration(){
//     const boxes = document.getElementById("boxes");
//     let akt = parseInt(document.getElementById("dbInput").value);
//     if(akt > a){
//         const ujbox = document.createElement("div");
//         ujbox.innerHTML = akt;
//         boxes.appendChild(ujbox);
//         a++;
        
//     }
//     else{
//         boxes.removeChild(boxes.lastChild);
//         a--;
//     }
// }


// const tegla = document.getElementById("tegla");
// const kor = document.getElementById("kor");
// if(tegla.value == true)
// {
//     generate("tegla");
// }
// generate("kor");
// function generate(check)
// {
//     const boxes = document.getElementById("boxes");
//     const ujbox = document.createElement("div");
//     ujbox.innerHTML = akt;
//     boxes.appendChild(ujbox);
// }

function boxGeneration(params)
{
    const boxes = document.createElement("boxes");
    const ujbox = ujBoxGen(params);
    boxes.appendChild(ujbox);
    a++;

}

function ujBoxGen(params)
{
    const ujbox = document.createElement("div");
    ujbox.innerHTML = a;
    if(params == `kor`)
        ujbox.style.borderRadius  = 
}
