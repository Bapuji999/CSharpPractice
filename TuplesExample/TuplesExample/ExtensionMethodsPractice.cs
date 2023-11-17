namespace TuplesExample
{
    sealed class ExtensionMethodsPractice
    {
        public string Name = "bapuji";
        public string GetName()
        {
            return this.Name;
        }
    }

    class ExtensionMethodsExample
    {
        public static void Example()
        {
            ExtensionMethodsPractice extensionMethodsPractice = new ExtensionMethodsPractice();
            Console.WriteLine(extensionMethodsPractice.GetUpperName());
            Console.WriteLine("akbiswa".updateString());
            Console.WriteLine(65.add25());
        }
    }
    static class Namehelper
    {
        public static string GetUpperName(this ExtensionMethodsPractice name)   
        {
            return name.Name.ToUpper();
        }
        public static string updateString(this String name)
        {
            return name.ToUpper() + " Updated " + DateTime.Now ;
        }
        public static int add25(this int i)
        {
            return i + 25;
        }
    }
}
