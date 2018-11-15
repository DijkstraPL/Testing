using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Sample);
            Thread thread = new Thread(threadStart);
            thread.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
        
        static void Sample()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(".");
            }
        }
    }
}
