//Implicit Casting(automatically) -converting a smaller type to a larger type size
//char -> int -> long -> float -> double

//Explicit Casting (manually) -converting a larger type to a smaller size type
//double -> float -> long -> int -> char

//Type Conversion using Parse()

//Type Conversion using Convert Class


using System.Security.Claims;

namespace BasicandOOPsPart1Practice
{
    class DatatypesConversion
    {
        public void Example()
        {
            //Implicit Casting
            char ch = 'A';
            int num = ch;
            long l = num;
            float f = l;
            double d = f;

            //Explicit Casting
            f = (float)d;
            l = (long)f;
            num = (int)l;
            ch = (char)num;
            Console.WriteLine(ch);

            //Parse()
            string ParseExample1 = "29.89";
            double ParseExample2 = double.Parse(ParseExample1);
            Console.WriteLine(ParseExample2);

            //Type Convert Class
            string ConvertClassStrng = "99";
            int ConvertClassInt = Convert.ToInt32(ConvertClassStrng);
            Console.WriteLine(ConvertClassStrng);
        }
    }
}
