const express = require("express");

const app = express();

app.use(express.json());

app.use(express.urlencoded({ extended: true }));

app.disable("x-powered-by");

const studentRoutes = require("./api/routes/studentRoutes");

app.use("/students", studentRoutes);

const errorHandler = require("./api/middlewares/errorHandler");

app.use(errorHandler);

module.exports = app;