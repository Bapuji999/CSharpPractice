using System.Security.Cryptography.X509Certificates;

namespace DelegatesPractice
{
    class LamdaExpressionExample
    {
        Func<int> add = () => 10; //Statement Lamdas

        Action action = () => Console.WriteLine("hi");

        public Func<int, int, int> sub = static (x, y) => x - y; //Static Anonymous Function

        Func<int, int, int> customFunction = (x, y) => { //Expression Lamdas
            int result = x * 2;
            result += 10;
            return result;
        };
        public void Example()
        {
            List<int> a = new List<int>();
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            Console.WriteLine(a.Capacity);
            action();
            customFunction(5, 6);
        }
    }
}
