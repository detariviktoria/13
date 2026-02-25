const express = require("express");

const app = express();

const api = express();

const errorHandler = require("./api/middlewares/errorHandler");

app.use(express.json());

app.use(express.urlencoded({ extended: true }));

app.use("/api", api);

const studentRoutes = require("./api/routes/studentRoutes");

api.use("/students", studentRoutes);

app.use(errorHandler.notFound);
api.use(errorHandler.notFound);
app.use(errorHandler.showError);


module.exports = app;