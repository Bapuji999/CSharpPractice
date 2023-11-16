using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1StudentManagment
{
    static class ExtensionForLast
    {
        public static void DisplayClass(this List<Student> StudentList)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var student in StudentList)
                {
                    if (StudentList.IndexOf(student) < StudentList.Count - 1)
                    {
                        Console.WriteLine($"RollNo:{student.RollNo} belongs to class {student.ClassName}");
                        Thread.Sleep(10000);
                    }
                    else
                    {
                        Console.WriteLine($"RollNo:{student.RollNo} belongs to class {student.ClassName}");
                    }
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
