using GakkoWebApp.Models;

namespace GakkoWebApp.Services
{
    public interface ISubjectService
    { 
        List<Subject> GetSubjects(string query);
        void InsertSubject(Subject subject);
        void DeleteSubject(Subject subject);
        List<Student> GetStudentsFromSubject(Subject subject);
        List<Grade> GetStudentProfile(Subject subject, Student student);
    }
}