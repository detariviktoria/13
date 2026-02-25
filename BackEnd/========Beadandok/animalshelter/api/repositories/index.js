const AnimalRepository = require("./AnimalRepository");
const SpeciesRepository = require("./SpeciesRepository");
const LocationRepository = require("./LocationRepository");
const AdopterRepository = require("./AdopterRepository");
const AdoptionRepository = require("./AdoptionRepository");
const VetRepository = require("./VetRepository");
const AppointmentRepository = require("./AppointmentRepository");

module.exports = (db) => {
  const animalRepository = new AnimalRepository(db);
  const speciesRepository = new SpeciesRepository(db);
  const locationRepository = new LocationRepository(db);
  const adopterRepository = new AdopterRepository(db);
  const adoptionRepository = new AdoptionRepository(db);
  const vetRepository = new VetRepository(db);
  const appointmentRepository = new AppointmentRepository(db);

  return {
    animalRepository,
    speciesRepository,
    locationRepository,
    adopterRepository,
    adoptionRepository,
    vetRepository,
    appointmentRepository,
  };
};
