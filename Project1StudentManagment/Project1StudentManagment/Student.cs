namespace Project1StudentManagment
{
    class Student
    {
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 30 || value < 5)
                {
                    throw new CustomeExeptionAge();
                }
                age = value;
            }
        }
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
    class StudentWithTotalMark
    {
        public int RollNo { get; set; }
        public int TotalMark { get; set; }
    }
}
