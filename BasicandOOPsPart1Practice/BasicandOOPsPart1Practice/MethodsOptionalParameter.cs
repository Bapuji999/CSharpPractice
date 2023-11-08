namespace BasicandOOPsPart1Practice
{
    class MethodsOptionalParameter
    {
        //Method Declaration
        public int IntegerMethod(int a)
        {
            int b = a + 10;
            return b; 
        }
        dynamic dynamicTypeMethod(dynamic a)
        {
            return null; // we can also write "return a";
        }

        //Method Call
        public void example()
        {
            IntegerMethod(10);
            dynamic a = null;
            dynamicTypeMethod(a);
        }

        //Optional Parameter
        public int intMethod(int a, int oParameter = 1)
        {
            a += oParameter;
            return a;
        }
    }
}
