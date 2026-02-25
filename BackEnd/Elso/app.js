const express = require("express");

const app = express();

// GET, POST, PUT, PATCH, DELETE, OPTIONS

// localhost:3000

// MIDDLWARE

// app.use("/cica", (req, res, next) => 
// {
//     console.log(`A ${req.url} lett elérve!` );

//     next();
// })

// app.get(["/", "/alma", "/barack"], (req, res, next) => 
// {
//     res.status(200).send("Jó reggelt!");
// })

// twitch.tv/kriszhadvice
// twitch.tv/wearethevr/dashboard



app.param("userName", (req, res, next, userName) => {
    req.user = userName; 
    next();
})

app.get("/users/:userName", (req, res, next) => 
{
    
    // const currentUserName = req.params["userName"];

    res.status(200).send(`Jelenlegi felhasználónév: ${req.user}` )
})
// /users/:userName/post/10
// Válasz: A ${userName} ${postNumber}. posztja

app.get("/users/:userName/post/:postNumber", (req, res, next) =>
{
    res.status(200).send(`A ${req.user} ${res.postNumber}.posztja`)
})

//POSTMAN
// /users (GET)
// /users (POST)

app.get("/register", (req, res, next) =>
{
    res.status(200).send(`Regiszer page`)
})

app.post("/register", (req, res, next) => {
    res.status(201).send("A felhasználó regisztrálva lett.")
})

module.exports = app;