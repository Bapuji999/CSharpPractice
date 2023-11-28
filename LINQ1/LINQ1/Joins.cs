namespace LINQ1
{
    class Joins
    {
        public static void Example()
        {
            IEnumerable<Subject> subjects = DataBase.GetAllSubjects();
            IEnumerable<Class> classes = DataBase.GetAllClass();
            IEnumerable<College> colleges = DataBase.GetAllCollege();

            var data1 = from subject in subjects
                        join clas in classes on subject.ClassId equals clas.Id
                        select new {subject.Name, ClassName = clas.Name };

            var data2 = subjects.Join(classes,
                                        subject => subject.ClassId,
                                        clas => clas.Id,
                                        (subject, clas) => new { subject = subject.Name, ClassName = clas.Name }
                                        );

            var data3 = from subject in subjects
                        join clas in classes on subject.ClassId equals clas.Id
                        join college in colleges on clas.CollegeId equals college.Id
                        select new { subject.Name, ClassName = clas.Name, CollegeName = college.Name };

            var data4 = subjects.Join(classes,
                                        subject => subject.ClassId,
                                        clas => clas.Id,
                                        (subject, clas) => new { subject,clas }
                                        ).Join(colleges,
                                                clas => clas.clas.CollegeId,
                                                col => col.Id,
                                                (clas, col)=> new { 
                                                                    subject = clas.subject.Name, 
                                                                    className = clas.clas.Name, 
                                                                    college = col.Name 
                                                                   }
                                               ).ToList();

            var data5 = classes.GroupJoin(subjects, cla => cla.Id, sub => sub.ClassId, (cla, sub) => new { cla.Name, sub });
            foreach (var data in data5)
            {
                Console.WriteLine(data.Name);
                foreach (var c in data.sub)
                {
                    Console.WriteLine(c.Name);
                }
            }
            var data6 = from c in classes
                        join s in subjects on c.Id equals s.ClassId into ClassSubjects
                        select new { c.Name, ClassSubjects };

            foreach (var data in data6)
            {
                Console.WriteLine(data.Name);
                foreach (var c in data.ClassSubjects)
                {
                    Console.WriteLine(c.Name);
                }
            }

            var data7 = subjects.Join(classes,
                                        subject => new { subject.ClassId, subject.Name },
                                        clas => new { ClassId = clas.Id, clas.Name },
                                        (subject, clas) => new { subject = subject.Name, ClassName = clas.Name }
                                        );

            var data8 = from c in classes
                        join s in subjects on c.Id equals s.ClassId into ClassSubjects
                        from cs in ClassSubjects.DefaultIfEmpty()
                        select new { className = c.Name,
                            Subject = (cs == null) ? "No Subject" : cs.Name
                        };

            var data9 = classes.GroupJoin(subjects, 
                                          cla => cla.Id, 
                                          sub => sub.ClassId, 
                                          (cla, sub) => new { 
                                              Classname = cla.Name,
                                              subject = sub.DefaultIfEmpty()
                                          });

            foreach (var data in data9)
            {
                Console.WriteLine(data.Classname);
                foreach (var c in data.subject)
                {
                    if (c == null)
                    {
                        Console.WriteLine("No Subject");
                    }
                    else
                    {
                        Console.WriteLine($"{c.Name}");
                    }
                }
            }
        }
    }
}
