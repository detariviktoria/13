const { Students } = require("../db");

exports.getStudents = async (req, res, next) =>
{
    try
    {
        const student = await Students.create(
        {
            name: "Kássa Gergő",
            age: 23,
            gender: "Fiú",
        });

        res.status(200).json(student);
    }
    catch(error)
    {
        next(error);
    }
}