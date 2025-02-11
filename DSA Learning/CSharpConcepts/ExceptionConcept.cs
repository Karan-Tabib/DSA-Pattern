using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.CSharpConcepts
{
    internal class ExceptionConcept
    {
        /*      
         * //  
               Anwser :
                In Catch block
                "In finally block!!
                if you have return in catch then main execution will stop.

            if we have multiple catch statement and Exception is first catch and then divided be zero or other exception 
            then it will give error.
        catch(Exception ex)
            {
                Console.WriteLine("In Catch block");
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine("Divided be Zero");
            }
         * 
         * 
         * 
         */
        static void Exception_Main(string[] args)
        {
            try
            {
                int number = 100;
                int num2 = 0;

                int i = number / num2;

                Console.WriteLine("After Exception");
            }catch(Exception ex)
            {
                Console.WriteLine("In Catch block");
            }
            finally
            {
                Console.WriteLine("In finally block!!");
            }

            Console.WriteLine("Main block Executin!!");
        }
    }
}
