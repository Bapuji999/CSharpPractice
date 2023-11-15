namespace TuplesExample
{
    class ExeptionHandling
    {
        public static void Example()
        {
            try
            {
                int[] arr = new int[2];
                arr[0] = 1;
                arr[1] = 2;
                arr[2] = 3;
                arr[3] = 4;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("OK");
            }
        }
    }
}
