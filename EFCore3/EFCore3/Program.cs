using EFCore3.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;

namespace EFCore3
{
    class A
    {
        public int AId { get; set; }
    }
    class B
    {
        public int BId { get; set; }
    }
    class C
    {
        public int CId { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContex dataContex = new DataContex();
            var data1 = dataContex.college.Where(x => x.UniversityId > 2).AsEnumerable();
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
            var inMemoryData = data1.AsQueryable();
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


            ////1. Get the list of students who belong with a University Name is ‘AAAAAA’.
            var studentsWithUnivercity = dataContex.student.Join(dataContex.department, std => std.DepartmentId, d => d.DepartmentId, (std, d) => new { std, d.CollegeId })
                                                            .Join(dataContex.college, x => x.CollegeId, clg => clg.CollegeId, (x, c) => new { x, c.UniversityId })
                                                            .Join(dataContex.universitie, x => x.UniversityId, u => u.UniversityId, (x, u) => new { x, u })
                                                            .Where(all => all.u.UniversityName == "Harvard University")
                                                            .Select(all => new { all.x.x.std.StudentName, all.u.UniversityName }).ToList();






            var asded = from std in dataContex.student
                        join dpt in dataContex.department on std.DepartmentId equals dpt.DepartmentId
                        join clg in dataContex.college on dpt.CollegeId equals clg.CollegeId
                        select new { std, dpt, clg };

            //var asded1 = from std in dataContex.student
            //            join dpt in dataContex.department on std.DepartmentId equals dpt.DepartmentId into deptGroup
            //             from dptGrouped in deptGroup
            //             join clg in dataContex.college on dptGrouped.CollegeId equals clg.CollegeId
            //             select new { dptGrouped, clg };



            //List<A> A = new List<A>()
            //{
            //    new A{AId = 1},
            //    new A{AId = 2},
            //};
            //List<B> B = new List<B>()
            //{
            //    new B{BId = 1},
            //    new B{BId = 2},
            //    new B{BId = 3},
            //    new B{BId = 4}
            //}; ;
            //List<C> C = new List<C>()
            //{
            //    new C{CId = 1},
            //    new C{CId = 3},
            //    new C{CId = 4}
            //};

            //var aswee = from a in A
            //            join b in B on a.AId equals b.BId
            //            join c in C on b.BId equals c.CId
            //            select new { a.AId, b.BId, c.CId };
            //var aswee1 = from a in A
            //            join b in B on a.AId equals b.BId into all
            //            from a1 in all
            //            join c in C on a1.BId equals c.CId
            //            select new { a.AId, a1.BId, c.CId };

            //var anotherway = dataContex.student
            //                           .Include(std => std.Department)
            //                           .ThenInclude(dpt => dpt.College)
            //                           .ThenInclude(c => c.University)
            //                           .Where(std => std.Department.College.University.UniversityName == "Harvard University")
            //                           .Select(std => new { StudentName = std.StudentName, UniversityName = std.Department.College.University.UniversityName })
            //                           .ToList();
            var another = dataContex.universitie.AsQueryable()
                                    .Include(u => u.Colleges)
                                    .ThenInclude(c => c.Departments)
                                    .ThenInclude(d => d.Students).GroupBy(x => x.Colleges.Select(x => x.Departments.Select(x => x.Students.Select(x => x.Age))));
            //var q1 = another.Select(x => x.Colleges);

            var kjk = dataContex.universitie.Include(u => u.Colleges).GroupBy(x => x.Colleges);

            var aaa = dataContex.universitie.GroupBy(x => x.UnvesrsityGrade);
        }
    }
}
