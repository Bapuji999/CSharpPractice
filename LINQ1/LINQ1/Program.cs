using System.Net.Cache;

namespace LINQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = { 10, 12, 30, 24, 15, 16, 97, 28, 39 };
            // from <alias> in <coll | arr> [<clauses>] select alias;
            var list = from score in scores
                                    where score > 20
                                    select score;
            Console.WriteLine(string.Join(",", list));
            var OrderdList = from score in scores
                                    where score > 20
                                    orderby score descending
                                    select score;
            Console.WriteLine(string.Join(",", OrderdList));
            var OrderdMax = (from score in scores
                             where score > 20
                             orderby score descending
                             select score).Max();
            Console.WriteLine(string.Join(",", OrderdMax));
            var listM = scores.Where(score => score > 20).OrderBy(score => score);
            Console.WriteLine(string.Join(",", listM));
            var students = DataBase.GetAllStudent();
            foreach ( var student in students )
            {
                Console.WriteLine($"Student: {student.Name}");
            }
            var claaWiseStudent = from student in students orderby student.Class select student;
            foreach (var student in claaWiseStudent)
            {
                Console.WriteLine($"{student.Name} {student.Class} class");
            }
            var data = students.Select(student => new
            {
                student.Name,
                student.Age
            });
            var data1 = students.Select(student => (Name: student.Name, Age: student.Age));
            DifferedExicution.Example();
            Projection.Example();
            SetOperations.Example();
            Joins.Example();
            LetAndInto.Example();
            AggregationOperatorsAndGroupBy.Example();
            DynamicQuery.Example();
            Paging.Example();
        }
    }
}