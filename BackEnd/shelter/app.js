const express = require("express");

const app = express();

const api = express();

const errorHandler = require("./api/middlewares/errorHandler");

const path = require("path");

app.use(express.json());

app.use(express.urlencoded({ extended: true }));

app.use(express.static("public"));
// app.use(express.static(path.join(__dirname, "public", "images")));
// app.use(express.static(path.join(__dirname, "public", "files")));

app.set("view engine", "ejs");

app.use("/api", api);

const animalRoutes = require("./api/routes/animalRoutes");
const shelterRoutes = require("./api/routes/shelterRoutes");

api.use("/animals", animalRoutes);
api.use("/shelters", shelterRoutes);

api.use(errorHandler.notFound);
app.use(errorHandler.notFound);
app.use(errorHandler.showError);

module.exports = app;