namespace Project6
{
    class Starting
    {
        public static void Start(List<City> cities)
        {
            try
            {
                Console.WriteLine("Please Enter the city for the weather related information.");
                string cityName = Console.ReadLine();
                if (cityName == null || cityName == "")
                {
                    Console.WriteLine("City cannot be Empty.");
                    return;
                }
                var city = cities.Find(x => x.city == cityName);
                if (city == null)
                {
                    Console.WriteLine("Weather related information is not available for the enterd city.");
                    return;
                }
                ApiCall.GetWetherData(city).Wait();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message, ex.InnerException?.Message);
            }
        }
    }
}
