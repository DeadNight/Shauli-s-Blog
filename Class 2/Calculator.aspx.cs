using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Calculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DigitButton_Click(object sender, EventArgs e)
    {
        if (DisplayTextBox.Text == "0")
            DisplayTextBox.Text = ((Button)sender).Text;
        else
            DisplayTextBox.Text += ((Button)sender).Text;
    }

    protected void OperatorButton_Click(object sender, EventArgs e)
    {
        long subtotal = int.Parse(SubtotalTextBox.Text);
        switch (LastOperatorHiddenField.Value)
        {
            case "+":
                subtotal += int.Parse(DisplayTextBox.Text);
                break;
            case "-":
                subtotal -= int.Parse(DisplayTextBox.Text);
                break;
            default:
                throw new NotImplementedException("Unsupported operator");
        }
        SubtotalTextBox.Text = subtotal.ToString();
        LastOperatorHiddenField.Value = ((Button)sender).Text;
        DisplayTextBox.Text = "0";
    }

    protected void Calc_Click(object sender, EventArgs e)
    {
        
    }
}