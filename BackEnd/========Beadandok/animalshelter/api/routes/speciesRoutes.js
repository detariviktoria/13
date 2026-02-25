const express = require("express");
const router = express.Router();

const speciesController = require("../controllers/speciesController");

router.get("/", speciesController.getAll);
router.post("/", speciesController.create);

router.param("speciesID", (req, res, next, speciesID) => {
    req.speciesID = speciesID;
    next();
});

router.get("/:speciesID", speciesController.getById);
router.put("/:speciesID", speciesController.update);
router.delete("/:speciesID", speciesController.delete);

module.exports = router;
