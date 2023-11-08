namespace BasicsAndOOPsPart2Practice
{
    class InheritanceExample
    {
        public void Example()
        {
            
        }
    }

    //Single
    class A
    {
       public int x;
    }

    class B : A
    {
       int Y;
    }

    //Multilevel
    class C
    {
        public int x;
    }
    
    class D : C
    {
        public int y;
    }
    class E : D
    {
        public int z;
    }

    //Hybrid
    class F
    {
        public int x;
    }

    class G : F
    {
        public int y;
    }

    class H : F
    {
        public int z;
    }
}
