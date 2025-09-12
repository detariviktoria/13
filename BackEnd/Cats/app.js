const express = require("express");

const app = express();

app.use(express.urlencoded({ extended: true }));

// MVC = ModelViewController

const catRoutes = require("./api/routes/catRoutes");

const errorHandler = require("./api/middlewares/errorHandler");

const userRoutes = require("./api/routes/userRoutes");

app.use("/", catRoutes);

app.use("/users", userRoutes);

app.use(errorHandler);

module.exports = app;