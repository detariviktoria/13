// api/services/AdoptionsService.js
const { BadRequestError, NotFoundError } = require("../errors");

class AdoptionsService {
  constructor(db) {
    this.adoptionRepository = require("../repositories")(db).adoptionRepository;
  }

  async getAll() {
    return await this.adoptionRepository.getAll();
  }

  async getById(id) {
    if (!id) throw new BadRequestError("Missing adoption ID");
    const adoption = await this.adoptionRepository.getById(id);
    if (!adoption) throw new NotFoundError("Adoption not found", { data: id });
    return adoption;
  }

  async create(data) {
    if (!data || !data.animalID || !data.adopterID) throw new BadRequestError("Missing adoption data");
    return await this.adoptionRepository.create(data);
  }

  async update(data, id) {
    if (!data || !id) throw new BadRequestError("Missing data or adoption ID");
    return await this.adoptionRepository.update(data, id);
  }

  async delete(id) {
    if (!id) throw new BadRequestError("Missing adoption ID for deletion");
    return await this.adoptionRepository.delete(id);
  }
}

module.exports = AdoptionsService;
