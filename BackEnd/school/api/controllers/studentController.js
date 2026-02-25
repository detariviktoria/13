const db = require("../db");

const { studentService } = require("../services")(db);

exports.getStudents = async (req, res, next) =>
{   
    res.status(200).json(await studentService.getStudents());
}

exports.createStudent = async (req, res, next) =>
{
    const {name} = res.body;
    res.status(201)
}