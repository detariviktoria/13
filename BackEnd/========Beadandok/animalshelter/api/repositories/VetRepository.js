// api/repositories/VetsRepository.js
const { DbError } = require("../errors");

class VetRepository {
  constructor(db) {
    this.Vets = db.Vets;
  }

  async getAll() {
    try {
      return await this.Vets.findAll();
    } catch (error) {
      throw new DbError("Failed to fetch vets", { details: error.message });
    }
  }

  async getById(id) {
    try {
      return await this.Vets.findOne({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to fetch vet", { details: error.message, data: id });
    }
  }

  async create(data) {
    try {
      return await this.Vets.create(data);
    } catch (error) {
      throw new DbError("Failed to create vet", { details: error.message, data });
    }
  }

  async update(data, id = data.id) {
    try {
      return await this.Vets.update(data, { where: { id } });
    } catch (error) {
      throw new DbError("Failed to update vet", { details: error.message, data });
    }
  }

  async delete(id) {
    try {
      return await this.Vets.destroy({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to delete vet", { details: error.message, data: id });
    }
  }
}

module.exports = VetRepository;
