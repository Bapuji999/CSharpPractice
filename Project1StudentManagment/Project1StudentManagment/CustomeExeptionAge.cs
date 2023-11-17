namespace Project1StudentManagment
{
    class CustomeExeptionAge : ApplicationException
    {
        //public CustomeExeptionAge() { Console.WriteLine("Age cannot be greater than 30 and less than 5."); }
        public CustomeExeptionAge() : base("Age cannot be greater than 30 and less than 5.") { }
    }
}
