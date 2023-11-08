using Practice2;
class Pogram
{
    private string asp {  get; set; } 
    public static void Main(string[] args)
    {
        Console.WriteLine(Staticexample.a);
        Check ch = new Check();
        int[] arr = { 1, 2, 3 };
        ch.Click(a:5, 1, 3, 5);
        Console.WriteLine(Staticexample.a);
        Check ch1 = new Check();
        Console.WriteLine(Staticexample.a);
        Console.WriteLine(Staticexample.Ok());
        int[] arr2 = new int[3];
        arr2[0] = 1;
        arr2[1] = 2;
        arr2[2] = 3;
        int[] arr3 = new int[arr2.Length];
        Array.Copy(arr2 , arr3, arr2.Length);
        Console.WriteLine(arr3.Length);
        string name = "Alice";
        string message = $"Hi {name}!";
        Console.WriteLine(message);
        int[] numbers = { 5, 2, 9, 1, 5 };
        Array.Sort(numbers);
        foreach (int i in numbers) Console.WriteLine(i);
        int index = Array.BinarySearch(numbers, 5);
        Console.WriteLine(index);
        Point P1;
        Point P2 = new Point(10, 20);
        P1.x = 10;
        P1.y = 10;
        Console.WriteLine(P1.x);
        Console.WriteLine(P2.x);
        Console.WriteLine(P1.y);
        Console.WriteLine(P2.y);

        Class1 examples = new Class1();
        examples.a = 1;
        examples.b = 2;
        Person person = new Person("Anil", "Kumar");
        Console.WriteLine(person);
        Console.WriteLine(person.FirstName);
        Console.WriteLine(person.LastName);
    }
}
public record Person(string FirstName, string LastName);
struct Point
{
    public int x;
    public int y;
    public Point(int x, int y)
    {
        this.y = y;
        this.x = x;
    }
}
static class Staticexample
{ 
    public static int a;

    public static string Ok()
    {
        return "Ok";
    }
}
class Check
{
   public Check()
    {
        Staticexample.a += 25;
    }
    public void Click(int a, params int[] c)
    {
        foreach(int i in c)
        {
            Console.WriteLine(i+a);
        }
    }
    public string add()
    {
        return string.Empty;
    }
    public int add(int a)
    {
        return a;
    }
    private string abc
    {
        get { return abc; }
        set { abc = value; }
    }
}