const { Model, DataTypes } = require("sequelize");

module.exports = (sequelize) =>
{
    class Food extends Model {};

    Food.init
    (
        {
            name:
            {
                type: DataTypes.STRING(40),
                primaryKey: true,
                allowNull: false,
            },

            price:
            {
                type: DataTypes.FLOAT,
                allowNull: false,

                validate:
                {
                    isFloat: true,
                },
            }
        },

        {
            sequelize,
            modelName: "Food",
            timestamps: false,
        }
    );

    return Food;
}