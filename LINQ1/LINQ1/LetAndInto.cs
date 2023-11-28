namespace LINQ1
{
    class LetAndInto
    {
        public static void Example()
        {
            IEnumerable<Subject> subjects = DataBase.GetAllSubjects();
            IEnumerable<Class> classes = DataBase.GetAllClass();
            IEnumerable<College> colleges = DataBase.GetAllCollege();
            IEnumerable<Student> students = DataBase.GetAllStudent();

            var data = from subject in subjects
                       let isEvenId = (subject.Id % 2 == 0)
                       select new { subject, isEvenId }
                       into SubjectIsEven
                       join c in classes on 1 equals 1
                       let isEvenClassId = (c.Id % 2 == 0)
                       select new { SubjectIsEven, c, isEvenClassId };
            var data1 = from student in students
                        let totalStudent = students.Count()
                        select new { student, totalStudent };
        }
    }
}