const express = require("express");

const router = express.Router();

const catController = require("../controllers/catController");

router.param("catName", (req, res, next, catName) => 
{
    req.catName = catName;

    next();
});

router.get("/cats", catController.getCats);

router.get("/cats/:catName", catController.getCat);

router.post("/cats/:catName", catController.createCat);



module.exports = router;