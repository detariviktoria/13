module.exports = (sequelize) => {
  const Species = require("./Species")(sequelize);
  const Locations = require("./Locations")(sequelize);
  const Animals = require("./Animals")(sequelize);
  const Adopters = require("./Adopters")(sequelize);
  const Adoptions = require("./Adoptions")(sequelize);
  const Vets = require("./Vets")(sequelize);
  const Appointments = require("./Appointments")(sequelize);


  // Species <-> Animals
  Species.hasMany(Animals, 
    { foreignKey: "speciesID", 
        as: "animals" 
    });

  Animals.belongsTo(Species, 
    { foreignKey: "speciesID",
         as: "species" 
    });

  // Locations <-> Animals
  Locations.hasMany(Animals, 
    { foreignKey: "locationID",
        as: "animals" 
    });

  Animals.belongsTo(Locations, 
    { foreignKey: "locationID",
        as: "location" 
    });

  // Animals <-> Adoptions
  Animals.hasMany(Adoptions,
     { foreignKey: "animalID", 
        as: "adoptions" 
    });

  Adoptions.belongsTo(Animals, 
    { foreignKey: "animalID", 
        as: "animal" 
    });

  // Adopters <-> Adoptions
  Adopters.hasMany(Adoptions,
    { foreignKey: "adopterID", 
        as: "adoptions" 
    });

  Adoptions.belongsTo(Adopters, 
    { foreignKey: "adopterID", 
        as: "adopter" 
    });

  // Animals <-> Appointments
  Animals.hasMany(Appointments, 
    { foreignKey: "animalID", 
        as: "appointments" 
    });

  Appointments.belongsTo(Animals, 
    { foreignKey: "animalID", 
        as: "animal" 
    });

  // Vets <-> Appointments
  Vets.hasMany(Appointments, 
    { foreignKey: "vetID", 
        as: "appointments" 
    });

  Appointments.belongsTo(Vets, 
    { foreignKey: "vetID", 
        as: "vet" 
    });


  return {
    Species,
    Locations,
    Animals,
    Adopters,
    Adoptions,
    Vets,
    Appointments,
  };
};
