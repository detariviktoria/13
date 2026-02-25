const { DbError } = require("../errors");

const { Op } = require("sequelize");

class OrvosRepository {
    constructor(db)
    {
        this.Orvos = db.Orvos;
    }

    async getOrvos()
    {
        try 
        {
            return await this.Orvos.findAll();
        }
         catch (error) 
        {
            throw new Error("TODO");
        }
    }


    async createOrvos(orvosAdatok)
    {
        try
        {
            return await this.Orvos.create(orvosAdatok);
        } 
        catch (error) 
        {
            throw new Error("TODO");
        }
    }
}
