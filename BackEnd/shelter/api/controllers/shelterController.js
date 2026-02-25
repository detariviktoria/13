const db = require("../db");

const { shelterService } = require("../services")(db);

exports.getShelters = async (req, res, next) =>
{
    try
    {
        const shelters = await shelterService.getShelters();

        shelters[0].destroy();

        res.format(
        {
            html: () => 
            {
                res.status(200).render("pages/shelter", { shelters })
            },

            json: () => 
            {
                res.status(200).json(shelters);
            },
        });
    }
    catch(error)
    {
        next(error);
    }
}