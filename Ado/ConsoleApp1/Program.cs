//Program to demonstrate the usage of Ado.net
//connection string is hard-coded inside the program.cs filee

using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp1
{


    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }




    internal class  AdoDriver
    {
        static string connectionString = @"Data Source=LAPTOP-R4GATB80\MSSQLSERVER01; Initial Catalog=SchoolDb; Integrated Security=true";
        private SqlConnection connection = null;
        private List<Student> _students = null;


        public AdoDriver()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            _students = new List<Student> { new Student() };
        }

        ~AdoDriver()
        {
            connection.Close();
        }


        public List<Student> getStudents()
        {
            string sqlCommand = "select * from [dbo].[Student]";
            SqlCommand cmd = new SqlCommand(sqlCommand, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {
                _students.Add( new Student() { Id = reader.GetInt32(0), Name = reader.GetString(1), Age = reader.GetInt32(2) });
                //GetOrdinal("Column Name") 
            }

            return _students;

        }

        public void InsertStudent(Student student)
        {
            string sqlCommand = "insert into [dbo].[Student] (Name, Age) Values(@Name, @Age)";
            SqlCommand cmd = new SqlCommand(sqlCommand, connection);

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Age", student.Age);

            cmd.ExecuteNonQuery();

        }

        public void UpdateStudent(int studentId)
        {

            string sqlCommand = "select TOP 1 * from [dbo].[Student] where id = @id";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);

            adapter.SelectCommand.Parameters.AddWithValue("@id", studentId);

            DataTable dataTable= new DataTable();
            adapter.Fill(dataTable);

            DataRow studentRow = dataTable.Rows[0];

            studentRow["Age"] = 145;


            //automatically generate the update command based on the update done to the data table
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dataTable);

        }

        public void DeleteStudent(int studentId)
        {

            //no need to follow this approach directly delete sql query and ExecuteNonQuery
            string sqlCommand = "select TOP 1 * from [dbo].[Student] where id = @id";

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);

            adapter.SelectCommand.Parameters.AddWithValue("@id", studentId);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            DataRow studentRow = dataTable.Rows[0];

            studentRow.Delete();



            //automatically generate the update command based on the update done to the data table
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dataTable);

        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {


            AdoDriver driver = new AdoDriver();

            //Student newSudent = new Student() { Id = 1, Name = "Hari Bahadur", Age = 38 };

            //driver.InsertStudent(newSudent);

            driver.DeleteStudent(6);

            List<Student> student = driver.getStudents();
            foreach (var _student in student)
            {
                Console.WriteLine(_student.Name);
            }



        }
    }
}