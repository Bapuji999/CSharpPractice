using System.Text;

namespace EFCore1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UserAppDbContex())
            {
                var users = context.fatherandson;
                foreach (var user in users)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Id: {user.Id}");
                    data.AppendLine($"Name: {user.PersonName}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
    }
}
