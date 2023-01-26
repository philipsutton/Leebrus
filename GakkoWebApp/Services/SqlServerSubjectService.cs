using System.Data.SqlClient;
using GakkoWebApp.Models;

namespace GakkoWebApp.Services;

public class SqlServerSubjectService : ISubjectService
{
    public List<Subject> GetSubjects(string query)
    {
        SqlConnection con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "select * from subject";
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        var subjects = new List<Subject>();
        while (dr.Read())
        {
            Subject subject = new Subject();
            subject.IdSubject = int.Parse(dr["IdSubject"].ToString());
            subject.Name = dr["Name"].ToString();
            subjects.Add(subject);
        }

        return subjects;
    }
    
    public void InsertSubject(Subject subject)
    {
        SqlConnection con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "INSERT INTO Subject(Name) VALUES(@Name)";
        com.Parameters.AddWithValue("Name", (subject.Name==null ?1:subject.Name));  
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
    }
    
    public void DeleteSubject(Subject subject)
    {
        SqlConnection con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "DELETE FROM SUBJECT WHERE Name = @Name";
        com.Parameters.AddWithValue("Name", subject.Name);
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
    }
    public List<Student> GetStudentsFromSubject(Subject subject)
    {
        SqlConnection con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "SELECT FirstName, LastName, IndexNumber from studentsubject inner join student on studentsubject.student_idstudent = student.idstudent WHERE StudentSubject.Subject_IdSubject = @IdStudentSubject";
        com.Parameters.AddWithValue("IdStudentSubject", subject.IdSubject);
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        var students = new List<Student>();
        while (dr.Read())
        {
            Student student = new Student();
            student.FirstName = dr["FirstName"].ToString();
            student.LastName = dr["LastName"].ToString();
            student.IndexNumber = dr["IndexNumber"].ToString();
            students.Add(student);
        }

        return students;

            


            
    }
}