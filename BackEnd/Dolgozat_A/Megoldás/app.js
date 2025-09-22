const express = require("express");
const app = express();

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// A root folderben található errorHandler.js file-t 
// használd fel a tanult módon. 
const errorHandler = require("./api/middlewares/errorHandler");
app.use(errorHandler);


// Készíts egy routert, ami a /watches útvonalra fog hallgatni
const watchRoutes = require("./api/routes/watchRoutes");
app.use("/watches", watchRoutes);

module.exports = app;