const { DbError } = require("../errors");

class LocationRepository {
  constructor(db) {
    this.Locations = db.Locations;
  }

  async getAll() {
    try {
      return await this.Locations.findAll();
    } catch (error) {
      throw new DbError("Failed to fetch locations", { details: error.message });
    }
  }

  async getById(id) {
    try {
      return await this.Locations.findOne({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to fetch location", { details: error.message, data: id });
    }
  }

  async create(data) {
    try {
      return await this.Locations.create(data);
    } catch (error) {
      throw new DbError("Failed to create location", { details: error.message, data });
    }
  }

  async update(data, id = data.id) {
    try {
      return await this.Locations.update(data, { where: { id } });
    } catch (error) {
      throw new DbError("Failed to update location", { details: error.message, data });
    }
  }

  async delete(id) {
    try {
      return await this.Locations.destroy({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to delete location", { details: error.message, data: id });
    }
  }
}

module.exports = LocationRepository;
