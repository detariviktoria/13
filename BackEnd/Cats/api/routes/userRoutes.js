const express = require("express");

const router = express.Router();

const users =
[
    {
        name: "User1",
        password: "jelszo123"
    },
    {
        name: "User2",
        password: "123jelszo"
    },
]

router.get("/", (req, res, next) => 
{
    res.status(200).json(users);
})

router.post("/", (req, res, next) => 
{
    


}

)

module.exports = router;