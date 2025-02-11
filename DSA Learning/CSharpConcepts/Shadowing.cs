using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.CSharpConcepts.Shadowing
{
    internal class CShadowing
    {
        static void CShadowing_Main(string[] args)
        {
            List<Customer>cust = new List<Customer>();
            Customer customer = new Discounted();
            customer.Name = "ABC";
            customer.Address = "pune";
            customer.TotalBill = 1200;
            customer.CalculateDiscount();
            cust.Add(customer);

            customer = new GeoDiscounted();
            customer.Name = "ABC";
            customer.Address = "pune";
            customer.TotalBill = 1200;
            customer.CalculateDiscount();
            cust.Add(customer);

            customer = new Enquiry();
            customer.Name = "ABC";
            customer.Address = "pune";
            customer.TotalBill = 1200;
            customer.CalculateDiscount();
            cust.Add(customer);

        }
    }

    class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual decimal TotalBill{ get; set;}
        public virtual decimal CalculateDiscount() {
            return 0;
        }
    }

    class Discounted :Customer
    {
        public override decimal CalculateDiscount()
        {
            if(TotalBill > 1100)
            {
                return TotalBill - 10;
            }
            return base.CalculateDiscount();
        }

    }

    class GeoDiscounted : Customer
    {
        public override decimal CalculateDiscount()
        {
            if (Address.Equals("pune"))
            {
                return TotalBill - 100;
            }
            return base.CalculateDiscount();
        }
    }
    
    class Enquiry : Customer
    {
        //public override decimal CalculateDiscount()
        //{
        //    throw new NotImplementedException("Just Enquiry for Lead");
        //}

        // replcae with new keyword to hide it from Parent

        public new decimal CalculateDiscount()
        {
            throw new NotImplementedException("Just Enquiry for Lead");
        }
    }
}
