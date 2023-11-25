namespace LINQ1
{
    class DifferedExicution
    {
        public static void Example()
        {
            List<Student> students = DataBase.GetAllStudent().ToList();
            IEnumerable<Student> Students = students.Where(s => s.Class == "5th");
            students.Add(new Student() { Id = 17, Name = "Rajan", Age = 10, Class = "5th" });
            foreach (Student student in Students)
            {
                Console.WriteLine(student.Name);
            }
            students.Add(new Student() { Id = 18, Name = "Ramana", Age = 10, Class = "5th" });
            foreach (Student student in Students)
            {
                Console.WriteLine(student.Name);
            }
        }
    }
}
