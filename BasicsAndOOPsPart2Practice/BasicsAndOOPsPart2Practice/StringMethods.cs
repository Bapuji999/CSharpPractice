namespace BasicsAndOOPsPart2Practice
{
    class StringMethods
    {
        public void StingExample()
        {
            string myString = "Hello, World!";

            //Length Property
            int length = myString.Length;

            //Methods

            //Substring
            string subString = myString.Substring(0, 5); // "Hello"

            //ToUpper and ToLower
            string upperCase = myString.ToUpper(); // "HELLO, WORLD!"
            string lowerCase = myString.ToLower(); // "hello, world!"

            //Replace
            string replaced = myString.Replace("Hello", "Hi"); // "Hi, World!"

            //Trim
            string withWhitespace = "   Trim me   ";
            string trimmed = withWhitespace.Trim(); // "Trim me"

            //Split
            string data = "apple,banana,orange";
            string[] fruits = data.Split(','); // ["apple", "banana", "orange"]

            //Contains
            string sentence = "This is a sample sentence.";
            bool containsWord = sentence.Contains("sample"); // true

            //StartsWith and EndsWith
            string filename = "document.txt";
            bool startsWithDoc = filename.StartsWith("doc"); // true
            bool endsWithTxt = filename.EndsWith("txt"); // true

            //IndexOf and LastIndexOf
            string sentence1 = "This is a sample sentence with sample word.";
            int firstIndex = sentence1.IndexOf("sample"); // 10
            int lastIndex = sentence1.LastIndexOf("sample"); // 31

            string str1 = "apple";
            string str2 = "banana";
            int result = string.Compare(str1, str2);// a negative value
        }
    }
}
