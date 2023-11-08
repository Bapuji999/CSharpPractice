namespace BasicandOOPsPart1Practice
{
    class StaticAndInstance
    {
        public int InstanceProperty;
        public static int StaticProperty;

        public int InstanceMethod(int a)
        {
            return a + 10;
        }
        public static int StaticMethod(int a)
        {
            return a + 10;
        }
    }

    class Apply
    {
        public void Example()
        {
            //For Instance property and methods 
            StaticAndInstance staticAndInstance = new StaticAndInstance();
            staticAndInstance.InstanceProperty = 10;
            Console.WriteLine(staticAndInstance.InstanceMethod(20));

            //For Static Property and Methods
            StaticAndInstance.StaticProperty = 10;
            StaticAndInstance.StaticMethod(20);
        }
    }
}
