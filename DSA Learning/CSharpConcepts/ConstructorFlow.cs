using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.CSharpConcepts
{
    internal class ConstructorFlow
    {
        static void ConstructorFlow_Main(string[] args)
        {
            Women c = new Women();
            Women.display();
            Console.WriteLine(Women.Pval);
        }
    }

    public class Human
    {
        public int HumanAge;

        public static int Pval=20;

        public Human()
        {
            Console.WriteLine("Parent constructor");
        }

        //static Human()
        //{
        //    Console.WriteLine("Static Human Constuctor");
        //}

        public static void display()
        {

        }
    }

    public class Men : Human
    {
        public int MenAge = 20;
        
        public Men()
        {
            Console.WriteLine("Men Constructor");
        }
    }

    public class Women :Human
    {
        public int WomenAge;
        public static int Pval = 10;
        public Women()
        {
            Console.WriteLine("Women Constructor");
        }

        //static Women()
        //{
        //    Console.WriteLine("Static Women Constuctor");
        //}

        public static void display()
        {
            Console.WriteLine("Static Women Display");
        }
    }
}
