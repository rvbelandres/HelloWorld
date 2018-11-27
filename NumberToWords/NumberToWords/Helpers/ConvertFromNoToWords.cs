using System;

namespace NumberToWords.Helpers
{
    public static class AppConversion
    {
        public static String ConvertFromNoToWords(double n)
        {
            string[] lvloneNumName = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] lvltwoNumName = new string[] { "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] lvlthreeNumName = new string[] { "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion" };

            string numToWords = "";

            bool tens = false;

            if (n < 0)
            {
                numToWords += "Minus ";
                n *= -1;
            }

            int numPower = (lvlthreeNumName.Length + 1) * 3;

            while (numPower > 3)
            {
                double numPow= Math.Pow(10, numPower);
                if (n >= numPow)
                {
                    if (n % numPow > 0)
                    {
                        numToWords += ConvertFromNoToWords(Math.Floor(n / numPow)) + " " + lvlthreeNumName[(numPower / 3) - 1] + " "; 
                    }
                    else if (n % numPow == 0)
                    {
                        numToWords += ConvertFromNoToWords(Math.Floor(n / numPow)) + " " + lvlthreeNumName[(numPower / 3) - 1];
                    }
                    n %= numPow;
                }
                numPower -= 3;
            }
            if (n >= 1000)
            {
                if (n % 1000 > 0) numToWords += ConvertFromNoToWords(Math.Floor(n / 1000)) + " Thousand ";
                else numToWords += ConvertFromNoToWords(Math.Floor(n / 1000)) + " Thousand";
                n %= 1000;
            }
            if (0 <= n && n <= 999)
            {
                if ((int)n / 100 > 0)
                {
                    numToWords += ConvertFromNoToWords(Math.Floor(n / 100)) + " Hundred";
                    n %= 100;
                }
                if ((int)n / 10 > 1)
                {
                    if (numToWords != "")
                        numToWords += " ";
                    numToWords += lvltwoNumName[(int)n / 10 - 2];
                    tens = true;
                    n %= 10;
                }

                if (n < 20 && n > 0)
                {
                    if (numToWords != "" && tens == false)
                        numToWords += " ";
                    numToWords += (tens ? " " + lvloneNumName[(int)n - 1] : lvloneNumName[(int)n - 1]);
                    n -= Math.Floor(n);
                }
            }
            return numToWords;
        }
    }
}
