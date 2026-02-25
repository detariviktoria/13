const { BadRequestError, NotFoundError } = require("../errors");

class LocationService {
  constructor(db) {
    this.locationRepository = require("../repositories")(db).locationRepository;
  }

  async getAll() {
    return await this.locationRepository.getAll();
  }

  async getById(id) {
    if (!id) throw new BadRequestError("Missing location ID");
    const loc = await this.locationRepository.getById(id);
    if (!loc) throw new NotFoundError("Location not found", { data: id });
    return loc;
  }

  async create(data) {
    if (!data || !data.name) throw new BadRequestError("Missing location name");
    return await this.locationRepository.create(data);
  }

  async update(data, id) {
    if (!data || !id) throw new BadRequestError("Missing data or location ID");
    return await this.locationRepository.update(data, id);
  }

  async delete(id) {
    if (!id) throw new BadRequestError("Missing location ID for deletion");
    return await this.locationRepository.delete(id);
  }
}

module.exports = LocationService;
