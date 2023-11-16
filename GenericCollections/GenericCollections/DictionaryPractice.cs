using System.Collections;
using System.Collections.ObjectModel;

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

            //ReadOnlyDictionary
            ReadOnlyDictionary<int, string> abc = froot.AsReadOnly();

            Dictionary<int, List<int>> asd = new Dictionary<int, List<int>>();
            asd.Add(1, new List<int>() { 1,23,4 });
            asd.Add(2, new List<int>() { 2, 23, 4 });
            foreach (int key in asd.Keys)
            {
                foreach(int value in asd[key])
                {
                    Console.WriteLine($"[{key}, {value}]");
                }
            }

            //foreach( entry in abc)
            //{
            //    Console.WriteLine(entry);
            //}
        }
    }
}
