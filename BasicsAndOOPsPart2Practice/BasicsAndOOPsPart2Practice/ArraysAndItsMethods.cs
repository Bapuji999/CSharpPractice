using System.Security.Cryptography.X509Certificates;

namespace BasicsAndOOPsPart2Practice
{
    class ArraysAndItsMethods
    {
        public void ArrayDeclare()
        {
            //Array Initialization
            int[] array = new int[10];
            int[] array2 = new int[1] { 1 };
            int[] array3 = { 1, 2, 3 };
            var arr4 = new[] {1,2,3};
            dynamic arr5 = new[] {1,2,3};
            object[] mixedArray = new object[] { 42, "Hello", 3.14, true };

            //Array Properties
            Console.WriteLine("Length is: " + array.Length); //Gets the total number of elements in all the dimensions of the Array.
            Console.WriteLine("Rank is: "+array.Rank); //Gets the rank (number of dimensions) of the Array.

            //Array Methods 
            int[] arr = {1, 2, 3};

            //Find
            int evenNumber = Array.Find(arr, n => n % 2 == 0);
            Console.WriteLine("Even number is "+ evenNumber);

            //FindAll
            var oddNumber = Array.FindAll(arr, n => n % 2 != 0);
            Console.WriteLine("Odd number is " + string.Join(", ", oddNumber));

            //Exists
            bool exist = Array.Exists(arr, n => n==2);
            Console.WriteLine("Exists: "+exist);

            //Clone
            int[] arrCloned = (int[])arr.Clone();

            //Equals
            bool equal = Array.Equals(arrCloned, arr);
            Console.WriteLine("Cloned: "+equal);
            arrCloned = arr;
            equal = Array.Equals(arrCloned, arr);
            Console.WriteLine("Equals to: " + equal);

            //Empty
            int[] arr3 = Array.Empty<int>();

            //Copy
            arr3 = new int[3];
            Array.Copy(arr, arr3, arr.Length);
            Console.WriteLine("arr3 [" + string.Join(", ", arr3)+"]");

            //CopyTo
            int[] arr6 = new int[3];
            arr.CopyTo(arr6, 0);
            Console.WriteLine("arr6 [" + string.Join(", ", arr6) + "]");

            //IndexOf
            int index = Array.IndexOf(arr, 2);
            Console.WriteLine("Index of 2 is: "+index);

            //Reverse
            Array.Reverse(arr);
            Console.WriteLine("arr Reversed [" + string.Join(", ", arr) + "]");

            //Sort
            Array.Sort(arr);
            Console.WriteLine("arr Sorted [" + string.Join(", ", arr) + "]");

            //ToString
            string arrayString = arr.ToString();
            Console.WriteLine(arrayString);
        }
    }
}
