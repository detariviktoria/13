const express = require("express");
const router = express.Router();

const animalController = require("../controllers/animalController");
//const authMiddleware = require("../middlewares/authMiddleware");

router.get("/", animalController.getAnimals);
router.post("/", animalController.createAnimal);

router.param("animalID", (req, res, next, animalID) => {
    req.animalID = animalID;
    next();
});

router.get("/:animalID", animalController.getAnimal);
router.put("/:animalID", animalController.updateAnimal);
router.delete("/:animalID", animalController.deleteAnimal);

module.exports = router;
