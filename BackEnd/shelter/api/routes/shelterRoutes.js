const express = require("express");

const router = express.Router();

const shelterController = require("../controllers/shelterController");

router.get("/", shelterController.getShelters);

module.exports = router;