namespace WebAPI1
{
    public interface IEmploye
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public interface ITrans
    {
        public int GetCallNo();
    }
    public interface IScope
    {
        public int GetCallNo();
    }
    public interface ISingle
    {
        public int GetCallNo();
    }
    public class Single: ISingle
    {
        private static int instanceCount = 0;
        private int incrementedValue;
        public int IncrementedValue => incrementedValue;
        public Single()
        {
            incrementedValue = ++instanceCount;
        }
        public int GetCallNo()
        {
            return incrementedValue;
        }
    }
    public class Single1 : ISingle
    {
        private static int instanceCount = 0;
        private int incrementedValue;
        public int IncrementedValue => incrementedValue;
        public Single1()
        {
            incrementedValue = ++instanceCount + 1;
        }
        public int GetCallNo()
        {
            return incrementedValue;
        }
    }
    public class Scope : IScope
    {
        private static int instanceCount = 0;
        private int incrementedValue;
        public int IncrementedValue => incrementedValue;
        public Scope()
        {
            incrementedValue = ++instanceCount;
        }
        public int GetCallNo()
        {
            return incrementedValue;
        }
    }
    public class Trans : ITrans
    {
        private static int instanceCount = 0;
        private int incrementedValue;
        public int IncrementedValue => incrementedValue;
        public Trans()
        {
            incrementedValue = ++instanceCount;
        }
        public int GetCallNo()
        {
            return incrementedValue;
        }
    }
    public class Employe : IEmploye
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
