using System.Text.Json;

namespace Project6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome To Custom Weather Client Tool");
                string filePath = @"C:\Users\bapuj\OneDrive\Desktop\BapujiPrac\Project6\Project6\CityConstants.json";
                string jsonString = System.IO.File.ReadAllText(filePath);
                if (jsonString != null)
                {
                    List<City> cities = JsonSerializer.Deserialize<List<City>>(jsonString);
                    Starting.Start(cities);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
