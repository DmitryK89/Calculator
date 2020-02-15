using System;
using System.Collections.Generic;
using System.Text;

namespace CalcLib
{
    public struct ParsedData
    {
        public List<double> Digits_double { get; set; }
        public List<MathOperator> MathOpSequence { get; set; }
        public string ErrorMessage { get; set; }
        public ParsedData(List<double> digits_double, List<MathOperator> mathOperationsSequence, string errorMessage)
        {
            this.Digits_double = digits_double;
            this.MathOpSequence = mathOperationsSequence;
            this.ErrorMessage = errorMessage;
        }
    }
}
