namespace GenericCollections
{
    class SortedListExample
    {
        public void Example()
        {
            SortedList<int, string> froot = new SortedList<int, string>();
            froot.Add(2, "Banana");
            froot.Add(1, "apple");

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
