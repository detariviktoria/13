const express = require("express");
const router = express.Router();

const appointmentController = require("../controllers/appointmentController");

router.get("/", appointmentController.getAll);
router.post("/", appointmentController.create);

router.param("appointmentID", (req, res, next, appointmentID) => {
    req.appointmentID = appointmentID;
    next();
});

router.get("/:appointmentID", appointmentController.getById);
router.put("/:appointmentID", appointmentController.update);
router.delete("/:appointmentID", appointmentController.delete);

module.exports = router;
