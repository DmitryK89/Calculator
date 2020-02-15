using System;

namespace CalcLib
{    

    class Program
    {
        static void Main()
        {      
            while (true)
            {
                string math_sequence = GetData.GetMathSequence();

                ParsedData parsedData = Parser.ConvertStringToData(math_sequence);

                CalcResult calcResult = Calculator.Calculate(parsedData);

                SendResult.PublicResult(calcResult);
            }
        }
    }
}
