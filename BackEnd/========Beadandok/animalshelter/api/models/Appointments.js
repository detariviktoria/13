// api/models/Appointments.js
const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) => {
  class Appointments extends Model {}

  Appointments.init(
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
      vetID: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
      appointmentDate: {
        type: DataTypes.DATE,
      },
      reason: {
        type: DataTypes.STRING(255),
      },
      notes: {
        type: DataTypes.TEXT,
      },
    },
    {
      sequelize,
      modelName: "Appointments",
      timestamps: false,
    }
  );

  return Appointments;
};
