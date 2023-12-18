using Models;
using Newtonsoft.Json;
using System.Text;
namespace WebApiWithConsoleApplication.Events
{
    class GetStudents
    {
        public static async Task GetAllStudents(string baseUrl)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var apiUrl = baseUrl + "GetAllStudents";
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            var students = JsonConvert.DeserializeObject<List<Student>>(content);
                            if (students != null && students.Any())
                            {
                                foreach (var student in students)
                                {
                                    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Class: {student.Class}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No students found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Empty response content.");
                        }
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
        public static async Task GetStudent(string baseUrl)
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
                    var apiUrl = baseUrl + $"GetStudent?Id={id}";
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            var student = JsonConvert.DeserializeObject<Student>(content);
                            if (student != null)
                            {
                                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Class: {student.Class}");
                            }
                            else
                            {
                                Console.WriteLine("No students found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Empty response content.");
                        }
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