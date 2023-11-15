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
        }
    }
    static class Namehelper
    {
        public static string GetUpperName(this ExtensionMethodsPractice name)   
        {
            return name.Name.ToUpper();
        }
    }
}
