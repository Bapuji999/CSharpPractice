using BasicandOOPsPart1Practice;

namespace BasicOops1
{
    class Practice //Reference type
    {
        public static void Main(string[] args)
        {
            //Value type
            int valueType1 = 0;
            bool valueType2 = false;
            double a = 3.14;

            //Reference type
            string str1 = "Hello";
            int[] array1 = { 1, 2, 3 };

            //Dynamic Example
            NullableTypeDynamicTypeVar exapleClass = new NullableTypeDynamicTypeVar();
            if (exapleClass.ExampleMethod(exapleClass.dynamicproperty) == null)
            {
                Console.WriteLine("Null returned");
            }

            DatatypesConversion datatypesConversion = new DatatypesConversion();
            datatypesConversion.Example();

            Loops loops = new Loops();
            loops.LoopsExample();
    }

    }
    enum Day { Monday = 0, Tuesday = 1, Wednesday = 2 } //Value type
    struct Point { public int X; public int Y; } //Value type
    interface IReferenceExample { int example1(); } //Reference type
}