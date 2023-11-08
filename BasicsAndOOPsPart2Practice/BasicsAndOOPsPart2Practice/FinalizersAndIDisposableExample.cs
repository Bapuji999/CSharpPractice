using System.IO;

namespace BasicsAndOOPsPart2Practice
{
    class FinalizersAndIDisposableExample
    {
        void example(string[] args)
        {
            FileStream file1 = new FileStream("example.txt", FileMode.Open);
            file1.Dispose();

            using (FileStream file2 = new FileStream("example.txt", FileMode.Open))
            {

            }// The using statement will automatically call fileStream.Dispose() when the block is exited

            FileStream file3 = new FileStream("example.txt", FileMode.Open);
        }
    }
}
