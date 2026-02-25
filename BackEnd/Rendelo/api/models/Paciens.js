const { DataTypes, Model } = require("sequelize");

module.exports = (sequelize) =>
{
    class Paciens extends Model {};

    Paciens.init (
        {
            ID: {
                type: DataTypes.UUID,
                primaryKey : true,
                allowNull: false,
                defaultValue: DataTypes.UUIDV4,
            },

            nev: 
            {
                type: DataTypes.STRING,

                allowNull: false,

                validate: {
                    isAlpha: {
                        args: true,

                        msg: "A páciens neve csak betűket tartalmazhat"
                    }
                }
            },

            bejelentkezesi_kod:
            {
                type: DataTypes.UUID,
                allowNull: false,
                defaultValue: DataTypes,
                UUIDV1,
            },

            betegseg: {
                type: DataTypes.ENUM("Bárányhimlő", "AIDS", "HIV", "Covid", "Ebola", "Szalmonella", "Cancer"),
                validate:
                {
                    isIn:
                    {
                        args: [ [ "Bárányhimlő", "AIDS", "HIV", "Covid", "Ebola", "Szalmonella", "Cancer"] ],

                        msg: "Nem vehető fel ilyen betegség",
                    }
                }
            },

            erkezesi_ido : {
                type: DataTypes.DATE,
            }
        },

        {
            sequelize,
            modelName: "paciensek",
            freezeTableName: true,
            timestamps: false,
        },
    );

    return Paciens;
}