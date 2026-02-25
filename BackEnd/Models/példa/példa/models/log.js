const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) =>
{
    //#region 4. FELADAT

    class Log extends Model {};

    Log.init(
    {
        id:
        {
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true,
        },
    },
    {
        sequelize,
        modelName: "Naplóbejegyzés",
        freezeTableName: true,
        timestamps: true,
        updatedAt: false,
        createdAt: "dátum"
    });

    return Log;

    //#endregion
}