namespace Generic
{
    public class GenericClassPractice <T>
    {
        public T data;
        public void Example()
        {
            
        }
        public bool Add(T a, T b)
        {
           bool result = a.Equals(b);
            return result;
        }
    }
    public interface IGenericInterface<T>
    {
        T GetValue();
        void SetValue(T value);
    }
    public class GenericClass<T> : IGenericInterface<T>
    {
        private T data;

        public T GetValue()
        {
            return data;
        }

        public void SetValue(T value)
        {
            data = value;
        }
    }
}
