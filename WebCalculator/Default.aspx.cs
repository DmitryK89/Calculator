using CalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxInput.Text = "";
            TextBoxResult.Text = "";
        }

        protected void ButtonCalc_Click(object sender, EventArgs e)
        {
            TextBoxResult.Text = "";

            string math_sequence = GetMathSequence();

            ParsedData parsedData = Parser.ConvertStringToData(math_sequence);

            CalcResult calcResult = Calculator.Calculate(parsedData);

            PublicResult(calcResult);
        }

        private string GetMathSequence()
        {
            string math_sequence = TextBoxInput.Text;
            if (math_sequence == "") math_sequence = null;
            return math_sequence;
        }

        private void PublicResult(CalcResult calcResult)
        {
            if (String.IsNullOrEmpty(calcResult.ErrorMessage))
            {
                TextBoxResult.Text = calcResult.Data.ToString();
            }
            else
            {
                TextBoxResult.Text = calcResult.ErrorMessage;
            }
        }
    }
}