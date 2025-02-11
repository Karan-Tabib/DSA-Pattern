using System.Threading;
namespace Learning.CSharpConcepts
{
    internal class ThreadingConcept
    {
        public ThreadingConcept() { }

        public void Method1()
        {
            for (int i = 0; i < 5; i++) {
                Console.WriteLine(" Method1 Item : {0}", i);
            }
            Console.WriteLine("Thread Sleep .. Assume Taking more time to execute task");
            Thread.Sleep(10000);
            Console.WriteLine("Thread Sleep End");

        }

        public void Method2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Method2 Item : {0}", i);
            }
        }
        static void Main_Method(String[] args)
        {
            ThreadingConcept con = new ThreadingConcept();
            // this Will Run on Main thread of Application
            //con.Method1();
            //con.Method2();
            //Console.WriteLine();

            //Thread t1= new Thread(new ThreadStart(con.Method1));
            //t1.Start();
            //Thread t2 = new Thread(new ThreadStart(con.Method2));
            //t2.Start();


            //Thread t3 = new Thread(new ThreadStart(CThreadSynchronization.IncrementCount));
            //t3.Start();

            //Thread t4 = new Thread(new ThreadStart(CThreadSynchronization.IncrementCount));
            //t4.Start();

            //Thread t5 = new Thread(new ThreadStart(CThreadSynchronization.IncrementCount));
            //t5.Start();

            //t3.Join();
            //t4.Join();
            //t5.Join();

            //Console.WriteLine("Counter= " + CThreadSynchronization.counter);

            ThreadingExample.Main_Method();
           
        }
    }

    internal class CThreadSynchronization
    {
        public static int counter = 0;
        public static readonly object _lockobject = new object();
        
        public static void IncrementCount()
        {
            for (int i = 0; i < 1000; i++) {

                lock(_lockobject)
                {
                    counter++;
                }
            }
        }
    }

  internal class ThreadingExample
    {
        // no of resources
        private static int[] resourcepool = new int[5];

        //Resources in Used;
        private static bool[] resourcesInUsed = new bool[5];

        //semaphore to limit number of thread accessing resource pool
        private static SemaphoreSlim semaphore = new SemaphoreSlim(3);

        //Auto reset Event for signling Availability of resources
        private static AutoResetEvent resourceAvailable = new AutoResetEvent(false);

        //Monitor object to Synchronize access to  the resouce pool
        private static readonly object monitorLock = new object();  


      public   static void Main_Method()
        {
            //Initialization of resouce pool
            for(int i=0;i<resourcepool.Length;i++) {
                resourcepool[i] = i + 1;
            }

            Thread[] threads = new Thread[10];

            for(int i=0;i< 10; i++)
            {
                threads[i] = new Thread(AccessResource);
                threads[i].Name = $"Thread {i + 1}";
                threads[i].Start();
            }

            for (int i = 0; i < 10; i++)
            {
                threads[i].Join();
            }


            Console.WriteLine("Main Thread Completed...");
        }


        private static void AccessResource()
        {
            semaphore.Wait();
            int resouces = -1;
            Monitor.Enter(monitorLock);
            try
            {
                //find Available resource

                for(int i= 0; i< resourcepool.Length; i++)
                {
                    if (!resourcesInUsed[i])
                    {
                        resouces = resourcepool[i];
                        resourcesInUsed[i] = true;
                        break;
                    }
                }
            }
            finally
            {
                Monitor.Exit(monitorLock);
            }

            if(resouces == -1) {
                Console.WriteLine("Resource are not Avaialble " + Thread.CurrentThread.Name);
            }
            else
            {
                Console.WriteLine("Resources Are Available" + Thread.CurrentThread.Name);
                Thread.Sleep(new Random().Next(500, 2000));
                ReleaseResource(resouces);
            }
        }

        private static void ReleaseResource(int resouce)
        {
            Monitor.Enter(monitorLock) ;
            try
            {
                for(int i=0; i< resourcepool.Length; i++)
                {
                    if (resourcepool[i] ==resouce)
                    {
                        resourcesInUsed[i] = false;
                        Console.WriteLine("Resource Release " + Thread.CurrentThread.Name);
                        resourceAvailable.Set();
                        break;
                    }
                }
            }
            finally
            {
                Monitor.Exit(monitorLock) ;
            }
        }
    }

}
