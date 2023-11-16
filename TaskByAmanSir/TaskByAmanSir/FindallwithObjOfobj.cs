namespace TaskByAmanSir
{
    class FindallwithObjOfobj
    {
        public static void Example()
        {
            List<ObjOut> list = new List<ObjOut>();
            for (int i = 1; i < 6; i++) 
            {
                ObjOut objOut = new ObjOut();
                for (int j = 1; j < 6; j++)
                {
                    ObjIn objIn = new ObjIn();
                    objIn.a = i+j;
                    objOut.list.Add(objIn);
                }
                list.Add(objOut);
            }
            var ab = list.FindAll((x) => {
                foreach (var obj in x.list)
                {
                    if (obj.a > 5)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            });
            Console.WriteLine(string.Join(",",ab));

            int[] numbers = { 1, 2, 3, 4, 5 };

            bool containsThree = numbers.Contains(3); // true
            bool containsTen = numbers.Contains(10);   // false
        }
    }
    class ObjOut
    {
        public List<ObjIn> list = new List<ObjIn>();
    }
    class ObjIn
    {
        public int a {  get; set; }
    }
}
