namespace DelegatesPractice
{
    class MultiCastDelegateExample
    {
        delegate void Calculation(int x, int y);
        private void Add(int x, int y)
        {
            Console.WriteLine($"Add function called addition result is {x+y}.");
        }
        private void Mul(int x, int y)
        {
            Console.WriteLine($"Mul function called multiplication result is {x * y}.");
        }
        public void Calculate(int x, int y)
        {
            Calculation cal = new Calculation(Add);
            cal += Mul;
            cal(x, y);
        }
    }
}
