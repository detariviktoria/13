const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) =>
{
    class Weapon extends Model {};

    Weapon.init
    (
        {
            name:
            {
                type: DataTypes.STRING,

                primaryKey: true,

                allowNull: false,
            },

            type:
            {
                type: DataTypes.ENUM("Pistol", "SMG", "Rifle", "Sniper", "Heavy"),

                allowNull: false,
            },

            rarity:
            {
                type: DataTypes.ENUM("Common", "Uncommon", "Rare", "Epic", "Legendary"),

                allowNull: false,
            }
        },

        {
            sequelize,
            modelName: "Weapon",
        }
    );

    return Weapon;
}