using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LINQ1
{
    class Projection
    {
        public static void Example()
        {
            IEnumerable<Student> students = DataBase.GetAllStudent();

            List<Student> stds = (from student in students select student).ToList();

            foreach (Student student in stds)
            {
                Console.WriteLine(student.Name);
            }

            IEnumerable<int> ssdts = students.Select(stud => stud.Id).ToList();
            foreach (var student in ssdts)
            {
                Console.WriteLine(student);
            }

            var stdts = students.Select(s => new { Id = s.Id, Age = s.Age }).ToList();

            var stdts1 = from s in stdts select new { Id = s.Id, Age = s.Age };

            List<string> str = new List<string>() { "asp", "core" };

            List<char> stdts2 = (from s in str
                                 from d in s
                                 select d).ToList();

            List<char> stdt2 = str.SelectMany(c => c).ToList();

            List<Employe> newDataSource = new List<Employe>() {
                new Employe{ Id = 1, Name = "Akbar", Skills = new List<string>(){ "C", "C++", "C#" } },
                new Employe{ Id = 2, Name = "Virat", Skills = new List<string>(){ "Python", "Statistic" } },
                new Employe{ Id = 3, Name = "Linku", Skills = new List<string>(){ "Java", "JavaScript", "Springboot" } }
            };



            List<string> empSkills = (from emp in newDataSource
                                      from skill in emp.Skills
                                      select skill).ToList();

            List<string> empSkills1 = newDataSource.SelectMany(emp => emp.Skills).ToList();
            IEnumerable<Employe> newDataSource1 = newDataSource.Where(emp => emp.Id < 3 && emp.Skills.Count < 3);
            IEnumerable<Employe> newDataSource2 = from emp in newDataSource
                                                  where emp.Id < 3
                                                  select emp;

            List<object> list = new List<object>() { "A", 1, "B", 2, 3 };
            List<int> list2 = list.OfType<int>().ToList();
            var list3 = (from l in list
                         where l is int
                         select l).ToList();

            IOrderedEnumerable<Student> sst = students.OrderBy(std => std.Name);
            IEnumerable<string> sst1 = students.OrderBy(std => std.Name)
                                               .Select(std => std.Name)
                                               .Where(std => std.Contains('A'));
            IOrderedEnumerable<Student> sst2 = students.OrderBy(std => std.Class)
                                                       .ThenBy(std => std.Name).ThenBy(std => std.Age);

            IOrderedEnumerable<Student> sst3 = from std in students
                                               orderby std.Class descending, std.Name, std.Age
                                               select std;
            bool isMiner = students.All(std =>
            {
                bool a;
                a = std.Age < 18 ? true : false;
                return a;
            });

            bool any = students.Any();
            any = students.Any(std => std.Age < 6);
            any = students.Where(std => std.Age < 6).Select(std => std.Age).Contains(5);
            var comparer = new Equal();
            any = students.Contains(new Student() { Id = 1, Name = "Aham", Age = 5, Class = "1st" }, comparer);

            Student a = students.ElementAt(0);
            Student? a1 = students.ElementAtOrDefault(60);
            Student b = students.First(std => std.Name == "Vikash");
            Student ? c = students.FirstOrDefault(std => std.Name == "qqq");
            Student e = students.Last(std => std.Name == "Vikash");
            Student? f = students.LastOrDefault(std => std.Name == "qqq");
            Student l1 = students.Single(std => std.Name == "Prakash");
            Student? l2 = students.SingleOrDefault(std => std.Name == "qqq");
        }
    }
    class Employe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Skills = new List<string>();
    }
    class Equal : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }
            if (object.ReferenceEquals(x, null))
            {
                return false;
            }
            return x.Id == y.Id && x.Class == y.Class && x.Age == y.Age && x.Name == y.Name;
        }

        public int GetHashCode(Student obj)
        {
            if(obj == null)
            {
                return 0;
            }
            return 1;
        }
    }
}