using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.CSharpConcepts
{
    public interface ICustomer
    {
        string name { get; set; }
        string add { get; set; }
        string productname { get; set; }
        decimal productAmount { get; set; }
        decimal CalculateDiscount();
    }
    public abstract class Customer : ICustomer,ICustomerWithInterest
    {
        public string name { get; set; }
        public string add { get; set; }
        public string productname { get; set; }
        public decimal productAmount { get; set; }
        public abstract decimal CalculateDiscount();
        public decimal CalculateInterest()
        {
            return 0;
        }
    }

    public class GoldCustomer : Customer
    {
        public override decimal CalculateDiscount()
        {
            return 10;
        }
    }
    public class SilverCustomer : Customer
    {
        public override decimal CalculateDiscount()
        {
            return 5;
        }
    }

    // can you add new method in ICusotmer 
    // we can add new method to ICustomer but that will enforce existing user to implement new Methods 
    // which may be required for all customers
    // to handle this situation we can create interace and attached to only those users which are required.

    public interface ICustomerWithInterest : ICustomer
    {
        decimal CalculateInterest();
    }

    // we can add this interface to 
    public class CInterfaceDemo
    {
        static void InterfaceDemo_Main(string[] args)
        {
            ICustomer x = new GoldCustomer();
            x.name ="Test";
            x.productname ="Test";
            x.productAmount = 100;
            x.CalculateDiscount();

            ICustomer x1 = new SilverCustomer();
            x1.name = "Test";
            x1.productname = "Test";
            x1.productAmount = 100; 
            x1.CalculateDiscount();


            ICustomerWithInterest x2 = new SilverCustomer();
            x2.name = "Test";
            x2.productname = "Test";
            x2.productAmount = 100;
            x2.CalculateDiscount();
            x2.CalculateInterest();
            Console.ReadLine();
        }
    }
}
