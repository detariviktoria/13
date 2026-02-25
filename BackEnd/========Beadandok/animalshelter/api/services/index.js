const AnimalService = require("./AnimalService");
const SpeciesService = require("./SpeciesService");
const LocationService = require("./LocationService");
const AdopterService = require("./AdopterService");
const AdoptionService = require("./AdoptionService");
const VetService = require("./VetService");
const AppointmentService = require("./AppointmentService");

module.exports = (db) => {
  return {
    animalService: new AnimalService(db),
    speciesService: new SpeciesService(db),
    locationService: new LocationService(db),
    adopterService: new AdopterService(db),
    adoptionService: new AdoptionService(db),
    vetService: new VetService(db),
    appointmentService: new AppointmentService(db),
  };
};
