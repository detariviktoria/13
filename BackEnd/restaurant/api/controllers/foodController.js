module.exports = 
{
    getFoods: (req, res, next) => 
    {
        try
        {
            res.status(200).send("OK!");
        }
        catch(error)
        {
            next(error);
        }
    },

    addFood: (req, res, next) => 
    {
        try
        {
            res.status(201).json({});
        }
        catch(error)
        {
            next(error);
        }
    },

    updateFood: (req, res, next) => 
    {
        try
        {
            res.status(200).json({});
        }
        catch(error)
        {
            next(error);
        }
    },
}