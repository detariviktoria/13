const { Model } = require("sequelize");

module.exports = (sequelize, DataTypes) =>
{
    class Classroom extends Model {};

    Classroom.init
    (
        {
            ID:
            {
                type: DataTypes.INTEGER,
                allowNull: false,
                primaryKey: true,
                autoIncrement: true,
            },

            hasAC:
            {
                type: DataTypes.BOOLEAN,
                allowNull: false,
                defaultValue: false,
            },
        },

        {
            sequelize,
            modelName: "Classroom",
            freezeTableName: true,
            timestamps: false,
        }
    );

    return Classroom;
}