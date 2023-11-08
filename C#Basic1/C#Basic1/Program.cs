using System;

namespace Conversion
{
    class Program
    {
        static void Main(string[] args)
        {

            //Implicit conversion
            int num1 = 10;
            double num2 = num1;
            Console.WriteLine("Implicit conversion " + num2);

            //Explicit conversion
            double num3 = 55.55;
            int num4 = (int)num3;
            Console.WriteLine("Explicit conversion " + num4);

            //Parse
            string n = "100";
            int num5 = int.Parse(n);
            Console.WriteLine("Parse() " + num5);

            //Convert Class
            int num6 = 100;
            string n1 = Convert.ToString(num6);
            Console.WriteLine("Convert Class " + n1.GetType());

            //Switch
            int num7 = 2;

            switch (num7)
            {
                case 0:
                    Console.WriteLine("ok");
                    break;
                case 1:
                    Console.WriteLine("ok1");
                    break;
                case 2:
                    Console.WriteLine("Match");
                    break;
                default:
                    Console.WriteLine("NO");
                    break;
            }

            //ForEach
            int[] arr = {1, 2, 3};
            foreach(int i in arr)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(Add(1, 2, 3, 4, 56));
            var ab = Add(1, 2, 3, 4, 56);
        }
        // function containing params parameters 
        public static int Add(params int[] ListNumbers)
        {
            int total = 0;

            // foreach loop 
            foreach (int i in ListNumbers)
            {
                total += i;
            }
            return total;
        }
       
    }
}