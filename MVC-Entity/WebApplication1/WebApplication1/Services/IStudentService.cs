using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        bool DeleteStudent(int id); 
    }
}
