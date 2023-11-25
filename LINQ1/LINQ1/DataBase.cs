namespace LINQ1
{
    class DataBase
    {
        public static IEnumerable<Student> GetAllStudent()
        {
            return new[] 
            { 
                new Student() { Id = 1, Name = "Aham", Age = 5, Class = "1st" },
                new Student() { Id = 2, Name = "Akash", Age = 6, Class = "2nd" },
                new Student() { Id = 3, Name = "Priti", Age = 9, Class = "4th" },
                new Student() { Id = 4, Name = "Surya", Age = 8, Class = "3rd" },
                new Student() { Id = 5, Name = "Vikram", Age = 7, Class = "3rd" },
                new Student() { Id = 6, Name = "Naidu", Age = 5, Class = "1st" },
                new Student() { Id = 7, Name = "Pratik", Age = 10, Class = "5th" },
                new Student() { Id = 8, Name = "Suman", Age = 7, Class = "2nd" },
                new Student() { Id = 9, Name = "Laxmi", Age = 9, Class = "4th" },
                new Student() { Id = 10, Name = "Prakash", Age = 10, Class = "5th" },
                new Student() { Id = 11, Name = "Vikash", Age = 6, Class = "2nd" },
                new Student() { Id = 12, Name = "Harish", Age = 5, Class = "1st" },
                new Student() { Id = 13, Name = "Raju", Age = 8, Class = "4th" },
                new Student() { Id = 14, Name = "Nilam", Age = 5, Class = "1st" },
                new Student() { Id = 15, Name = "Arpana", Age = 7, Class = "2nd" },
                new Student() { Id = 16, Name = "Rachana", Age = 6, Class = "3rd" },
                new Student() { Id = 17, Name = "Vikash", Age = 8, Class = "2nd" },
            };
        }
        public static IEnumerable<Subject> GetAllSubjects()
        {
            return new[]
            {
                new Subject() { Id=1, Name="Math", ClassId=1},
                new Subject() { Id=2, Name="Chem", ClassId=1},
                new Subject() { Id=3, Name="Physics", ClassId=2},
                new Subject() { Id=4, Name="Englisg", ClassId=2},
                new Subject() { Id=5, Name="Hindi", ClassId=3},
                new Subject() { Id=6, Name="It", ClassId=3}
            };
        }
        public static IEnumerable<Class> GetAllClass()
        {
            return new[]
            {
                new Class() { Id=1, Name="A"},
                new Class() { Id=2, Name="B"},
                new Class() { Id=3, Name="C"}
            };
        }
    }
}
