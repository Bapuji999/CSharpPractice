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

            //Remove()
            colours.Remove("Red");

            //Clear
            colours.Clear();
        }
    }
}
