const { DataTypes } = require("sequelize");

module.exports = (sequelize) =>
{
    const Student = require("./Student")(sequelize, DataTypes);

    const Classroom = require("./Classroom")(sequelize, DataTypes);

    Student.belongsToMany(Classroom, 
    {
        through: "Studies",
        
        foreignKey:
        {
            name: "studentID",
            allowNull: false,
        },

        timestamps: false,
    });

    Classroom.belongsToMany(Student, 
    {
        through: "Studies",
        foreignKey:
        {
            name: "classroomID",
            allowNull: false,
        },

        timestamps: false,
    })

    return { Student, Classroom };
}