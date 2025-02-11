using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.SOLIDPRINCIPLES
{
    /*
     * 
     * 
     * Customer Class is directly dependent on Discount class 
     * therefore any change in Discount class will lead to change in Customer class
     * So we will create an abstraction using interface to calculate discount.
     * 
     * Dependency inversion solve decoupling problem ?
     *  No.Object creation in dependency inversion should happen in high level class. 
     *  As you can see that we are creating object in customer class which is not responsibility of customer class
     *  we have to invert this job some other fucntion.

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

    public class Customer : Customerbase
    {
        public virtual decimal Amount { get; set; }

        /*/Before Change
        public virtual decimal CalculateDiscount()
        {
            Discount dis = new Discount();
            return dis.CalculateDiscount(this);
        }
        */

        //After change
        //private IDiscount discount = new WeekEndDiscount();
        public virtual decimal CalculateDiscount()
        {
            return discount.CalculateDiscount(this);
        }

        //Again mopdificatin for dependent object creation
        private IDiscount discount = null;
        public Customer(IDiscount dis)
        {
            discount = dis;
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

    public interface IDiscount
    {
        decimal CalculateDiscount(Customer cust);
    }

    class PlatiniumCustomer : Customer
    {
        public PlatiniumCustomer(IDiscount dis) : base(dis)
        {

        }
        public override decimal Amount
        {
            get { return base.Amount; }
            set { base.Amount = value; }
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

    class Discount : IDiscount
    {
        public decimal CalculateDiscount(Customer cust)
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

    class LocationDiscount : Discount, IDiscount
    {
        public new decimal CalculateDiscount(Customer cust)
        {
            if (cust.Address.Contains("Pune"))
            {
                return cust.Amount - 100;
            }
            return cust.Amount;
        }
    }

    class WeekEndDiscount : Discount, IDiscount
    {
        public new decimal CalculateDiscount(Customer cust)
        {
            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                case DayOfWeek.Saturday:
                    {
                        return cust.Amount - 10;
                    }
                default:
                    {
                        return cust.Amount;
                    }
            }
        }
    }
    internal class DependencyInversion
    {
        static void DependencyInversion_Main(string[] args)
        {
            Customer c = new PlatiniumCustomer(new WeekEndDiscount());
            c.CalculateDiscount();
        }
    }
}
