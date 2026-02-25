const express = require("express");
const router = express.Router();

const adoptionController = require("../controllers/adoptionController");

router.get("/", adoptionController.getAll);
router.post("/", adoptionController.create);

router.param("adoptionID", (req, res, next, adoptionID) => {
    req.adoptionID = adoptionID;
    next();
});

router.get("/:adoptionID", adoptionController.getById);
router.put("/:adoptionID", adoptionController.update);
router.delete("/:adoptionID", adoptionController.delete);

module.exports = router;
