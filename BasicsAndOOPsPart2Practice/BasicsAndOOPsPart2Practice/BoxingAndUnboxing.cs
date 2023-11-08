namespace BasicsAndOOPsPart2Practice
{
    class BoxingAndUnboxing
    {
        public void Example()
        {
            int a = 1;
            object b = a; //Boxing
            a = (int)b; //Unboxing using explicit conversion
            a = Convert.ToInt32(a); //Unboxing using Convert Class
            a = int.Parse(a.ToString()); //Unboxing using Parse method
        }
    }
}
