const express = require("express");

const app = express();

const api = express();

const errorHandler = require("./api/middlewares/errorHandler");

app.use(express.json());

app.use(express.urlencoded({ extended: true }));

app.use("/api", api);

const animalRoutes = require("./api/routes/animalRoutes");

api.use("/animals", animalRoutes);

api.use(errorHandler.notFound);
app.use(errorHandler.notFound);
app.use(errorHandler.showError);

module.exports = app;