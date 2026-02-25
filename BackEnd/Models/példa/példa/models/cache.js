const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) =>
{
    class Cache extends Model {};

    Cache.init(
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
            allowNull: false,
        },

        szélesség:
        {
            type: DataTypes.FLOAT,

            allowNull: false,

            validate:
            {
                isFloat:
                {
                    args: true,
                    msg: "A szélesség csak lebegőpontos szám lehet!"
                }
            }
        },


        magasság:
        {
            type: DataTypes.FLOAT,

            validate:
            {
                isFloat:
                {
                    args: true,
                    msg: "A magasság csak lebegőpontos szám lehet!"
                }
            }
        }
    },
    {
        sequelize,
        modelName: "Geoláda",
        freezeTableName: true,
        timestamps: false,
    });

    return Cache;
}