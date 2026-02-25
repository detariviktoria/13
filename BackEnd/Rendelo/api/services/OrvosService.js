const { DbError } = require("../errors");

const { Op } = require("sequelize");

class OrvosService {
    constructor(db)
    {
        this.repository = db.repository;
    }

    async getOrvosok()
    {
        return await this.repository.getOrvosok();
    }


    async getOrvos(orvosAdatok)
    {
        if(!orvosID) throw new Error("TODO");
        return await this.repository.getOrvos(orvosID);
    }

    async createOrvos(orvosAdatok)
    {
        this.validaiteOrvosAdat(orvosAdatok);

        return await this.repository.createOrvos(orvosAdatok);
    }

    async updateOrvos(orvosID, orvosAdatok)
    {
        if(!orvosID) throw new Error("TODO");

        this.validaiteOrvosAdat(orvosAdatok);

        return await this.repository.updateOrvos(orvosID, orvosAdatok);
    }

    async deleteOrvos(orvosID)
    {
        if(!orvosID) throw new Error("TODO");
        return await this.repository.deleteOrvos(orvosID);
    }

    validaiteOrvosAdat(orvosAdatok)
    {
        if(!orvosAdatok) throw new Error("TODO");

        if(!orvosAdatok.nev) throw new Error("TODO");
    }
}

ex
