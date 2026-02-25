const { Animals } = require("../db");

exports.getAnimals = async (req, res, next) =>
{
    const animals = await Animals.findAll();

    res.format(
    {
        html: () =>
        {
            res.status(200).render("pages/animal", { animals });
        },

        json: () =>
        {
            res.status(200).json(animals);
        },

        text: () => 
        {
            res.status(200).send("Success");
        },

        pdf: () =>
        {
            res.status(200).download("./public/files/animals.pdf");
        }
    });
}