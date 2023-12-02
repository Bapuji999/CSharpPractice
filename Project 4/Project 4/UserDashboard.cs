using Project_4.Models;
namespace Project_4
{
    class UserDashboard
    {
        public static void Home(User user)
        {
            Console.WriteLine($"Home Page,\n Hi, {user.UserName}");
        }
    }
}
