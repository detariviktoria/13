const express = require("express");

const app = express();

const api = express();

const foodRoutes = require("./api/routes/foodRoutes");

app.use("/api", api);

api.use("/foods", foodRoutes);

module.exports = app;