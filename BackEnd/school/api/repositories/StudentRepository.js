class StudentRepository
{
    // DI = Dependency Injection

    constructor(dbParam)
    {
        this.Student = dbParam.Student;
    }
    
    async getStudents()
    {
        return await this.Student.findAll();
    }
}

module.exports = StudentRepository;