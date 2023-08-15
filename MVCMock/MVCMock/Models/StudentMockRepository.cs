namespace MVCMock.Models
{
    public class StudentMockRepository: IStudentRepository
    {
        public List<Student> GetAll()
        {
            List<Student> _students = new List<Student>
            {
                new Student() { Id = 1, Name = "Genuine", Age = 22 },
                new Student() { Id = 2, Name = "John", Age = 33},
                new Student() { Id = 3, Name = "Wilson", Age = 25 },
                new Student() { Id = 4, Name = "Mark", Age = 21 }
            };

            return _students;          
        }
    }
}
