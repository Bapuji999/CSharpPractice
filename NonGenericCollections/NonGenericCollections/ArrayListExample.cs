using System.Collections;

namespace NonGenericCollections
{
    class ArrayListExample
    {
       public void Example()
       {
            //ArrayList Initialization

            //Using ArrayList()
            ArrayList arrayList = new ArrayList(); //Capacity will be 0 initialy then 4 then 8 and so on....
            Console.WriteLine("Current capacity of arrayList2: " + arrayList.Capacity);

            //Using ArrayList(Int32)
            ArrayList arrayList2 = new ArrayList(10); //initial capacity specified as 10. Then it will increase capacity multiple of 2 like 10, 20, 40 and so on...
            
            // Displaying count of elements of ArrayList 
            Console.WriteLine("Number of elements in arrayList2: " + arrayList2.Count);
             
            // Displaying Current capacity of ArrayList 
            Console.WriteLine("Current capacity of arrayList2: " + arrayList2.Capacity);

            //Using ArrayList(ICollection)
            List<int> list = new List<int>();
            list.Add(1);
            ArrayList arrayList3 = new ArrayList(list);
            arrayList3.Add(1); //Add(Object) Method
            Console.WriteLine("arrayList3: ");
            Console.WriteLine("Current capacity of arrayList3: " + arrayList3.Capacity);
            foreach (object obj in arrayList3)
            {
                Console.WriteLine(obj);
            }

            //IsFixedSize Property
            ArrayList myListfixed = ArrayList.FixedSize(arrayList2);
            Console.WriteLine("This Array is Fixed Size: " + myListfixed.IsFixedSize);

            //IsReadOnly Property
            ArrayList readOnly = ArrayList.ReadOnly(arrayList2);
            Console.WriteLine("This Array is Read Only: "+readOnly.IsReadOnly);

            //Item[Int32] Property
            for(int i = 0; i< arrayList3.Count; i++)
            {
                Console.WriteLine(arrayList3[i]);
            }

            //AddRange(ICollection) Method
            ArrayList arrList1 = new ArrayList() {1, 2, 3};
            ArrayList arrList2 = new ArrayList();
            arrayList2.Add(10);
            arrList2.AddRange(arrList1);

            //Clear() 
            arrList2.Clear();

            //Clone()
            arrList2 = (ArrayList)arrList1.Clone();

            //Contains()
            if (arrList2.Contains(2))
                Console.WriteLine("Yes arrayList2 have element 1 at index " + arrList2.IndexOf(1)); //IndexOf()
            else
                Console.WriteLine("No arrayList2 don't have element 1");

            //CopyTo
            int[] arr = new int[10];
            arr[9] = 20;
            arr[2] = 220;
            arrList2.CopyTo(arr);
            Console.WriteLine(string.Join(",", arr));
            arrList2.CopyTo(arr, 3);
            Console.WriteLine(string.Join(",", arr));

            //GetEnumerator
            ArrayList arrList3 = new ArrayList();
            arrList3.Add("Item 1");
            arrList3.Add("Item 2");
            arrList3.Add("Item 3");

            // Get an enumerator using GetEnumerator()
            IEnumerator enumerator = arrList3.GetEnumerator();

            // Use a while loop to iterate through the ArrayList
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            //Sort()
            ArrayList arrList4 = new ArrayList();
            arrList4.Add(10); ;
            arrList4.Add(1); ;
            arrList4.Add(60); ;
            arrList4.Add(5); ;
            arrList4.Add(3);
            arrList4.Sort();
            foreach (int i in arrList4)
            {
                Console.WriteLine(i);
            }

            //special case
            ArrayList arrL = new ArrayList();
            arrayList2.Add(1);
            Console.WriteLine(arrayList2.Capacity);
            arrayList2.Add("abc");
            Console.WriteLine(arrayList2.Capacity);
            arrayList2.Add(1);
            arrayList2.Add(1);
            arrayList2.Add("abc");
            arrayList2.Add(true);
            arrayList2.Add(arrL);
            arrayList2.Add(25.63);
            arrayList2.Add(1);
            arrayList2.Add(1);
            arrayList2.Add("abc");
            arrayList2.Add(true);
            arrayList2.Add(arrL);
            Console.WriteLine(arrayList2.Capacity);
        }
    }
}
