using System.Security.Cryptography.X509Certificates;

namespace DelegatesPractice
{
    class LamdaExpressionExample
    {
        Func<int, int, int> add = (x, y) => x + y; //Statement Lamdas

        public Func<int, int, int> sub = static (x, y) => x - y; //Static Anonymous Function

        Func<int, int, int> customFunction = (x, y) => { //Expression Lamdas
            int result = x * 2;
            result += 10;
            return result;
        };
        public void Example()
        {
            add(5, 6);
            customFunction(5, 6);
        }
    }
}
