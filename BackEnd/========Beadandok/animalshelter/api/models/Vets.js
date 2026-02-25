// api/models/Vets.js
const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) => {
  class Vets extends Model {}

  Vets.init(
    {
      id: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false,
      },
      name: {
        type: DataTypes.STRING(100),
        allowNull: false,
      },
      specialty: {
        type: DataTypes.STRING(50),
      },
      phone: {
        type: DataTypes.STRING(20),
      },
      email: {
        type: DataTypes.STRING(100),
      },
    },
    {
      sequelize,
      modelName: "Vets",
      timestamps: false,
    }
  );

  return Vets;
};
