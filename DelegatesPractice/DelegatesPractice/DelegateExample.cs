namespace DelegatesPractice
{
    class DelegateExample
    {
        delegate int Calculation(int x, int y);
        private int Add(int x, int y)
        {
            return x + y;
        }
        private int Mul(int x, int y)
        {
            return x * y;
        }
        public void Calculate(int x, int y, string calculationType)
        {
            if(calculationType == "Add")
            {
                Calculation add = new Calculation(Add);
                Console.WriteLine($"Addition of {x},{y} is {add(x, y)}");
            }
            if (calculationType == "Mul")
            {
                Calculation mul = new Calculation(Mul);
                Console.WriteLine($"Multipliction of {x},{y} is {mul(x, y)}");
            }
        }
    }

}
