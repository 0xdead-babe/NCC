using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudentService: IStudentService
    {
        private readonly ApplicationContext _applicationContext;
        public StudentService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public  List<Student> GetAllStudents()
        {
            return  _applicationContext.Student.ToList();
        }
        public Student GetStudentById(int id)
        {
            return _applicationContext.Student.SingleOrDefault(stu => stu.Id == id);
        }
        public void CreateStudent(Student student)
        {
            _applicationContext.Add(student);
            _applicationContext.SaveChanges();
        }
        public void UpdateStudent(Student student) {
            _applicationContext.Student.Update(student);
            _applicationContext.SaveChanges();
        }
        public bool DeleteStudent(int id)
        {
            var student = _applicationContext.Student.Find(id);

            if(student != null)
            {
                _applicationContext.Student.Remove(student);
                _applicationContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
