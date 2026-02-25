// api/models/Species.js
const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) => {
  class Species extends Model {}

  Species.init(
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
      averageLifespan: {
        type: DataTypes.INTEGER,
      },
    },
    {
      sequelize,
      modelName: "Species",
      timestamps: false,
    }
  );

  return Species;
};
