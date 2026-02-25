const express = require("express");

const router = express.Router();

const weaponController = require("../controllers/weaponController");

router.get("/", weaponController.getWeapons);

router.patch("/", weaponController.updateWeapon);

module.exports = router;