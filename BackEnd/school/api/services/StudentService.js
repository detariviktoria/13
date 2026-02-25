const StudentRepository = require("../repositories/StudentRepository");

class StudentService
{
    constructor(dbParam)
    {
        this.studentRepository = new StudentRepository(dbParam);
    }

    async getStudents()
    {
        return await this.studentRepository.getStudents();
    }

    async createStudent(studentData)
    {
        if(!studentData.name) throw new Error("Missing name!");

        return await this.studentRepository.createStudent(studentData);
    }

    async updateStudent(studentID, studentName)
    {
        if(!studentName) throw new Error("Missing name!");

        return await this.studentRepository.updateStudent(studentID, studentName);
    }
}

module.exports = StudentService;