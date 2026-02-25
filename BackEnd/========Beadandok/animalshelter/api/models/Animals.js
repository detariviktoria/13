// api/models/Animals.js
const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) => {
  class Animals extends Model {}

  Animals.init(
    {
      id: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false,
      },
      name: {
        type: DataTypes.STRING(50),
        allowNull: false,
      },
      speciesID: {
        type: DataTypes.INTEGER,
      },
      age: {
        type: DataTypes.INTEGER,
      },
      adopted: {
        type: DataTypes.BOOLEAN,
        defaultValue: false,
      },
      registeredAt: {
        type: DataTypes.DATE,
      },
      locationID: {
        type: DataTypes.INTEGER,
      },
    },
    {
      sequelize,
      modelName: "Animals",
      timestamps: false,
    }
  );

  return Animals;
};
