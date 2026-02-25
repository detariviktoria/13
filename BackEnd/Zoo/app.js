//!!!
const express = require("express");

const app = express();


app.use(express.json());
///------------------

app.use(express.urlencoded({ extended: true }));

//!!!!!!
const animalRoutes = require("./api/routes/animalRoutes");

app.get("/", (req, res, next) => 
{
    res.status(302).redirect("/animals");
})

app.use("/animals", animalRoutes); // !!!



module.exports = app;//!!