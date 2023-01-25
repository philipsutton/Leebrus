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
}