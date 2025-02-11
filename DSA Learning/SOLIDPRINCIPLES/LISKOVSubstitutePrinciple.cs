using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.SOLIDPRINCIPLES.LISKOV
{
    /*
     * LISKOV Sibstitution PRNCIPLE
     * 
     * Customer class has property like Name,Address, Amount, Gender and method are Calculate Discount and validate
     * there are two classes platinium and Enquiry customer which are deriving from Customer 
     *  As you can see the Enquiry customer does not buy anything he just enquired still he has to implement discount method.
     *  
     *  ANSwer:
     *  by Refactoring we can resolve LISKOV Sibstitution problem
     */

    public class Customerbase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }
        public virtual bool Validate()
        {
            if (Name.Length == 0)
            {
                return false;
            }
            return true;
        }
    }

    public class Customer :Customerbase
    {
        public virtual decimal Amount {  get; set; }    
        public virtual decimal CalculateDiscount()
        {
            Discount dis = new Discount();
            return dis.CalculateDiscount(this);
        }
        public override bool Validate()
        {
            if (Name.Length == 0)
            {
                return false;
            }
            return true;
        }
    }

    class PlatiniumCustomer : Customer
    {
        public override decimal Amount
        {
            get { return base.Amount; }
            set { base.Amount = value; }
        }
        public override decimal CalculateDiscount()
        {
            return base.CalculateDiscount();
        }
    }

    class EnquiryCustomer : Customerbase
    {
        public override bool Validate()
        {
            if (Name.Length == 0)
            {
                return false;
            }
            return true;
        }
    }

    class Discount
    {
        public virtual decimal CalculateDiscount(Customer cust)
        {
            decimal amount = cust.Amount;
            decimal finalAmount = cust.Amount;
            decimal percent = 5;
            if (amount > 1000)
            {
                var discount = percent / 100;
                decimal dicountAmt = discount * amount;
                finalAmount = finalAmount - discount;
            }
            return finalAmount;
        }
    }

    class LocationDiscount : Discount
    {
        public override decimal CalculateDiscount(Customer cust)
        {
            if (cust.Address.Contains("Pune"))
            {
                return cust.Amount - 100;
            }
            return cust.Amount;
        }
    }

    public class LISKOVSubstitutePrinciple
    {
        static void LISKOVSubstitutePrinciple_Main(string[] args)
        {
            Customer obj = new Customer();

            obj = new PlatiniumCustomer();
            obj.CalculateDiscount();

           Customerbase obj1 = new EnquiryCustomer();
            obj.Validate();
        }

    }
}
