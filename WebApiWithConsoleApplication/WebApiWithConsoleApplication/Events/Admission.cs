using Models;
using Newtonsoft.Json;
using System.Text;
namespace WebApiWithConsoleApplication.Events
{
    class Admission
    {
        public static async Task AddStudent(string baseUrl)
        {
            try
            {
                Student student = new Student();
                if (!TryReadIntFromConsole("Please Enter Student Id", out int id))
                {
                    Console.WriteLine("Invalid input for Student Id");
                    return;
                }
                student.Id = id;
                Console.WriteLine("Please Enter Student Name");
                student.Name = Console.ReadLine();
                if (!TryReadIntFromConsole("Please Enter Class", out int studentClass))
                {
                    Console.WriteLine("Invalid input for Class");
                    return;
                }
                student.Class = studentClass;
                using (HttpClient httpClient = new HttpClient())
                {
                    var apiUrl = baseUrl + "AddStudent";
                    string jsonContent = JsonConvert.SerializeObject(student);
                    HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Student added successfully in the API");
                    }
                    else
                    {
                        Console.WriteLine(response.ReasonPhrase);
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        public static bool TryReadIntFromConsole(string prompt, out int result)
        {
            Console.WriteLine(prompt);
            return int.TryParse(Console.ReadLine(), out result);
        }
    }
}
