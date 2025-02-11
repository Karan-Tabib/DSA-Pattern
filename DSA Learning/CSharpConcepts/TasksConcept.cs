using System.Threading.Tasks;

namespace Learning.CSharpConcepts
{
    internal class TasksConcept
    {
        public static int Method1()
        {
            int sum = 0;
            for(int i=0;i<10; i++)
            {
                sum += i;
            }
            return sum;
        }

        public static  void Method2()
        {
            for(int i=0;i<10;i++)
            {

            }
        }


        static void Main_Method(string[] args)
        {
            Task<int> task = Task.Run(() => Method1());
            int result = task.Result;

            Console.WriteLine(result);
        }
    }
}
