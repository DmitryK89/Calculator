using System;
using System.Collections.Generic;
using System.Text;

namespace CalcLib
{
    public struct CalcResult
    {
        public CalcResult(double data, string errorMessage)
        {
            this.Data = data;
            this.ErrorMessage = errorMessage;
        }

        public double Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
