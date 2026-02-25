const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) => {
  class Adoptions extends Model {}

  Adoptions.init(
    {
      id: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false,
      },
      animalID: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
      adopterID: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
      adoptionDate: {
        type: DataTypes.DATEONLY,
      },
    },
    {
      sequelize,
      modelName: "Adoptions",
      timestamps: false,
    }
  );

  return Adoptions;
};
