const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) =>
{
    class User extends Model {};

    User.init(
    {
        id:
        {
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true,
        },

        név:
        {
            type: DataTypes.STRING(200),
        },

        jelszó_hash:
        {
            type: DataTypes.STRING,
        },

        email:
        {
            type: DataTypes.STRING(255),
        }
    },
    {
        sequelize,
        modelName: "Felhasználó",
        freezeTableName: true,
        timestamps: true,
        updatedAt: false,
        createdAt: "regisztráció_dátuma",
    });

    return User;
}