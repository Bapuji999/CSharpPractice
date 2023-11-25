using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LINQ1
{
    class SetOperations
    {
        public static void Example()
        {
            IEnumerable<Student> data = DataBase.GetAllStudent();
            IEnumerable<Student> distinct = data.Distinct();
            IEnumerable<object> distinct1 = (from student in data
                                             select new { student.Name, student.Id }).Distinct();
            var comparor = new CheckAll();
            List<Student> distinct2 = data.Distinct(comparor).ToList();
            var comparor1 = new CheckName();
            List<Student> distinct3 = data.Distinct(comparor1).ToList();
            var comparor2 = new CheckAge();
            List<Student> distinct4 = data.Distinct(comparor2).ToList();
            var comparor3 = new CheckClass();
            List<Student> distinct5 = data.Distinct(comparor3).ToList();



            List<string> data1 = new List<string>() { "A", "B", "C", "D" };
            List<string> data2 = new List<string>() { "C", "D", "E", "F" };

            List<string> data3 = data1.Except(data2).ToList();

            List<int> data4 = distinct4.Select(d => d.Id).Except(distinct5.Select(d => d.Id)).ToList();
            List<Student> data5 = distinct4.Except(distinct5, comparor).ToList();



            List<Student> data6 = distinct4.Intersect(distinct5, comparor).ToList();
            List<Student> data7 = distinct4.Intersect(distinct5).ToList();


            List<string> data8 = data.Select(x => x.Class).Union(data.Select(x => x.Class)).ToList();


            IEnumerable<Student> data9 = data.Take(5);
            Range range = new Range(1,6);
            IEnumerable<Student> data10 = data.Take(range);

            IEnumerable<Student> data11 = data.TakeWhile(x => x.Age < 8);
            IEnumerable<Student> data12 = data.TakeWhile((x, index) => x.Age > index);

            IEnumerable<Student> data13 = data.Skip(6);
            IEnumerable<Student> data14 = data.SkipWhile((x, index) => x.Age > index);
            

        }
    }
    class CheckAll : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if(x.Id == y.Id && x.Class == y.Class && x.Name == y.Name && x.Age == y.Age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode( Student obj)
        {
            if(obj == null)
            {
                return 0;
            }
            return 1;
        }
    }

    class CheckName : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if (x.Name == y.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Student obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return 1;
        }
    }

    class CheckAge : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if (x.Age == y.Age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Student obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return 1;
        }
    }
    class CheckClass : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if (x.Class == y.Class)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Student obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return 1;
        }
    }
}
