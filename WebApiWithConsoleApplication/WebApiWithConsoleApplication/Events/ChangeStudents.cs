using Models;
using Newtonsoft.Json;
using System.Text;

namespace WebApiWithConsoleApplication.Events
{
    class ChangeStudents
    {
        public static async Task ChangeStudent(string baseUrl)
        {
            try
            {
                Student student = new Student();
                if (!Admission.TryReadIntFromConsole("Please Enter Student Id", out int id))
                {
                    Console.WriteLine("Invalid input for Student Id");
                    return;
                }
                student.Id = id;
                Console.WriteLine("Please Enter Student Name");
                student.Name = Console.ReadLine();
                if (!Admission.TryReadIntFromConsole("Please Enter Class", out int studentClass))
                {
                    Console.WriteLine("Invalid input for Class");
                    return;
                }
                student.Class = studentClass;
                using (HttpClient httpClient = new HttpClient())
                {
                    var apiUrl = baseUrl + $"ChangeStudent?Id={id}";
                    string jsonContent = JsonConvert.SerializeObject(student);
                    HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PutAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Student changed successfully in the API");
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
        public static async Task RenameStudent(string baseUrl)
        {
            try
            {
                if (!Admission.TryReadIntFromConsole("Please Enter Student Id", out int id))
                {
                    Console.WriteLine("Invalid input for Student Id");
                    return;
                }
                Console.WriteLine("Please Enter Student Name");
                var Name = Console.ReadLine();
                using (HttpClient httpClient = new HttpClient())
                {
                    var apiUrl = baseUrl + $"RenameStudent?Id={id}&Name={Name}";
                    HttpResponseMessage response = await httpClient.PatchAsync(apiUrl, null);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Student Renamed successfully");
                    }
                    else
                    {
                        Console.WriteLine(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
        public static async Task DeleteStudent(string baseUrl)
        {
            try
            {
                if (!Admission.TryReadIntFromConsole("Please Enter Student Id", out int id))
                {
                    Console.WriteLine("Invalid input for Student Id");
                    return;
                }
                using (HttpClient httpClient = new HttpClient())
                {
                    var apiUrl = baseUrl + $"DeleteStudent?Id={id}";
                    HttpResponseMessage response = await httpClient.DeleteAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Student Deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
