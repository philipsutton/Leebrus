using GakkoWebApp.Models;
using System.Data.SqlClient;

namespace GakkoWebApp.Services
{
    public class SqlServerStudentService : IStudentService
    {
        public List<Student> GetStudents(string query)
        {
            SqlConnection con;
            //...
            //...
            return null;
        }

        public void InsertStudent(Student student)
        {
            //INSERT
            throw new NotImplementedException();
        }
    }
}
