const express = require("express");
const router = express.Router();

const locationController = require("../controllers/locationController");

router.get("/", locationController.getAll);
router.post("/", locationController.create);

router.param("locationID", (req, res, next, locationID) => {
    req.locationID = locationID;
    next();
});

router.get("/:locationID", locationController.getById);
router.put("/:locationID", locationController.update);
router.delete("/:locationID", locationController.delete);

module.exports = router;
