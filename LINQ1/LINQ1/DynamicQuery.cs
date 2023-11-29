using LinqKit;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace LINQ1
{
    class DynamicQuery
    {
        public static void Example()
        {
            IEnumerable<Student> students = DataBase.GetAllStudent();
            int Age;
            int Id;
            string Name;
            string Class;

            Console.WriteLine("Select Option:");
            Console.WriteLine("1. Age\n2. Id\n3. Name\n4.Class");

            int option;

            int.TryParse(Console.ReadLine(), out option);
            string Filter = string.Empty;
            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter Age:");
                    int.TryParse(Console.ReadLine(), out Age);
                    Filter = $"age == {Age}";
                    break;
                case 2:
                    Console.WriteLine("Enter Id:");
                    int.TryParse(Console.ReadLine(), out Id);
                    Filter = $"Id == {Id}";
                    break;
                case 3:
                    Console.WriteLine("Enter Name:");
                    Name = Console.ReadLine();
                    Filter = $"Name == \"{Name}\"";
                    break;
                case 4:
                    Console.WriteLine("Enter Class:");
                    Class = Console.ReadLine();
                    Filter = $"Class ==\"{Class}\"";
                    break;
                default: Console.WriteLine("Choose from given option."); break;
            }
            var results = students.AsQueryable().Where(Filter);
            foreach (Student student in results)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Class: {student.Class}, " +
                                     $"Age: {student.Age}");
            }

            ExpressionStarter<Student> predicate = PredicateBuilder.New<Student>();
            predicate = predicate.And(s => s.Age >= 5);
            predicate = predicate.And(s => s.Age <= 7);

            var dataEvaluation = predicate.Compile();
            var data1 = dataEvaluation(new Student() { Id = 1, Name = "Aham", Age = 5, Class = "1st" });

            var data = students.Where(predicate).OrderBy(s=>s.Age).ToList();

            // Simple lambda expression: x => x + 1
            Expression<Func<int, int>> addOne = x => x + 1;

            // Compile and execute the expression
            Func<int, int> addOneFunc = addOne.Compile();
            int result = addOneFunc(5);


            Expression<Func<Student, bool>> condition = x => x.Age > 5;

            var filteredNumbers = students.Where(condition.Compile());
            var result1 = students?.Where(condition.Compile()).ToList();

            string a = null;
            var x1 = a?.Concat("abc") ?? "a";

            ParameterExpression parameter = Expression.Parameter(typeof(Student));
            BinaryExpression condition1 = Expression.AndAlso(
                Expression.Equal(Expression.Property(parameter, "Name"), Expression.Constant("Prakash")),
                Expression.GreaterThan(Expression.Property(parameter, "Age"), Expression.Constant(5))
            );
            Expression<Func<Student, bool>> lambdaExpression = Expression.Lambda<Func<Student, bool>>(condition1, parameter);

            // Apply the dynamic expression to filter the list
            var filteredStudents = students.Where(lambdaExpression.Compile()).ToList();
        }
    }
}
