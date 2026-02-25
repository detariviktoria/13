const { Model , DataTypes} = require ("sequelize");

module.exports = (sequelize) => {
    class Orvos extends Model {};

    Orvos.init (
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

                        msg: "Az orvos neve csak betűket tartalmazhat"
                    }
                }
            },

            telefonszam: {
                type: DataTypes.STRING,

                validate: {
                    isMatch: {
                        args: /^\+36[0-9]{9}$/gmi,
                        msg: "Nem létezik ilyen formátumú telefonszám"
                    }
                }
            }
        },

        {
            sequelize,
            modelName: "orvosok",
            freezeTableName: true,
            timestamps: false,
        },

    );
    return Orvos;
}