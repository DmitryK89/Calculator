using System;
using System.Collections.Generic;
using System.Text;

namespace CalcLib
{
    public struct MathOperator
    {
        public char Symvol { get; private set; }
        public int Priority { get; private set; }
        public Func<double, double, double> Execution { get; private set; }
        public int Parentheses_level { get; set; }
        public MathOperator(char symvol, int priority, int parentheses_level, Func<double, double, double> execution)
        {
            this.Symvol = symvol;
            this.Priority = priority;
            this.Parentheses_level = parentheses_level;
            this.Execution = execution;
        }
    }
}
