using GakkoWebApp.Models;

namespace GakkoWebApp.Services
{
    public class StudentsService : IStudentService
    {
        private static List<Student> _students = new List<Student>();

        public List<Student> GetStudents(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return _students;
            }

            return _students.Where(e => e.LastName == query).ToList();
        }

        public void InsertStudent(Student student)
        {
            _students.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            _students.Remove(student);
        }
    }
}
