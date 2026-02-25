const { Model } = require("sequelize");

module.exports = (sequelize, DataTypes) =>
{
    class Student extends Model {};

    Student.init
    (
        {
            ID:
            {
                type: DataTypes.INTEGER,
                primaryKey: true,
                autoIncrement: true,
            },

            name:
            {
                type: DataTypes.STRING(50),
                allowNull: false,
            }
        },

        {
            sequelize,
            modelName: "Student",
            freezeTableName: true,
            updatedAt: false,
            createdAt: "registerDate"
        }
    );

    return Student;
}