// api/services/VetsService.js
const { BadRequestError, NotFoundError } = require("../errors");

class VetService {
  constructor(db) {
    this.vetRepository = require("../repositories")(db).vetRepository;
  }

  async getAll() {
    return await this.vetRepository.getAll();
  }

  async getById(id) {
    if (!id) throw new BadRequestError("Missing vet ID");
    const vet = await this.vetRepository.getById(id);
    if (!vet) throw new NotFoundError("Vet not found", { data: id });
    return vet;
  }

  async create(data) {
    if (!data || !data.name) throw new BadRequestError("Missing vet name");
    return await this.vetRepository.create(data);
  }

  async update(data, id) {
    if (!data || !id) throw new BadRequestError("Missing data or vet ID");
    return await this.vetRepository.update(data, id);
  }

  async delete(id) {
    if (!id) throw new BadRequestError("Missing vet ID for deletion");
    return await this.vetRepository.delete(id);
  }
}

module.exports = VetService;
