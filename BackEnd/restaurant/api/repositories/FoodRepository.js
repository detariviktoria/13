class FoodRepository
{
    constructor(db)
    {
        this.Foods = db.Foods;
    }

    async getFoods()
    {
        try
        {
            return await this.Foods.findAll();
        }
        catch(error)
        {
            throw new Error("DbError");
        }
    }
}

module.exports = FoodRepository;