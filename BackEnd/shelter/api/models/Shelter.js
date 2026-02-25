/*
TODO:
    Models:
    A Shelternek legyenek a következő attr.:
    - name
    - capacity

    Repository:
    - findAll, de legyen Eager Loading az Animals-re 
    (include: "animals")

    Service:
    - findAll metódusra

    SSR (Server-Side Rendering):
    - views/shelter mappában az index.ejs file-t,
    amiben **shelterenként** táblázatba 
    kiírjuk az állatok adatait
*/

const { Model, DataTypes } = require("sequelize");
const { ValidationError } = require("../errors");

module.exports = (sequelize) =>
{
    class Shelter extends Model {};

    Shelter.init
    (
        {
            name:
            {
                type: DataTypes.STRING,

                primaryKey: true,

                allowNull: false,
            },

            capacity:
            {
                type: DataTypes.FLOAT,

                validate:
                {
                    isFloat: true,

                    greaterThanZero(capacity)
                    {
                        if(capacity <= 0) throw new ValidationError("Capacity must be greater than 0", { data: capacity });
                    }
                },
            }
        },

        {
            hooks:
            {
                afterDestroy: (shelter, options) => 
                {
                    console.error(`Törlődött a ${shelter.name} nevű menhely`);
                }
            },

            sequelize,
            modelName: "Shelter",
            timestamps: false,
        }
    );

    return Shelter;
}