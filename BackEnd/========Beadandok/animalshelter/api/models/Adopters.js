const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) => {
  class Adopters extends Model {}

  Adopters.init(
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
      email: {
        type: DataTypes.STRING(100),
        allowNull: false,
        unique: true,
        validate: {
          isEmail: true,
        },
      },
      phone: {
        type: DataTypes.STRING(20),
      },
      registeredAt: {
        type: DataTypes.DATE,
      },
    },
    {
      sequelize,
      modelName: "Adopters",
      timestamps: false,
    }
  );

  return Adopters;
};
