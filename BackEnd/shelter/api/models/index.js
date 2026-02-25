module.exports = (sequelize) =>
{
    const Animals = require("./Animal")(sequelize);

    const Shelters = require("./Shelter")(sequelize);

    Shelters.hasMany(Animals, 
    {
        foreignKey: "shelter_name",

        as: "animals",

        onDelete: "CASCADE",

        constraints: false,
    });

    Animals.belongsTo(Shelters, 
    {
        foreignKey: "shelter_name",

        as: "shelter",

        constraints: false,
    });

    return { Animals, Shelters };
}