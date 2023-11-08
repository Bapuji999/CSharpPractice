using DelegatesPractice;
using System.Runtime.CompilerServices;

class Pogram
{
    public static void Main(String[] args)
    {
        DelegateExample delegateExample = new DelegateExample();
        delegateExample.Calculate(8, 9, "Add");
        delegateExample.Calculate(8, 9, "Mul");

        MultiCastDelegateExample multiCastDelegateExample = new MultiCastDelegateExample();
        multiCastDelegateExample.Calculate(8, 9);

        AnonymousMethodExample anonymousMethodExample = new AnonymousMethodExample();
        anonymousMethodExample.Calculate(8, 9);

        LamdaExpressionExample lamdaExpressionExample = new LamdaExpressionExample();
        lamdaExpressionExample.Example();
        Console.WriteLine(lamdaExpressionExample.sub(20, 10));
    }
}