using System.ComponentModel.DataAnnotations;

namespace Project1StudentManagment
{
    class Student
    {
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public int RollNo { get; set; }
        public ClassList ClassName { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public string Address { get; set; }
        public List<string> Hobbies { get; set; } = new List<string>();
        public DateTime AddedDate { get; set; }
    }
    class Subject
    {
        public string SubjectName { get; set; }
        public int MarkObtained { get; set; }
    }
}
