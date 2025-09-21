const tabla = document.querySelector("#fotabla"); // a fő táblázat, ahova a termékeket rajzoljuk
const creatediv = document.querySelector("#creatediv"); // az űrlap doboza, ahol az input mezők vannak.
const divupdate = document.querySelector("#divupdate"); // a Módosítás gomb az űrlapon.
const createbutton = document.querySelector("#create1"); // a Hozzáadás gomb az űrlapon.
const creategomb = document.querySelector("#create"); // az Új termék gomb, ami előhozza az űrlapot.

// ------------------------------------------------
// induláskor a módosítás gomb legyen rejtve
divupdate.classList.add("nemmutat");
//------------------------------------------
// táblázat kirajzolása
function showTable() {
    let out = "";
    for (let i = 0; i < products.length; i++) { // végigmegyünk a products tömbön 
        out += `
        <tr id="${products[i].id}">
            <td>${products[i].name}</td>
            <td>${products[i].price}</td>
            <td>${products[i].quantity}</td>
            <td><button class="update" index="${i}">✍️</button></td> 
            <td><button class="delete" index="${i}">❌</button></td>
        </tr>`;
        // name="${i}" → a gombok tudják, melyik indexű termékről van szó.
    }
    tabla.innerHTML = out; // beilleszti az összes sort a táblázatba
}
showTable();
//------------------------------------------------

// eseménykezelők a táblázatra 
// minden kattintást egyszerre figyelünk a táblázatban 
tabla.addEventListener("click", (e) => {
    let index = e.target.index; // indexet kapjuk vissza a products tömből

    if (e.target.classList.contains("delete")) {
        // törlés splice(start, deleteCount)
        products.splice(index, 1);
        showTable();
    }

    if (e.target.classList.contains("update")) {
        // szerkesztés
        showCreate();
         
        //input mezok lekérése
        let nev = document.querySelector("#nevinput");
        let ar = document.querySelector("#arinput");
        let mennyiseg = document.querySelector("#mennyiseginput");

        // kitöltjuk az aktuális termék adataival
        nev.value = products[index].name;
        ar.value = products[index].price;
        mennyiseg.value = products[index].quantity;

        // Hozzáadás gomb marad látható, csak a módosítás gomb jelenik meg
        divupdate.classList.remove("nemmutat");

        divupdate.onclick = () => {
            updateObject(index, nev, ar, mennyiseg);
        };
    }
});

// meglévő termék módosítása
function updateObject(index, nev, ar, mennyiseg) {
    products[index] = {
        id: products[index].id,
        name: nev.value,
        price: ar.value,
        quantity: mennyiseg.value
    };
    showTable();
}
//-----------------------------------------

createbutton.addEventListener("click", newObject);

// új termék hozzáadása
function newObject() {
    const nev = document.querySelector("#nevinput").value;
    const ar = document.querySelector("#arinput").value;
    const mennyiseg = document.querySelector("#mennyiseginput").value;

    products.push({
        id: products.length > 0 ? products[products.length - 1].id + 1 : 1,
        name: nev,
        price: ar,
        quantity: mennyiseg
    });

    showTable();

    // Új termék hozzáadás után az űrlap eltűnik
    creatediv.classList.remove("mutat");
    creatediv.classList.add("nemmutat");
    clearInputs();
}

//------------------------------------------------------
// űrlap mutatása
function showCreate() {
    creatediv.classList.remove("nemmutat");
    creatediv.classList.add("mutat");
// Új termék gomb megnyomására minden input üres legyen
    clearInputs();
}

//-------------------------------
// inputok törlése
function clearInputs() {
    document.querySelector("#nevinput").value = "";
    document.querySelector("#arinput").value = "";
    document.querySelector("#mennyiseginput").value = "";
}

// gombok eseménykezelői

creategomb.addEventListener("click", showCreate);
