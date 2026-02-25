// api/services/AnimalService.js
const { BadRequestError, NotFoundError } = require("../errors");

class AnimalService {
  constructor(db) {
    this.animalRepository = require("../repositories")(db).animalRepository;
  }

  // Összes állat lekérése
  async getAnimals() {
    return await this.animalRepository.getAnimals();
  }

  // Egy állat lekérése ID alapján
  async getAnimal(animalID) {
    if (!animalID)
      throw new BadRequestError("Missing animal ID from payload");

    const animal = await this.animalRepository.getAnimal(animalID);

    if (!animal)
      throw new NotFoundError("Animal not found", { data: animalID });

    return animal;
  }

  // Új állat létrehozása
  async createAnimal(animalData) {
    if (!animalData)
      throw new BadRequestError("Missing animal data from payload", 
        {
            data:animalData,
        }
    );

    if (!animalData.name)
      throw new BadRequestError("Missing animal name", 
    { data: animalData });

    if (!animalData.speciesID)
      throw new BadRequestError("Missing speciesID",
     { data: animalData });

    if (!animalData.locationID)
      throw new BadRequestError("Missing locationID", 
    { data: animalData });

    return await this.animalRepository.createAnimal(animalData);
  }

  // Állat frissítése
  async updateAnimal(animalData, animalID) {
    if (!animalData || !animalID)
      throw new BadRequestError("Missing data or animalID");

    return await this.animalRepository.updateAnimal(animalData, animalID);
  }

  // Állat törlése
  async deleteAnimal(animalID) {
    if (!animalID)
      throw new BadRequestError("Missing animalID for deletion");

    return await this.animalRepository.deleteAnimal(animalID);
  }
}

module.exports = AnimalService;
