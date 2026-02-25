const express = require("express");
const cors = require("cors");

const app = express();

// --- CORS beállítás ---
app.use(cors({
  origin: ["http://localhost:3001", "https://discordapp.com"],
  methods: ["GET", "POST", "PATCH", "PUT", "DELETE"],
}));


app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Route-ok
//const userRoutes = require("./api/routes/userRoutes");
const animalRoutes = require("./api/routes/animalRoutes");
const speciesRoutes = require("./api/routes/speciesRoutes");
const locationRoutes = require("./api/routes/locationRoutes");
const adopterRoutes = require("./api/routes/adopterRoutes");
const adoptionRoutes = require("./api/routes/adoptionRoutes");
const vetRoutes = require("./api/routes/vetRoutes");
const appointmentRoutes = require("./api/routes/appointmentRoutes");

// Hibakezelő middleware
const { notFound, showError } = require("./api/middlewares/errorHandler");

// Routes hozzárendelése
//app.use("/api/users", userRoutes);
app.use("/api/animals", animalRoutes);
app.use("/api/species", speciesRoutes);
app.use("/api/locations", locationRoutes);
app.use("/api/adopters", adopterRoutes);
app.use("/api/adoptions", adoptionRoutes);
app.use("/api/vets", vetRoutes);
app.use("/api/appointments", appointmentRoutes);

// endpoint teszthez
app.get("/", (req, res) => {
  res.json({ message: "Welcome to the Animal Shelter API 🐾" });
});

// Hibakezelés
app.use(notFound);   
app.use(showError); 

module.exports = app;
