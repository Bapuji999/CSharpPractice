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
        }
    }
}
