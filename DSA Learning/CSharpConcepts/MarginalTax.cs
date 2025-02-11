using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.CSharpConcepts
{
    internal class MarginalTax
    {
        static void MarginalTax_Main(string[] args)
        {
            double[] slab = new double[] { 0, 1000 };
            double[] rate = new double[] { 0.1, 0.5 };
            double income = 2000;
            Console.WriteLine(CalculateMarginalTax(slab, rate, income).ToString());
        }

        public static double CalculateMarginalTax(double[] slab, double[] rate, double income)
        {
            double tax = 0;
            if (income <= 0)
            {
                return tax;
            }
            double remainingAmount = income;
            for (int i = 0; i < slab.Length; i++)
            {
                if (i < slab.Length - 1)
                {
                    tax += (slab[i + 1] - slab[i]) * rate[i];
                    remainingAmount -= slab[i + 1];
                }
                else
                {
                    tax += remainingAmount * rate[i];
                }
            }
            return tax;
        }
    }


    class MarginalTaxSystem
    {
        public static double CalculateTax(double[] slab, double[] rate, double income)
        {
            double totalTax = 0;
            int numOfSlabs = slab.Length;

            // Iterate through each slab and calculate the tax for the corresponding income part
            for (int i = 0; i < numOfSlabs; i++)
            {
                // Check how much of the income falls in the current slab
                double slabAmount = (i == numOfSlabs - 1) ? income - slab[i] : Math.Min(income - slab[i], slab[i + 1] - slab[i]);

                // If income is below the current slab, no more tax to be calculated
                if (slabAmount <= 0)
                    break;

                // Tax the income portion within this slab at the corresponding rate
                totalTax += slabAmount * rate[i];
            }

            return totalTax;
        }

        static void CMain(string[] args)
        {
            double[] slab = new double[] { 0, 1000 };  // Slab starting points
            double[] rate = new double[] { 0.1, 0.5 }; // Corresponding rates
            double income = 2000;  // Income to be taxed

            double tax = CalculateTax(slab, rate, income);
            Console.WriteLine($"Total tax for an income of {income} is {tax}");
        }
    }

}
