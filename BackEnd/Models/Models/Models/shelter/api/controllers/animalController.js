const { Animals } = require("../db");

exports.getAnimals = async (req, res, next) =>
{
    const animal = await Animals.create(
    {
        name: "Teszt",
        age: 6,
    });

    res.status(200).json(animal);
}