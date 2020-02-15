using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CalcLib
{
    static class SendResult
    {
        public static void PublicResult (CalcResult result)
        {
            if (String.IsNullOrEmpty(result.ErrorMessage))
            {
                Console.WriteLine("Результат:" + result.Data.ToString("0.00", CultureInfo.CurrentUICulture));
            }
            else
            {
                Console.WriteLine("Результат: " + result.ErrorMessage);
            }
        }
    }
}
