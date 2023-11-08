        // Create an array of four elements, and add values later
        string[] cars = new string[4];

        // Create an array of four elements and add values right away 
        string[] cars1 = new string[4] { "Volvo", "BMW", "Ford", "Mazda" };

        // Create an array of four elements without specifying the size 
        string[] cars2 = new string[] { "Volvo", "BMW", "Ford", "Mazda" };

        // Create an array of four elements, omitting the new keyword, and without specifying the size
        string[] cars3 = { "Volvo", "BMW", "Ford", "Mazda" };

        foreach (string car in cars3) 
        { 
            Console.WriteLine(car);
        }
        string text = "Hello, World!";
        string substring = text.Substring(1, 5);
        Console.WriteLine(substring);
        int? abss = null;
        switch(true)
        {
            case true: 
                abss = 0; 
                break;
            case false:
                abss = 0;
                break;
            default: 
                abss = 0; 
                break;
        }
        int a = 10;
        object ab = a;
        int abc = (int)ab;
    int? add(int b, dynamic a = null)
    {
        return null;
    }
Console.WriteLine(add(1, 2));

void MyMethod(int requiredParam, int optionalParam = 10)
{
    Console.WriteLine(requiredParam +"  "+ optionalParam);
}

MyMethod(optionalParam: 15, requiredParam: 20);
