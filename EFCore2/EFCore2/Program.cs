using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EFCore2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContex dataContex = new DataContex();
            Console.WriteLine("Press 1 for Add and 2 for View.");
            int i;
            int.TryParse(Console.ReadLine(), out i);
            switch (i)
            {
                case 1:
                    AddRow(dataContex);
                    break;
                case 2:
                    ViewUsers(dataContex);
                    break;

            }
            var track = dataContex.ChangeTracker;
            foreach(var item in track.Entries())
            {
                if(item.State == EntityState.Unchanged)
                {
                    Console.WriteLine(item.Entity);
                }
            }
        }
        public static void AddRow(DataContex dataContex)
        {
            User user = new User();
            Console.WriteLine("Enter user details.");
            Console.WriteLine("Enter Id:");
            int Id;
            int.TryParse(Console.ReadLine(), out Id);
            user.UserId = Id;
            Console.WriteLine("Enter Name:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            user.Password = Console.ReadLine();
            dataContex.Add(user);
            dataContex.SaveChanges();
        }
        public static void ViewUsers(DataContex dataContex)
        {
            var users = dataContex.users;
            if (!users.Any())
            {
                Console.WriteLine("No user found");
                return;
            }
            foreach (User user in users)
            {
                var print = new StringBuilder();
                print.Append($"Id: {user.UserId}\n");
                print.Append($"Name: {user.Name}\n");
                print.Append($"Email: {user.Email} \n");
                Console.WriteLine(print.ToString());
            }
        }
    }
}
