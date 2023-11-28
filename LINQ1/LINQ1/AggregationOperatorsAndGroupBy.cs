using System.Runtime.CompilerServices;

namespace LINQ1
{
    class AggregationOperatorsAndGroupBy
    {
        public static void Example()
        {
            IEnumerable<Student> students = DataBase.GetAllStudent();
            var ssst = (from student in students
                        group student by student.Age into std
                        where std.Key == 5
                        select std).ToList().AsEnumerable().ToLookup(x => x.Key);
            int ageSum = students.Sum(x => x.Age);
            double ageAvrage = students.Average(x => x.Age);
            int ageMax = students.Max(x => x.Age);
            int ageMin = students.Min(x => x.Age);
            int ageCount = students.Count();
            int ageCount1 = students.Count(x => x.Age >8);

            IEnumerable<IGrouping<int, Student>> data = from student in students
                                                        group student by student.Age into std
                                                        where std.Key == 5
                                                        select std;
            IEnumerable<IGrouping<int, Student>> data1 = students.GroupBy(x => x.Age);
            var result = data1.Select(group => new
            {
                Age = group.Key,
                Students = group.Select(student => student)
            });
            var comparor = new CheckName();
            var data2 = students.GroupBy(x => x.Age, 
                                         x => new { x.Name, x.Age },
                                         (key, data) => new {key, data}
                                         );
            var data3 = students.GroupBy(x => x,
                                         comparor
                                         );
            var data4 = students.GroupBy(x => new { x.Age, x.Class },
                                         (key, x) => key).OrderBy(x=>x.Class);
        }
    }
}
