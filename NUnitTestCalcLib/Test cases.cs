using NUnit.Framework;
using System;
using System.Collections.Generic;
using CalcLib;

namespace NUnitTestCalculator
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test_two_elements_add()
        {
            var input = "1+2";

            ParsedData parsedData  = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(3, "");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_four_elements_add()
        {
            var input = "1+2+3+4";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(10, "");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_decimal_division()
        {
            var input = "1.2+2,4+3/4";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(4.35, "");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_multiplication()
        {
            var input = "1+2+3*3+5*6";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(42, "");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_parentheses()
        {
            var input = "1+2*(3+4/(1+1))+5*(6*7-36)";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(41, "");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_errors_double_conversion()
        {
            var input = "1+2.1.1";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(Single.NaN, ErrorMessages.double_conversion);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_errors_parentheses()
        {
            var input = "1+3*(2+5";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(Single.NaN, ErrorMessages.parentheses);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_errors_math_operator_missed()
        {
            var input = "1+3(2+5)";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(Single.NaN, ErrorMessages.mathOp_missed);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_errors_math_operator_extra()
        {
            var input = "1+/5";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(Single.NaN, ErrorMessages.mathOp_extra);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_errors_math_operators_absent()
        {
            var input = "123";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(Single.NaN, ErrorMessages.mathOp_absent);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_errors_division_to_zero()
        {
            var input = "1/0";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(Single.NaN, ErrorMessages.division_to_zero);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_empty_string()
        {
            var input = "";

            ParsedData parsedData = Parser.ConvertStringToData(input);

            CalcResult actual = Calculator.Calculate(parsedData);

            CalcResult expected = new CalcResult(Single.NaN, ErrorMessages.empty_input);

            Assert.AreEqual(expected, actual);
        }

    }
}