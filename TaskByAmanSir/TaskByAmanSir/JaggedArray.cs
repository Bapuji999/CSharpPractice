using System.Security.Cryptography.X509Certificates;

namespace TaskByAmanSir
{
    class JaggedArray
    {
        public static void Example()
        {
            int[][,] arr = new int[3][,];

            arr[0] = new int[,]{ { 1, 2, 8}, 
                                 { 1, 2, 1} //2x3
                               };
            arr[1] = new int[,] { { 1, 2, 3 }, 
                                  { 1, 2, 1 }, 
                                  { 1, 2, 1 } //3x3
                                };
            arr[2] = new int[,] { { 1, 2, 3, 7 }, 
                                  { 1, 2, 1, 9 },
                                  { 1, 2, 3, 7 } //3x4
                                };


            Console.WriteLine(arr[2].Rank);
        }
    }
}
