namespace NonGenericCollections
{
    class ReflectionExample
    {
        public void Example()
        {
            Type type = typeof(int);
            Console.WriteLine(type.Name);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.BaseType);

            Type type1 = typeof(Array);
            Console.WriteLine(type1.Name);
            Console.WriteLine(type1.FullName);
            Console.WriteLine(type1.BaseType);
        }
    }
}
