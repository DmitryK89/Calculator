using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CalcLib
{
    public static class Parser
    {
        readonly static char[] splitters = { '+', '-', '*', '/', ' ', '(', ')' };

        readonly static MathOperator[] mathOperators = new MathOperator[]
        { 
          new MathOperator('+', 0, 0, (a, b) => a + b),
          new MathOperator('-', 0, 0, (a, b) => a - b),
          new MathOperator('*', 1, 0, (a, b) => a * b),
          new MathOperator('/', 1, 0, (a, b) => a / b)
        };

        public static ParsedData ConvertStringToData (string input_string)
        {
            string errorMessage = "";
            List<MathOperator> mathOperationsSequence = new List<MathOperator>();
            List<double> digits_double = new List<double>();

            if(string.IsNullOrEmpty(input_string)) errorMessage += ErrorMessages.empty_input;

            /*Create array of digits from the string*/
            if (string.IsNullOrEmpty(errorMessage))
            {
                string[] numbers_string = input_string.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < numbers_string.Length; i++)
                {
                    try
                    {
                        if (numbers_string[i].Contains(','))
                            digits_double.Add(Convert.ToDouble(numbers_string[i], CultureInfo.GetCultureInfo("ru-Ru")));
                        else
                            digits_double.Add(Convert.ToDouble(numbers_string[i], CultureInfo.InvariantCulture));
                    }
                    catch
                    {
                        if (!errorMessage.Contains(ErrorMessages.double_conversion))
                            errorMessage += ErrorMessages.double_conversion;
                    }
                }

                if(digits_double.Count==0) errorMessage = ErrorMessages.digits_empty;
            }

            /*Create array of Math operators*/
            if (errorMessage == "")
            { 
                int parentheses_Level = 0;
                foreach (var letter in input_string)
                {
                    if (letter == '(') parentheses_Level++;
                    if (letter == ')') parentheses_Level--;

                    foreach (var mathOperator in mathOperators)
                    {
                        if (letter == mathOperator.Symvol)
                            mathOperationsSequence.Add(new MathOperator(mathOperator.Symvol, mathOperator.Priority, parentheses_Level, mathOperator.Execution));
                    }
                }

                if (mathOperationsSequence.Count == 0) errorMessage += ErrorMessages.mathOp_absent;
                if (parentheses_Level!=0) errorMessage += ErrorMessages.parentheses;
                if (digits_double.Count > mathOperationsSequence.Count + 1) errorMessage += ErrorMessages.mathOp_missed;
                if (digits_double.Count < mathOperationsSequence.Count + 1) errorMessage += ErrorMessages.mathOp_extra;
            }

            return new ParsedData(digits_double, mathOperationsSequence, errorMessage);

        }
    }
}