using System.ComponentModel;

namespace BasicandOOPsPart1Practice
{
    class Namespaces
    {
    }
    namespace NameSpace1
    {
        class A
        {
            public int Add(int a , int b)
            {
                return a + b;
            }
        }
    }
    namespace NameSpace2
    {
        class A
        {
            public void Use()
            {
                NameSpace1.A A = new NameSpace1.A();
                A.Add(9, 10);
            }
        }
    }
}
