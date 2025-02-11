using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.SOLIDPRINCIPLES.OCP
{
    /*
    * 1. OPEN CLOSED PRINCIPLE
    * Open closed Principles says that class should be opened for extension and closed for modification.
    * Problem :We want to add discount for Pune/Mumbai Location?
    * What developer will do is just add discount logic for mumbai/puen location  in same class.
    * It might possible that this might be possible that this discount class can have huge impact.
    * so better to add seperate class for Lcoation discount so this way the existing class is opened for extension
    * anb closed for modification.
    */
    class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Amount { get; set; }
        public char Gender { get; set; }
        public decimal CalculateDiscount()
        {
            Discount dis = new Discount();
            return dis.CalculateDiscount(this);
        }
        public bool Validate()
        {
            if (Name.Length == 0)
            {
                return false;
            }
            if (Amount == 0)
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
            //if (cust.Address.Contains("Pune"))
            //{
            //    return finalAmount - 100;
            //}
            // instead we will new class to handle this situation
            if (amount > 1000)
            {
                var discount = percent / 100;
                decimal dicountAmt = discount * amount;
                finalAmount = finalAmount - discount;
            }
            return finalAmount;
        }
    }
    /*
     * AFTER MODIFICATION
     */
    class LocationDiscount: Discount
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
    internal class OCP
    {
    }
}
