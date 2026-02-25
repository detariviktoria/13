const express = require("express");
const cors = require("cors");

const app = express();
const api = express();

// CORS beállítások
app.use(cors(
{
    origin: [ "http://localhost:3001", "https://discordapp.com" ],
    methods: [ "GET", "POST", "PATCH", "PUT", "DELETE" ],
}));

// Body parsing
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

const userRoutes = require("./api/routes/userRoutes");
const errorHandler = require("./api/middlewares/errorHandler");
const authRoutes = require("./api/routes/authRoutes");

app.use("/api", api);
api.use("/users", userRoutes);
api.use("/auth", authRoutes);

api.use(errorHandler.notFound);
app.use(errorHandler.showError);
app.use(errorHandler.notFound);

module.exports = app;