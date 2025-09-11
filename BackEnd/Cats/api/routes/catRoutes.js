const express = require("express");

const router = express.Router();

const cats = [
    {
        name: "Cirmi",
        gender: "Nő",
    },
    {
        name: "Bodri",
        gender: "Férfi",
    },
    {
        name: "Tiramisu",
        gender: "Nő",
    },
]

//utvonal
router.get("/", (req, res, next) =>
{
    //válasz HTML-el
    res.status(200).send("<p>Elérhető endpointok:</p><a href='http://localhost:3000/cats'>Cats</a>")
})

router.get("/cats", (req, res, next) =>
{
    res.status(200).json(cats);
})

// Endpoint: /cats/catName
// Metodus: POST
// Művelet: cats tömbünkbe szúrjunk be egy uj elemet egyéb nemmel
// Válasz: ${catName} sikeresen befogadva
// Ha lehet és emlékszel rá: paraméter middleware-el

router.param("catName", (req, res, next, catName) =>
{
    req.catName = catName;

    next();
})

router.post("/cats/:catName", (req, res, next) => {

    try {
        for(let cat of cats)
    {
        if(cat.name == req.catName)
        {
            const error = new Error("Ez a macska már bent van a menhelyen.");
            error.status = 400;
            throw error;
        }
    }

    cats.push(
        {
            name: req.catName,
            gender: "Egyéb"
        }
    );
    res.status(201).send(`A ${req.catName} nevű macska be lett fogadva`)
    } catch (error) {
        next(error);
    }
})

router.get("/cats/:catName", (req, res, next) =>
{
    res.status(200).json(cats.filter(item.name == req.catName));
})

module.exports = router;