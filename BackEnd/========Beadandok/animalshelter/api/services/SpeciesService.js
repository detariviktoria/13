// api/services/SpeciesService.js
const { BadRequestError, NotFoundError } = require("../errors");

class SpeciesService {
  constructor(db) {
    this.speciesRepository = require("../repositories")(db).speciesRepository;
  }

  async getAll() {
    return await this.speciesRepository.getAll();
  }

  async getById(id) {
    if (!id) throw new BadRequestError("Missing species ID");
    const species = await this.speciesRepository.getById(id);
    if (!species) throw new NotFoundError("Species not found", { data: id });
    return species;
  }

  async create(data) {
    if (!data || !data.name) throw new BadRequestError("Missing species name");
    return await this.speciesRepository.create(data);
  }

  async update(data, id) {
    if (!data || !id) throw new BadRequestError("Missing data or species ID");
    return await this.speciesRepository.update(data, id);
  }

  async delete(id) {
    if (!id) throw new BadRequestError("Missing species ID for deletion");
    return await this.speciesRepository.delete(id);
  }
}

module.exports = SpeciesService;
