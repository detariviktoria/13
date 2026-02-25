const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) =>
{
    class User extends Model {};

    User.init
    (
        {
            ID:
            {
                type: DataTypes.UUID,
                primaryKey: true,
                allowNull: false,
                defaultValue: DataTypes.UUIDV4,
            },

            name:
            {
                type: DataTypes.STRING,
                unique: "username",
                allowNull: false,
            },

            password:
            {
                type: DataTypes.STRING,
                allowNull: false,
            },

            isAdmin:
            {
                type: DataTypes.BOOLEAN,
                defaultValue: false,
                allowNull: false,
            }
        },

        {
            sequelize,
            modelName: "User",
            createdAt: "registerDate",
            updatedAt: false,
        }
    );

    return User;
}