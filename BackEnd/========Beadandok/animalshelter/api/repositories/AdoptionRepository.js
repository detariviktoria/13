// api/repositories/AdoptionsRepository.js
const { DbError } = require("../errors");

class AdoptionRepository {
  constructor(db) {
    this.Adoptions = db.Adoptions;
  }

  async getAll() {
    try {
      return await this.Adoptions.findAll();
    } catch (error) {
      throw new DbError("Failed to fetch adoptions", { details: error.message });
    }
  }

  async getById(id) {
    try {
      return await this.Adoptions.findOne({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to fetch adoption", { details: error.message, data: id });
    }
  }

  async create(data) {
    try {
      return await this.Adoptions.create(data);
    } catch (error) {
      throw new DbError("Failed to create adoption", { details: error.message, data });
    }
  }

  async update(data, id = data.id) {
    try {
      return await this.Adoptions.update(data, { where: { id } });
    } catch (error) {
      throw new DbError("Failed to update adoption", { details: error.message, data });
    }
  }

  async delete(id) {
    try {
      return await this.Adoptions.destroy({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to delete adoption", { details: error.message, data: id });
    }
  }
}

module.exports = AdoptionRepository;
