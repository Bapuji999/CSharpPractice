using System;

class Program
{
    static void Main()
    {
        // Example usage:
        Console.WriteLine(FindSubarrayWithMultiplication(5, 6, new int[] { 1, 2, 3, 6, 12 }));  // Output: start = 0, end = 2
        Console.WriteLine(FindSubarrayWithMultiplication(3, 10, new int[] { 11, 33, 44 }));      // Output: -1
        Console.WriteLine(FindSubarrayWithMultiplication(7, 4, new int[] { 1, 4, 3, 2, 2, 9, 6, 7 }));  // Output: start = 3, end = 4
    }

    static string FindSubarrayWithMultiplication(int N, int M, int[] A)
    {
        int start = 0;
        int end = 0;
        int currentProduct = 1;
        int resultStart = -1;
        int resultEnd = -1;

        while (end < N)
        {
            currentProduct *= A[end];

            while (currentProduct > M && start <= end)
            {
                currentProduct /= A[start];
                start++;
            }

            if (currentProduct == M)
            {
                // Update the result indices
                resultStart = start;
                resultEnd = end;
                end++;
            }
            else
            {
                end++;
            }
        }

        if (resultStart != -1)
        {
            return $"start = {resultStart}, end = {resultEnd}";
        }
        else
        {
            return "-1";
        }
    }
}
