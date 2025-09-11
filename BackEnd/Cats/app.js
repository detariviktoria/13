//kívülről elérhető legyen a port
const express = require("express");

const app = express();


// MVC = ModelViewContoller

const catRoute = require("./api/routes/catRoutes");


const errorHandle = requre("./api/middlewares/error")
app.use("/", catRoute);
module.exports = app;
