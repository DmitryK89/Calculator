using System;
using System.Collections.Generic;
using System.Text;

namespace CalcLib
{
    public static class Calculator
    {
        public static CalcResult Calculate(ParsedData parsedData)
        {
            CalcResult output = new CalcResult(Single.NaN, "");
            output.ErrorMessage += parsedData.ErrorMessage;

            if (string.IsNullOrEmpty(parsedData.ErrorMessage))
            {
                while (parsedData.MathOpSequence.Count != 0) //Execute each mathematical operation in order of priority
                {
                    int max_parentheses_level = 0;
                    int max_operators_priority = 0;

                    /*Define Math operation which executed first, highest parentheses level and highest priority at current level*/
                    for (int i = 0; i < parsedData.MathOpSequence.Count; i++)
                    {
                        if (parsedData.MathOpSequence[i].Parentheses_level > max_parentheses_level) max_parentheses_level = parsedData.MathOpSequence[i].Parentheses_level;
                    }
                    for (int i = 0; i < parsedData.MathOpSequence.Count; i++)
                    {
                        if (parsedData.MathOpSequence[i].Parentheses_level == max_parentheses_level && parsedData.MathOpSequence[i].Priority > max_operators_priority)
                            max_operators_priority = parsedData.MathOpSequence[i].Priority;
                    }

                    /*Execute Math operation*/
                    for (int i = 0; i < parsedData.MathOpSequence.Count; i++)
                    {
                        if (parsedData.MathOpSequence[i].Parentheses_level == max_parentheses_level && parsedData.MathOpSequence[i].Priority == max_operators_priority)
                        {
                            if (parsedData.MathOpSequence[i].Symvol=='/' && parsedData.Digits_double[i + 1]==0) //Check division to 0
                            {
                                output.ErrorMessage += ErrorMessages.division_to_zero;
                                break;
                            }
                            else parsedData.Digits_double[i] = parsedData.MathOpSequence[i].Execution(parsedData.Digits_double[i], parsedData.Digits_double[i + 1]);
                            output.Data = parsedData.Digits_double[i];
                            parsedData.Digits_double.RemoveAt(i + 1);
                            parsedData.MathOpSequence.RemoveAt(i);
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(output.ErrorMessage)) break;
                }
            }


            return output;
        }
    
    }
}
