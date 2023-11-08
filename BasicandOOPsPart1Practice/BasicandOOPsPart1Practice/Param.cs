namespace BasicandOOPsPart1Practice
{
    class Param
    {
        //param Example
        public int AddAll(int a, int b, params int[] c)
        {
            int result = a+b;
            foreach(int i in c)
            {
                result += i;    
            }
            return result;
        }
    }
}
