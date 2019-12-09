using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Calculator
{
    public partial class frmMain : Form
    {
        Label CurrentOperator;
        TextBox result;
        double ResultVal = 0;
        string operator_icon = "";
        bool isOperationPerformed = false;
        bool isDigitalPressed = false;

        public frmMain()
        {
            Init();  
        }
        public void Init()
        {
            InitializeComponent();
            this.Name = "AppCalculator";
            this.Text = "Calculator";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(350, 450);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            result = new TextBox();
            result.Location = new Point(47, 50);
            result.Size = new Size(220, 22);
            result.Text = "0";
            result.AcceptsReturn = false;
            result.TextAlign = HorizontalAlignment.Right;

            CurrentOperator = new Label();
            CurrentOperator.Location = new Point(47, 20);
            CurrentOperator.Text = "";
            CurrentOperator.Size = new Size(100, 22);
            

            this.Controls.Add(CurrentOperator);
            this.Controls.Add(result);
        }

        private void digital_click(object sender, EventArgs e)
        {
            isDigitalPressed = true;
            if ((result.Text == "0") || (isOperationPerformed == true))
            {
                result.Clear();
            }

            if(double.IsNaN(ResultVal) == true)
            {
                result.Text = "0";
                ResultVal = 0;
                result.Clear();
            }

            isOperationPerformed = false;
            Button btt = (Button)sender;
            if(btt.Text == ".")
            {
                if (!(result.Text.Contains(".")))
                    result.Text += btt.Text;
            }
            else
            {
                result.Text += btt.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button btt = (Button) sender;
            if(ResultVal != 0)
            {
                Equal.PerformClick();
                operator_icon = btt.Text;
                CurrentOperator.Text = ResultVal + " " + operator_icon;
                isOperationPerformed = true;
            }
            else
            {
                operator_icon = btt.Text;
                ResultVal = double.Parse(result.Text);
                CurrentOperator.Text = ResultVal + " " + operator_icon;
                isOperationPerformed = true;
            }
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            ResultVal = 0;
            result.Text = "0";
            CurrentOperator.Text = "";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            switch (operator_icon)
            {
                case "+":
                    {
                        result.Text = (ResultVal + double.Parse(result.Text)).ToString();
                        break;
                    }
                case "-":
                    {
                        result.Text = (ResultVal - double.Parse(result.Text)).ToString();
                        break;
                    }
                case "X":
                    {
                        result.Text = (ResultVal * double.Parse(result.Text)).ToString();
                        break;
                    }
                case "/":
                    {
                        try
                        {
                            if (result.Text == "0")
                            {
                                ResultVal /= 0;
                            }
                            result.Text = ((ResultVal) / double.Parse(result.Text)).ToString();
                        }
                        catch
                        {
                            //Insert code here
                        }
                        result.Text = ((ResultVal) / double.Parse(result.Text)).ToString();
                        break;
                    }
                default:
                    break;
            }
            ResultVal = double.Parse(result.Text);
            CurrentOperator.Text = "";
            isDigitalPressed = false;

            if(isDigitalPressed == true)
            {
                ClearAll.PerformClick();
            }
        }
    }
}