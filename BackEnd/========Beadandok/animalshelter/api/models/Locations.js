const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) => {
  class Locations extends Model {}

  Locations.init(
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
      address: {
        type: DataTypes.STRING(255),
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
      modelName: "Locations",
      timestamps: false,
    }
  );

  return Locations;
};
