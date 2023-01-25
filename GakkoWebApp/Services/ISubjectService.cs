using GakkoWebApp.Models;

namespace GakkoWebApp.Services
{
    public interface ISubjectService
    { 
        List<Subject> GetSubjects(string query);
        void InsertSubject(Subject subject);
    }
}