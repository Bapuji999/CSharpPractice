using System.Text;
namespace WebApiWithConsoleApplication.Events
{
    class Starting
    {
        public static readonly string baseUrl = "https://localhost:44359/api/TestAll/";
        public static void start()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Please choose from given options.");
                stringBuilder.AppendLine("1. Add Student");
                stringBuilder.AppendLine("2. GetAll Students");
                stringBuilder.AppendLine("3. Get Student by Id");
                stringBuilder.AppendLine("4. Change student");
                stringBuilder.AppendLine("5. Change student Name");
                stringBuilder.AppendLine("6. Delete student");
                stringBuilder.AppendLine("7. Stop application");
                Console.WriteLine(stringBuilder);
                int option;
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        Admission.AddStudent(baseUrl).Wait();
                        break;
                    case 2:
                        GetStudents.GetAllStudents(baseUrl).Wait();
                        break;
                    case 3:
                        GetStudents.GetStudent(baseUrl).Wait();
                        break;
                    case 4:
                        ChangeStudents.ChangeStudent(baseUrl).Wait();
                        break;
                    case 5:
                        ChangeStudents.RenameStudent(baseUrl).Wait();
                        break;
                    case 6:
                        ChangeStudents.DeleteStudent(baseUrl).Wait();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("You have selected invalid option.");
                        break;
                }
                start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
