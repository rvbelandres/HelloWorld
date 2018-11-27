using System;
using System.Linq;
using NumberToWords.Helpers;

namespace NumberToWords
{
    class Program
    {
        public static void Main(string[] args)
        {

            bool isvalidNo = false;
            bool isLoopNotToCont = false;
            string inputNo = string.Empty;
            string inputAns = string.Empty;

            while (!isLoopNotToCont)
            {
                Console.Write("Input Number: ");
                inputNo = Console.ReadLine();

                // Make sure it's a valid number and should only process a whole number  
                isvalidNo = inputNo.IsNumeric() && 
                            !inputNo.Contains(".");

                if (!isvalidNo)
                {
                    string msg = inputNo.Contains(".") ? "You should enter a whole number. " : "Invalid number. ";
                    Console.WriteLine(msg + "Please try again!");
                 }
                else
                {
                    try
                    { 
                        long n = Convert.ToInt64(inputNo);
                        Console.WriteLine("Output in Words: {0}", AppConversion.ConvertFromNoToWords(n));
                        Console.Write("Press 'Y' to exit or any key to continue converting another numnber to words...");
                        inputAns = Console.ReadLine();
                        if (inputAns.ToUpper() == "Y")
                            isLoopNotToCont = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.Message + " Please enter a number that is not too large to convert!");
                    }
                }
            }
        }
    }
}

