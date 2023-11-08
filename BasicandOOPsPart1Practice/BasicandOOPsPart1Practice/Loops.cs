namespace BasicandOOPsPart1Practice
{
    class Loops
    {
        public void LoopsExample()
        {
            //for loop
            for(int i = 0; i > -1; i++)
            {
                //It will itterate 10 times
            }

            //forEach
            int[] arr = new int[10];
            foreach(int i in arr)
            {
                arr[i] = i;
            }

            //while
            int count = 10;
            while(count-- > 0) 
            {
                //It will itterate 10 times
            }

            //Do while
            string stringExample = "123abc";
            string OnlyString = string.Empty;
            string OnlyNumber = string.Empty;
            int coverdLength = 0;
            int length = stringExample.Length - 1;
            do 
            {
                if (char.IsDigit(stringExample[coverdLength]))
                {
                    OnlyNumber += stringExample[coverdLength];
                }
                else
                {
                    OnlyString += stringExample[coverdLength];
                }
            } while (coverdLength++ < length);
            Console.WriteLine(OnlyNumber + ":::" + OnlyString);
        }
    }
}
