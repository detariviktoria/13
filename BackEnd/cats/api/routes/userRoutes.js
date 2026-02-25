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
    try
    {
        const { userName, password } = req.body;

        if(users.some(item => item.name === userName))
        {
            const error = new Error("Ez a nevú felhasználó már létezik!");

            error.status = 400;

            throw error;
        }

        users.push(
        {
            name: userName,
            password: password,
        });

        res.status(201).send(`${userName} nevű felhasználó regisztrálva lett!`);
    }
    catch(error)
    {
        next(error);
    }
})

module.exports = router;