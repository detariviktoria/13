// api/repositories/AppointmentsRepository.js
const { DbError } = require("../errors");

class AppointmentRepository {
  constructor(db) {
    this.Appointments = db.Appointments;
  }

  async getAll() {
    try {
      return await this.Appointments.findAll();
    } catch (error) {
      throw new DbError("Failed to fetch appointments", { details: error.message });
    }
  }

  async getById(id) {
    try {
      return await this.Appointments.findOne({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to fetch appointment", { details: error.message, data: id });
    }
  }

  async create(data) {
    try {
      return await this.Appointments.create(data);
    } catch (error) {
      throw new DbError("Failed to create appointment", { details: error.message, data });
    }
  }

  async update(data, id = data.id) {
    try {
      return await this.Appointments.update(data, { where: { id } });
    } catch (error) {
      throw new DbError("Failed to update appointment", { details: error.message, data });
    }
  }

  async delete(id) {
    try {
      return await this.Appointments.destroy({ where: { id } });
    } catch (error) {
      throw new DbError("Failed to delete appointment", { details: error.message, data: id });
    }
  }
}

module.exports = AppointmentRepository;
