namespace GakkoWebApp.Models
{
    public class Grade
    {
        public int IdGrade { get; set; }
        public int StudentSubject_IdStudentSubject { get; set; }
        public int GradeValue { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}
