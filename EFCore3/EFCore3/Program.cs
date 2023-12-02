using EFCore3.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EFCore3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContex dataContex = new DataContex();
            IQueryable<College> data1 = dataContex.college.Where(x => x.UniversityId > 2);

            //dataContex.college.Add(
            //    new College
            //    {
            //        CollegeId = 7,
            //        CollegeName = "Engineering College 7",
            //        CollegeType = "Technical",
            //        CollegeAddress = "123 College Street 7",
            //        UniversityId = 1
            //    }
            //);
            //dataContex.SaveChanges();

            var inMemoryData = data1.AsEnumerable();

            //dataContex.college.Add(
            //    new College
            //    {
            //        CollegeId = 8,
            //        CollegeName = "Engineering College 8",
            //        CollegeType = "Technical",
            //        CollegeAddress = "123 College Street 8",
            //        UniversityId = 2
            //    }
            //);
            //dataContex.SaveChanges();

            var filterData = inMemoryData.Where(x => x.CollegeId > 2).AsQueryable().AsNoTracking();

            var filterData1 = filterData.Where(x => x.CollegeId > 5).AsTracking();


            var entry = new College
            {
                CollegeId = 9,
                CollegeName = "Engineering College 9",
                CollegeType = "Technical",
                CollegeAddress = "123 College Street 9",
                UniversityId = 3
            };

            Console.WriteLine(dataContex.Entry(entry).State); //Detached

            dataContex.college.Add(
                entry
            );

            Console.WriteLine(dataContex.Entry(entry).State); //Adeded

            Console.WriteLine(dataContex.Entry(dataContex.college.First()).State); //Unchanged

            var sample = dataContex.college.First();
            sample.UniversityId = 15;
            Console.WriteLine(dataContex.Entry(sample).State); //Modified

            dataContex.Remove(sample);
            Console.WriteLine(dataContex.Entry(sample).State); //Deleted

            var result = inMemoryData.ToList();


            //1. Get the list of students who belong with a University Name is ‘AAAAAA’.
            var studentsWithUnivercity = dataContex.student.Join(dataContex.department, std => std.DepartmentId, d => d.DepartmentId, (std, d) => new { std, d.CollegeId })
                                                            .Join(dataContex.college, x => x.CollegeId, clg => clg.CollegeId, (x, c) => new { x, c.UniversityId })
                                                            .Join(dataContex.universitie, x => x.UniversityId, u => u.UniversityId, (x, u) => new { x, u })
                                                            .Where(all => all.u.UniversityName == "Harvard University")
                                                            .Select(all => new { all.x.x.std.StudentName, all.u.UniversityName }).ToList();
            var anotherway = dataContex.student
                                       .Include(std => std.Department.College.University)
                                       .Where(std => std.Department.College.University.UniversityName == "Harvard University")
                                       .Select(std => new { StudentName = std.StudentName, UniversityName = std.Department.College.University.UniversityName })
                                       .ToList();
        }
    }
}
