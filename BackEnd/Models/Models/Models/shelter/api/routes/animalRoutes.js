const express = require("express");

const router = express.Router();

const animalController = require("../controllers/animalController");

router.get("/", animalController.getAnimals);

module.exports = router;