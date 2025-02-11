using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.GarbageCollector
{
    internal class GarbageCollectorDemo
    {
        static List<SomeClass> mylist = new List<SomeClass>();
        static void GarbageCollectorDemo_Main(string[] args)
        {
            Console.WriteLine("Press Enter to start!!");
            Console.Read();
            for (double i = 0; i < 100000000000; i++)
            {
                using (var x = new SomeClass())
                {
                    x.SomeData = DateTime.Now.ToString();
                }
            }
        }
    }

    internal class SomeClass :IDisposable
    {
        public string? SomeData { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
