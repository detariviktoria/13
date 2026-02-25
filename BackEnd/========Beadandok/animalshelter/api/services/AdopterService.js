// api/services/AdoptersService.js
const { BadRequestError, NotFoundError } = require("../errors");

class AdoptersService {
  constructor(db) {
    this.adopterRepository = require("../repositories")(db).adopterRepository;
  }

  async getAll() {
    return await this.adopterRepository.getAll();
  }

  async getById(id) {
    if (!id) throw new BadRequestError("Missing adopter ID");
    const adopter = await this.adopterRepository.getById(id);
    if (!adopter) throw new NotFoundError("Adopter not found", { data: id });
    return adopter;
  }

  async create(data) {
    if (!data || !data.name || !data.email) throw new BadRequestError("Missing adopter data");
    return await this.adopterRepository.create(data);
  }

  async update(data, id) {
    if (!data || !id) throw new BadRequestError("Missing data or adopter ID");
    return await this.adopterRepository.update(data, id);
  }

  async delete(id) {
    if (!id) throw new BadRequestError("Missing adopter ID for deletion");
    return await this.adopterRepository.delete(id);
  }
}

module.exports = AdoptersService;
