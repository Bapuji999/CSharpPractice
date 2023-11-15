﻿using System.Runtime.CompilerServices;

namespace Multi_Threading
{
    class TaskBasedAsynchronousProgramming
    {
        public async static Task Example()
        {
            TaskBasedAsynchronousProgramming taskBasedAsynchronousProgramming = new TaskBasedAsynchronousProgramming();
            await taskBasedAsynchronousProgramming.Example1();
            Console.WriteLine("Hi");
            Console.WriteLine("Hi");
            List<int> numbers = Enumerable.Range(1, 5).ToList();

            Func<Task> ab = async () =>
            {
                Console.WriteLine("Async function started.");
                await Task.Delay(2000);
                Console.WriteLine("Async function completed.");
            };
        }
        public Task<string> Example1()
        {
            Console.WriteLine("Hi");
            Console.WriteLine("Hi");
            return this.Example2();
        }
        public async Task<string> Example2()
        {
            Console.WriteLine("Hi");
            Console.WriteLine("Hi");
            return "hi";
        }

    }
}
