namespace LINQ1
{
    class Joins
    {
        public static void Example()
        {
            IEnumerable<Subject> subjects = DataBase.GetAllSubjects();
            IEnumerable<Class> classes = DataBase.GetAllClass();
            var data1 = from subject in subjects
                        join clas in classes on subject.ClassId equals clas.Id
                        select new {subject.Name, ClassName = clas.Name };

            var data2 = subjects.Join(classes,
                                        subject => subject.ClassId,
                                        clas => clas.Id,
                                        (subject, clas) => new { subject = subject.Name, ClassName = clas.Name }
                                        );
        }
    }
}
