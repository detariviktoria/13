const express = require("express");
const router = express.Router();

const vetController = require("../controllers/vetController");

router.get("/", vetController.getAll);
router.post("/", vetController.create);

router.param("vetID", (req, res, next, vetID) => {
    req.vetID = vetID;
    next();
});

router.get("/:vetID", vetController.getById);
router.put("/:vetID", vetController.update);
router.delete("/:vetID", vetController.delete);

module.exports = router;
