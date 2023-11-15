using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GenericCollections
{
    class ListPractice
    {
        public void Example()
        {
            //List Declarations 
            List<int> listInt = new List<int>(); //Initializes a new instance of the List<T> class that is empty and has the default initial capacity.
            listInt.Add(1);
            listInt.Add(2);
            listInt.Add(3);
            listInt.Add(4);
            listInt.Add(5); 
            listInt.Add(1);
            listInt.Add(2);
            listInt.Add(3);
            listInt.Add(4);
            listInt.Add(5);
            Console.WriteLine(listInt.Capacity);// Capacity is 0,4,8,16,.........

            List<String> listString = new List<String>();
            Console.WriteLine(listString.Capacity);
            listString.Add("a");
            listString.Add("ab");
            listString.Add("abc");
            listString.Add("abcd");
            listString.Add("abcde");
            Console.WriteLine(listString.Capacity);// Capacity is 0,4,8,16,.........

            List<int> listInt1 = new List<int>(10);
            listInt1.Add(1);
            listInt1.Add(2);
            listInt1.Add(3);
            listInt1.Add(1);
            listInt1.Add(2);
            listInt1.Add(3);
            listInt1.Add(1);
            listInt1.Add(2);
            listInt1.Add(3);
            listInt1.Add(1);
            listInt1.Add(2);
            listInt1.Add(3);
            Console.WriteLine(listInt1.Capacity);// Capacity is 10,20,40,80,.........

            List<int> listInt2 = new List<int>(listInt1);
            Console.WriteLine(string.Join(",", listInt2));
            Console.WriteLine(listInt1.Capacity);
            listInt2.Add(1);
            listInt2.Add(2);
            listInt2.Add(3);
            listInt2.Add(1);
            listInt2.Add(2);
            listInt2.Add(3);
            listInt2.Add(1);
            listInt2.Add(2);
            listInt2.Add(3);
            Console.WriteLine(listInt1.Capacity);

            int[] arr = new int[listInt1.Count];
            listInt1.CopyTo(arr, 0);

            //Nested List
            List<List<int>> lists = new List<List<int>>();
            lists.Add(new List<int>() { 1, 2, 3});
            lists.Add(new List<int>() { 3, 4, 5 });
            lists.Add(new List<int>() { 6, 7, 8 });

            foreach(var list in lists)
            {
                Console.WriteLine("--------------");
                foreach(var item in list) Console.WriteLine(item);
            }

            List<Dictionary<int,string>> listOfDict = new List<Dictionary<int,string>>();
            listOfDict.Add(new Dictionary<int, string>() { { 1, "ab" }, { 2, "ba" } });
            listOfDict.Add(new Dictionary<int, string>() { { 1, "cb" }, { 2, "da" } });
            foreach (var list in listOfDict)
            {
                Console.WriteLine("--------------");
                foreach (var item in list) Console.WriteLine(item);
            }

            ForEach(listInt2);

            listInt2.ForEach(display);
            listInt2.Remove(1);
            listInt2.Clear();

            //AsReadOonly 
            ReadOnlyCollection<List<int>> readOnlyList = lists.AsReadOnly();
        }
        static void display(int i)
        {
            Console.WriteLine(i);
        }
        //foreach Loop Without built-in Loop
        public void ForEach <T> (List<T> list, int index = 0)
        {
            if (index < list.Count)
            {
                Console.WriteLine(list[index]);
                ForEach(list, index+1);
            }
        }
    }
}
