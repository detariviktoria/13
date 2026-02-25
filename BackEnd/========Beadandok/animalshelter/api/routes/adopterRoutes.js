const express = require("express");
const router = express.Router();

const adopterController = require("../controllers/adopterController");

router.get("/", adopterController.getAll);
router.post("/", adopterController.create);

router.param("adopterID", (req, res, next, adopterID) => {
    req.adopterID = adopterID;
    next();
});

router.get("/:adopterID", adopterController.getById);
router.put("/:adopterID", adopterController.update);
router.delete("/:adopterID", adopterController.delete);

module.exports = router;
