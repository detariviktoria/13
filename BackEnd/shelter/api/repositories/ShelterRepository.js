const { DbError } = require("../errors");

class ShelterRepository
{
    constructor(db)
    {
        this.Shelters = db.Shelters;
    }

    async getShelters()
    {
        try
        {
            return await this.Shelters.findAll(
            {
                include: [ "animals" ],
            });
        }
        catch(error)
        {
            throw new DbError("Failed fetching shelters", { details: {msg: error.message, sqlMsg: error.sqlMessage} });
        }
    }

    async createShelter(data)
    {
        return await this.Shelters.create(data);
    }
}

module.exports = ShelterRepository;