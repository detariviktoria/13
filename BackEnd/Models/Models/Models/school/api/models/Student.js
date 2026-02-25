const { DataTypes, Model } = require("sequelize");
const { ValidationError } = require("../errors");

module.exports = (sequelize) =>
{
    class Student extends Model {};

    Student.init
    (
        {
            name:
            {
                type: DataTypes.STRING,

                unique: "student_name",
            },

            age:
            {
                type: DataTypes.INTEGER,

                allowNull: false,

                validate:
                {
                    isInt:
                    {
                        args: true,

                        msg: "A kor csak egész számot vehet fel!",
                    },

                    isPositive(age)
                    {
                        if(age <= 0) throw new ValidationError("Pozitív számot kell megadni", { data: age });
                    }
                }
            },

            gender:
            {
                type: DataTypes.ENUM("Fiú", "Lány"),

                validate:
                {
                    isIn: [ ["Fiú", "Lány"] ],
                }
            }
        },

        {
            sequelize,
            modelName: "Students",
            updatedAt: false,
        }
    );

    return Student;
}