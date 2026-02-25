// api/repositories/SpeciesRepository.js
const { DbError } = require("../errors");

class SpeciesRepository {
  constructor(db) {
    this.Species = db.Species;
  }

  async getAll() {
    try {
      return await this.Species.findAll();
    } catch (error) {
      throw new DbError("Failed to fetch species", { details: error.message });
    }
  }

  async getById(id) {
    try {
      return await this.Species.findOne({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to fetch species", { details: error.message, data: id });
    }
  }

  async create(data) {
    try {
      return await this.Species.create(data);
    } catch (error) {
      throw new DbError("Failed to create species", { details: error.message, data });
    }
  }

  async update(data, id = data.id) {
    try {
      return await this.Species.update(data, { where: { id } });
    } catch (error) {
      throw new DbError("Failed to update species", { details: error.message, data });
    }
  }

  async delete(id) {
    try {
      return await this.Species.destroy({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to delete species", { details: error.message, data: id });
    }
  }
}

module.exports = SpeciesRepository;
