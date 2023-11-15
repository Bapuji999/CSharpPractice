namespace Multi_Threading
{
    class ThreadingExample
    {
        public static void Run()
        {
            Thread myThread = new Thread(MyMethod); //State: Created

            myThread.Start(); //Start method does not return until the new thread has started running
                              //State: Running
            myThread.Name = "Worker";
            myThread.Priority = ThreadPriority.Highest;
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine("Thread Id {0}: ", currentThread.ManagedThreadId);
            Console.WriteLine("Thread Name : {0} ", currentThread.Name);
            Console.WriteLine("Is thread background: {0}", currentThread.IsBackground);
            Console.WriteLine("Priority: {0}", currentThread.Priority);
            Console.WriteLine("Culture: {0}", currentThread.CurrentCulture.Name);
            Console.WriteLine("UI Culture: {0}", currentThread.CurrentUICulture.Name);
            Console.WriteLine();
            myThread.Join();
            // Main thread continues to execute other tasks
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main thread: {i}");
                Thread.Sleep(1000);//State :WaitSleepJoin (The thread calls Sleep)
            }
        }
        static void MyMethod()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread currentThread = Thread.CurrentThread;
                Console.WriteLine("Thread Id {0}: ", currentThread.ManagedThreadId);
                Console.WriteLine("Thread Name : {0} ", currentThread.Name);
                Console.WriteLine("Is thread background: {0}", currentThread.IsBackground);
                Console.WriteLine("Priority: {0}", currentThread.Priority);
                Console.WriteLine("Culture: {0}", currentThread.CurrentCulture.Name);
                Console.WriteLine("UI Culture: {0}", currentThread.CurrentUICulture.Name);
                Console.WriteLine();
                Console.WriteLine($"Worker thread: {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
