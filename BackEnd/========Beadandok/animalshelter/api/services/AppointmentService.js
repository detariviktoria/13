// api/services/AppointmentsService.js
const { BadRequestError, NotFoundError } = require("../errors");

class AppointmentService {
  constructor(db) {
    this.appointmentRepository = require("../repositories")(db).appointmentRepository;
  }

  async getAll() {
    return await this.appointmentRepository.getAll();
  }

  async getById(id) {
    if (!id) throw new BadRequestError("Missing appointment ID");
    const appointment = await this.appointmentRepository.getById(id);
    if (!appointment) throw new NotFoundError("Appointment not found", { data: id });
    return appointment;
  }

  async create(data) {
    if (!data || !data.animalID || !data.vetID || !data.appointmentDate)
      throw new BadRequestError("Missing appointment data");
    return await this.appointmentRepository.create(data);
  }

  async update(data, id) {
    if (!data || !id) throw new BadRequestError("Missing data or appointment ID");
    return await this.appointmentRepository.update(data, id);
  }

  async delete(id) {
    if (!id) throw new BadRequestError("Missing appointment ID for deletion");
    return await this.appointmentRepository.delete(id);
  }
}

module.exports = AppointmentService;
