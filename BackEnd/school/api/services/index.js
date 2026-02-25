const StudentService = require("./StudentService")

module.exports = (dbParam) =>
{
    const studentService = new StudentService(dbParam);

    return { studentService };
}