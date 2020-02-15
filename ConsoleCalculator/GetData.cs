using System;
using System.Collections.Generic;
using System.Text;

namespace CalcLib
{
    static class GetData
    {
        public static string GetMathSequence()
        {
            string math_sequence = null;

            Console.Write("Введите выражение:");

            math_sequence = Console.ReadLine();
            if (math_sequence == "") math_sequence = null;
            return math_sequence;
        }
    }
}
