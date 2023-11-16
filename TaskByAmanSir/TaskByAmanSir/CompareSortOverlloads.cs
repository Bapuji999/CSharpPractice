namespace TaskByAmanSir
{
    class CompareSortOverlloads
    {
        public static void Examle()
        {
            //List of object
            List<object> list = new List<object>() { 1, 20, "Bapuji", "asd", 12.80, 2 };
            //list.Sort(); //Cannot compare objects of different types

            list.Sort(new CustomComparer());
            Console.WriteLine(string.Join(",", list));
            list.Sort(2, 3, new CustomComparer());
            Console.WriteLine(string.Join(",", list));
            list.Sort((x, y) => CompareObjects(x, y));// Sort the list using a custom comparison delegate

            Console.WriteLine(string.Join(",",list));


            static int CompareObjects(object x, object y)
            {
                // Compare based on the type of the objects
                if (x is int && y is int)
                {
                    return ((int)x).CompareTo((int)y);
                }
                else if (x is string && y is string)
                {
                    return String.Compare((string)x, (string)y, StringComparison.Ordinal);
                }
                else if (x is double && y is double)
                {
                    return ((double)x).CompareTo((double)y);
                }
                else
                {
                    // For other types, use their GetHashCode for comparison
                    return x.GetHashCode().CompareTo(y.GetHashCode());
                }
            }
        }
    }
    public class CustomComparer : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            return x.GetHashCode().CompareTo(y.GetHashCode());
        }
    }
}
