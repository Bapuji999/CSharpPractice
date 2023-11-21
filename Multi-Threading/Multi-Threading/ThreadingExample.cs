namespace Multi_Threading
{
    class ThreadingExample
    {
        public static void Run()
        {
            ThreadPool.QueueUserWorkItem(DoWork, 1);
            ThreadPool.QueueUserWorkItem(DoWork, 2);
            ThreadPool.QueueUserWorkItem(DoWork, 3);
            ThreadPool.QueueUserWorkItem(PrintNumbers);
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
            Console.WriteLine("-----------------------------------------------");
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
        static void PrintNumbers(object state)
        {
            // This method represents the work item that will be executed by a thread pool thread
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
        static void DoWork(object state)
        {
            int taskId = (int)state;
            Console.WriteLine($"Task {taskId} executed by thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
