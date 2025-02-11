using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.SOLIDPRINCIPLES.SRP
{
    /*
     * 1. SINGLE RESPONSIBILITY PRINCIPLE
     */
    /*====================================================================================
    class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Amount { get; set; }
        public char Gender { get; set; }
        public decimal CalculateDiscount()
        {
            decimal amount = this.Amount;
            decimal finalAmount = this.Amount;
            decimal percent = 5;

            if (amount > 1000)
            {
                var discount = percent / 100;
                decimal dicountAmt = discount * amount;
                finalAmount = finalAmount - discount;
            }
            return finalAmount;
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
    ==========================================================================================*/
    /*  if you see Name, Adddress, Amount,Gender, validate method are work of customer class. 
     *  but look at discount calculation done by some other person and not the resposibility of customer class
     * Is discount calaculation the work of customer class?
     *  to achive this SRP we have created another class Discount which will take of discount functionality.
     * Custmer class will take care of his work and discount class will take care of discount functionality
     */

    // AFTER MODIFICATION
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
    internal class CSRP
    {
    }
}
