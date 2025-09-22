const express = require("express");

const router = express.Router();

const animalController = require("../controllers/animalController");

router.get("/", animalController.getAnimals);

router.post("/", animalController.getAnimals); // hozzá kell kötnünk az alkalamzásunkhoz
module.exports = router;