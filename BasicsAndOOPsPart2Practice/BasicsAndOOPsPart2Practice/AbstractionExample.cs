namespace BasicsAndOOPsPart2Practice
{
    class AbstractionExample : Abstracted
    {
        public override int Add(int x, int y)
        {
            return x + y;
        }
    }
    abstract class Abstracted
    {
        public abstract int Add(int x, int y);
        public int Sub(int x, int y)
        {
            return x + y;
        }
    }

    interface IAbc
    {
        public int Add(int x, int y);
    }
    interface IAbc1
    {
        public int Sub(int x, int y);
    }

    class ExampleInterfaceA : IAbc, IAbc1
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Sub(int x, int y)
        {
            return x - y;
        }
    }
    class ExampleInterfaceB : IAbc
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
    class DimondExample
    {
        IAbc a = new ExampleInterfaceA();
        IAbc b = new ExampleInterfaceB();
    }
}
