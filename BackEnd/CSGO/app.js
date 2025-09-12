const express = require("express");

const app = express();


app.use(express)
// fegyverek lekérése
const weaponsRoutes = require("./api/routes/weaponRoutes");


app.use("/weapons", weaponRoutes);
//app.use(errorHandle)

module.exports = app;
