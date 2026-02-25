const ShelterRepository = require("../repositories/ShelterRepository");

const ShelterService = require("./ShelterService");

module.exports = (db) =>
{
    const shelterRepository = new ShelterRepository(db);

    const shelterService = new ShelterService(shelterRepository);

    return { shelterService };
}