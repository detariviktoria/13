const { DbError } = require("../errors");

class AdopterRepository {
  constructor(db) {
    this.Adopters = db.Adopters;
  }

  async getAll() {
    try {
      return await this.Adopters.findAll();
    } catch (error) {
      throw new DbError("Failed to fetch adopters", { details: error.message });
    }
  }

  async getById(id) {
    try {
      return await this.Adopters.findOne({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to fetch adopter", { details: error.message, data: id });
    }
  }

  async create(data) {
    try {
      return await this.Adopters.create(data);
    } catch (error) {
      throw new DbError("Failed to create adopter", { details: error.message, data });
    }
  }

  async update(data, id = data.id) {
    try {
      return await this.Adopters.update(data, { where: { id } });
    } catch (error) {
      throw new DbError("Failed to update adopter", { details: error.message, data });
    }
  }

  async delete(id) {
    try {
      return await this.Adopters.destroy({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to delete adopter", { details: error.message, data: id });
    }
  }
}

module.exports = AdopterRepository;
