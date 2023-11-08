namespace DelegatesPractice
{
    class AnonymousMethodExample
    {
        public AnonymousMethodExample()
        {
            Console.WriteLine("Anonymous Method Example:");
        }
        delegate void Calculation(int x, int y);
        public void Calculate(int x, int y)
        {
            Calculation cal = static delegate (int x, int y) //Static Anonymous Function
            {
                Console.WriteLine($"Add function called addition result is {x + y}.");
            };

            cal += delegate (int x, int y)
            {
                Console.WriteLine($"Mul function called multiplication result is {x * y}.");
            };

            cal(x, y);
        }
    }
}
