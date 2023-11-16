namespace GenericCollections
{
    class SortedListExample
    {
        public void Example()
        {
            SortedList<int, string> froot = new SortedList<int, string>();
            froot.Add(2, "Banana");
            froot.Add(1, "apple");

            SortedList<string, string> froot1 = new SortedList<string, string>();
            froot1.Add("bapuji", "6");
            froot1.Add("gangathr", "12");
            froot1.Add("gangathr", "12");
            froot1.Add("akash", "7");
            froot1.Add("prakash", "76");
            froot1.Add("Mukesh", "99");
            Console.WriteLine(string.Join(",", froot1));
            Console.WriteLine(string.Join(",", froot));//Always Shorted
            Console.WriteLine(froot.Count);//Count
            Console.WriteLine(froot.Capacity);//Capacity
            Console.WriteLine(string.Join(",", froot.Keys));//Keys
            Console.WriteLine(string.Join(",", froot.Values));//Values

            froot.Add(3, "coconut");//Add()
            froot.ContainsKey(2);//ContainsKey
            froot.ContainsValue("coconut");//ContainsValue
            string x;
            froot.TryGetValue(2,out x);
            Console.WriteLine(x);
        }
    }
}
