using System.Collections;
using System.Runtime.ExceptionServices;

namespace TaskByAmanSir
{
    class DictonaryWithObjectAndListcapReduce
    {
        public static void Example()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add(1, 2);
            dict.Add("arr", "adict2");

            List<int> list = new List<int>() {1,2,3,4,5,6,7,8,9,10};
            Console.WriteLine(list.Capacity);

            List<int> list2 = new List<int>(list);
            Console.WriteLine(list2.Capacity);
        }
    }
}
