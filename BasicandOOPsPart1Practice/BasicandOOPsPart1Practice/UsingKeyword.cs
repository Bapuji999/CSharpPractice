//Directive
using System; // Importing the System namespace
using Dict = System.Collections.Generic.Dictionary<string, int>; //Alias for Types
using System.Linq; // Importing extension methods of Static Classes

namespace BasicandOOPsPart1Practice
{
    class UsingKeyword
    {
        void example(string[] args)
        {
            using (FileStream file = new FileStream("example.txt", FileMode.Open))
            {
                
            }// The using statement will automatically call fileStream.Dispose() when the block is exited
        }
    }
}
