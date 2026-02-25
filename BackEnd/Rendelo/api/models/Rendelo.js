const { DataTypes, Model } = require("sequelize");

module.exports = (sequelize) =>
{
    class Rendelo extends Model {};

    Rendelo.init
    (
        {
            ID:
            {
                type: DataTypes.UUID,
                primaryKey: true,
                allowNull: false,
                defaultValue: DataTypes.UUIDV4,
            },

            nev:
            {
                type: DataTypes.STRING,
                validate: 
                {
                    
                }
            },

            cim:
            {
                type: DataTypes.STRING,
                allowNull: false,
                unique: true,
            },
        },

        {
            sequelize,
            timestamps: false,
            freezeTablename: true,
            modelName: "rendelok"
        }
    );

    return Rendelo;
}