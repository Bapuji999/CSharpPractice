using System.Security.Cryptography.X509Certificates;

namespace TaskByAmanSir
{
    class JaggedArray
    {
        public static void Example()
        {
            int[][,,] arr = new int[3][,,];

            int[] arr1 =new int[] {1,2,3};
            arr[0] = new int[,,]
            {
                { 
                    { 1, 2, 8},
                    { 1, 2, 1} 
                },
                {
                    {1,2,3 },
                    {1,2,3 }
                }
            };
            arr[1] = new int[,,]
            {
                {
                    { 1, 2, 8},
                    { 1, 2, 1}
                },
                {
                    {1,2,3 },
                    {1,2,3 }
                }
            };


            Console.WriteLine(arr[1][1,1,2]);
        }
    }
}
