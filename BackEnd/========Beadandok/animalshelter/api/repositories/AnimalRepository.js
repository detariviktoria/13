// api/repositories/AnimalRepository.js
const { DbError } = require("../errors");
const { Op } = require("sequelize");

class AnimalRepository {
  constructor(db) 
  {
    this.Animals = db.Animals;
    this.sequelize = db.sequelize;
  }

  // Összes állat lekérése
  async getAnimals() {
    try 
    {
      return await this.Animals.findAll();
    } 
    catch (error) {
        throw new DbError("Failed to fetch animals", 
        {
            details: error.message,
        });
    }
  }

  // Egy állat lekérése ID alapján
  async getAnimal(animalID) {
    try {
      return await this.Animals.findOne({
        where: { id: animalID },
      });
    } catch (error) {
      throw new DbError("Failed to fetch animal", {
        details: error.message,
        data: animalID,
      });
    }
  }

  // Új állat létrehozása
  async createAnimal(animalData) {
    try {
      return await this.Animals.create(animalData);
    } catch (error) {
      throw new DbError("Failed to create animal", {
        details: error.message,
        data: animalData,
      });
    }
  }

  // Állat törlése
  async deleteAnimal(animalID) {
    try {
      return await this.Animals.destroy({
        where: { id: animalID },
      });
    } catch (error) {
      throw new DbError("Failed to delete animal", {
        details: error.message,
        data: { animalID },
      });
    }
  }

  // Állat frissítése
  async updateAnimal(animalData, animalID = animalData.id) {
    try {
      return await this.Animals.update(
        { ...animalData },
        {
          where: { id: animalID },
        }
      );
    } catch (error) {
      throw new DbError("Failed to update animal", {
        details: error.message,
        data: { animalData },
      });
    }
  }
}

module.exports = AnimalRepository;
