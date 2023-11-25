namespace LINQ1
{
    class Paging
    {
        public static void Example()
        {
            int a = 5;
            int page;
            do
            {
                Console.WriteLine("Enter Page no:\n");
                int itemPerPage = 5;
                int.TryParse(Console.ReadLine(), out page);
                IEnumerable<Student> items = DataBase.GetAllStudent().Skip((page - 1) * itemPerPage).Take(itemPerPage);

                foreach (Student item in items)
                {
                    Console.WriteLine($"Name : {item.Name}");
                }
                a++;
            }
            while (a< page);

        }
    }
}
