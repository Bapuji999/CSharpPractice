namespace WebAPI1.Examples
{
    public class DIwithAllMethods
    {
        public void Examples()
        {
            ConstructureExample CE = new ConstructureExample(new DataA());
            var result = CE.Result();

            PropertyExample PE = new PropertyExample();
            PE.Data = new DataA();
            var data = PE.Data.GetData();

            MethodExample ME = new MethodExample();
            ME.GetData(new DataA());
        }
    }
    public class MethodExample()
    {
        public int GetData(IDataA dataA)
        {
            return dataA.GetData();
        }
    }
    public class PropertyExample()
    {
        private IDataA data;
        public IDataA Data
        {
            get 
            { 
                if (data == null)
                {
                    throw new Exception("Object not Passed to property");
                }
                else
                {
                    return data;
                }
            }
            set { data = value; }
        }
    }
    public class ConstructureExample
    {
        private IDataA dataA;
        public ConstructureExample(IDataA IDataA)
        {
            dataA = IDataA;
        }
        public int Result()
        {
            return dataA.GetData();
        }
    }
    public interface IDataA
    {
        public int GetData();
    }
    public class DataA : IDataA
    {
        public int GetData()
        {
            return 10;
        }
    }
}
