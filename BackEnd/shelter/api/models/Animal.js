const { DataTypes, Model } = require("sequelize");

const { ValidationError } = require("../errors");

module.exports = (sequelize) =>
{
    class Animal extends Model {};

    Animal.init
    (
        {
            name:
            {
                type: DataTypes.STRING,

                unique: "animal_name",
            },

            age:
            {
                type: DataTypes.VIRTUAL,

                get()
                {
                    return new Date(Date.now()).getFullYear() - new Date(this.birthday).getFullYear();
                },

                set(age)
                {
                    return this.age;
                },

                validate:
                {
                    isInt:
                    {
                        args: true,

                        msg: "Nem egész értékű számot adtál meg!",
                    },

                    len:
                    {
                        args: [ 1, 20 ],

                        msg: "Csak az 1 és 20 közötti értékeket fogadjuk el",
                    },

                    check67(age)
                    {
                        if(age == 6 || age == 7) throw new ValidationError("Nem fogadjuk el a 6 vagy 7-es számot!!!!!!!!!!!!!!", { data: age });
                    }
                }
            },

            birthday:
            {
                type: DataTypes.DATEONLY,

                validate:
                {
                    isDate:
                    {
                        args: true,

                        msg: "Dátumot fogadunk csak el a szülinaphoz",
                    },
                },

                allowNull: false,
            }
        },

        {
            sequelize,
            modelName: "animals",
            updatedAt: false,
        }
    );

    return Animal;
}