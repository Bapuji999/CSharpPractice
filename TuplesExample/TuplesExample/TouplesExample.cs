using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace TuplesExample
{
    class TouplesExample
    {
        public static void Example()
        {
            Tuple<int, string, int, string> touple1 = new Tuple<int, string, int, string>(1,"hi", 2, "He");

            //Accessing Tuple Elements
            Console.WriteLine(touple1);
            Console.WriteLine(touple1.Item1);
            Console.WriteLine(touple1.Item2);
            Console.WriteLine(touple1.Item3);
            Console.WriteLine(touple1.Item4);

            var My_Tuple3 = Tuple.Create(13, "Geeks", 67,
                      89.90, 'g', 39939, "geek", 10);

            //Named Tuples
            var myNamedTuple = (Id: 1, Name: "Hello", IsValid: true);

            int id = myNamedTuple.Id;
            string name = myNamedTuple.Name;
            bool isValid = myNamedTuple.IsValid;

            //ValueTuple
            var t1 = (1, "hi", 2, "He");
            var t2 = (1, "hi");
            Console.WriteLine(TouplesExample.Ok(t2));

            //Deconstruction with Named Tuples
            var person = (Name: "John", Age: 30, IsStudent: false);
            var (Name, age, isStudent) = person;

            TouplesExample touplesExample = new TouplesExample();
            Console.WriteLine(touplesExample.DoubleThem((2, 3, 4)));
            Func<(int, int, int), int> total = ns => (ns.Item1 + ns.Item2 + ns.Item3);
            Console.WriteLine(total((1, 6, 13)));
        }
        //ToupleMethod
        public static (int, string) Ok((int, string) v) //Tuple as Method Parameters
        {
            return (v.Item1, v.Item2);
        }

        Func<(int, int, int), (int, int, int)> DoubleThem = ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3);
        Func<(int, int, int), int> total = ns => (ns.Item1+ns.Item2+ns.Item3);
    }
}
