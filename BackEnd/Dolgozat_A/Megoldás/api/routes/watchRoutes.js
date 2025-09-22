const express = require("express");

const router = express.Router();

// Ehhez a routerhez készíts egy controllert is 
//(tanult elnevezéssel)
const watchController = require("../controllers/watchController");

router.get("/", watchController.getWatches);

router.param("watchBrand", (req, res, next, watchBrand) => 
{
    req.watchBrand = watchBrand;

    next();
})

router.get("/:watchBrand", watchController.getWatchesByBrand);

router.delete("/", watchController.deleteWatch);

module.exports = router;