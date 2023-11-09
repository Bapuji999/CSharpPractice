using System.Collections;

namespace NonGenericCollections
{
    class HashtableExample
    {
        public void Example()
        {
            Hashtable colours = new Hashtable();
            colours.Add("Red", "#FF0000");
            colours.Add("Black", "#0000");
            foreach(DictionaryEntry colour in colours)
            {
                Console.WriteLine($"Colour Name is {colour.Key} and colour hashcode is {colour.Value}");
            }

            //Propertys

            //Count
            int count = colours.Count;

            //Item Property
            object value = colours["Red"];

            //Keys Property
            ICollection keys = colours.Keys;

            //Values Property
            ICollection values = colours.Values;

            //Methods

            //Clone()
            Hashtable copy = (Hashtable)colours.Clone();

            //ContainsKey(key)
            bool containsKey = colours.ContainsKey("Red");

            //ContainsValue(value)
            bool containsValue = colours.ContainsValue("#FF0000");

            //Remove()
            colours.Remove("Red");

            //Clear
            colours.Clear();

        }
    }
}
