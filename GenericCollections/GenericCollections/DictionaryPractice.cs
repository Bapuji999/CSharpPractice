namespace GenericCollections
{
    class DictionaryPractice
    {
        public void example()
        {
            Dictionary<int, String> froot = new Dictionary<int, String>();
            froot.Add(1, "Apple");
            froot.Add(2, "Banana");
            froot.Add(3, "coconut");

            //Count
            Console.WriteLine(froot.Count);

            //Keys
            ICollection<int> keys = froot.Keys;
            Console.WriteLine(string.Join(",", keys));

            //Values
            ICollection<string> values = froot.Values;
            Console.WriteLine(string.Join(",", values));

            //Remove
            froot.Remove(1);
            Console.WriteLine(string.Join(",", froot));
        }
    }
}
