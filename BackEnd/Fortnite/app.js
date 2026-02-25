const express = require("express");

const app = express();

const authRoutes = require("./api/routes/authRoutes")

const api = express();

app.use(express.json());

app.use(express.urlencoded({ extended: true }));
app.use('/api', api);
app.use('/auth', authRoutes);


const errorHandler = require("./api/middlewares/errorHandler");
app.use(errorHandler.showError);
app.use(errorHandler.notFound);

module.exports = { app, api };