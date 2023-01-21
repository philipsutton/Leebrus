using GakkoWebApp.Models;
using System.Data.SqlClient;

namespace GakkoWebApp.Services
{
    public class SqlServerStudentService : IStudentService
    {
        public List<Student> GetStudents(string query)
        {
            SqlConnection con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "select * from student";
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            var students = new List<Student>();
            while (dr.Read())
            {
                Student student = new Student();
                student.FirstName = dr["FirstName"].ToString();
                student.LastName = dr["LastName"].ToString();
                student.Email = dr["Email"].ToString();
                student.Address = dr["Address"].ToString();
                student.IndexNumber = dr["IndexNumber"].ToString();
                students.Add(student);
            }

            return students;
        }

        public void InsertStudent(Student student)
        {
            SqlConnection con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "INSERT INTO Student(IdStudent, FirstName, LastName, Email, Address, IndexNumber) VALUES(DEFAULT, @FirstName, @LastName, @Email, @Address, @IndexNumber)";
            com.Parameters.AddWithValue("FirstName", student.FirstName);
            com.Parameters.AddWithValue("LastName", student.LastName);
            com.Parameters.AddWithValue("Email", student.Email);
            com.Parameters.AddWithValue("Address", student.Address);
            com.Parameters.AddWithValue("IndexNumber", student.IndexNumber);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
        }
        
        public void DeleteStudent(Student student)
        {
            SqlConnection con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "DELETE FROM STUDENT WHERE IndexNumber = 's20001'";
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
        }
    }
}
