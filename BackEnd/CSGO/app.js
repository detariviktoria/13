const express = require("express");

const app = express();

app.use(express.urlencoded({ extended: true }));

// const errorHandler = require("./api/middlewares/errorHandler");

const weaponRoutes = require("./api/routes/weaponRoutes");

app.use("/weapons", weaponRoutes);

// app.use(errorHandler);

module.exports = app;