using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    class Calc
    {
        public string operators;
        public double? value1;
        public double? value2;
        public double? member_value2;
        public double? member;

        public Calc()
        {
            member = null;
            operators = null;
            value1 = null;
            value2 = null;
            member_value2 = null;
        }

        private double? Addition()
        {
            return (value1 + value2);
        }
        private double? Subtraction()
        {
            return (value1 - value2);
        }
        private double? Multiplication()
        {
            return (value1 * value2);
        }
        private double? Division()
        {
            return (value1 / value2);
        }
        public double? Proz()
        {
            if (value1 != null && value2 != null)
                return (value1 * value2 / 100);
            return null;
        }
        public double? Operetion()
        {
            if (operators == "+")
            {
                if (value1 != null && value2 != null)
                {
                    return Addition();
                }
            }
            else if (operators == "-")
            {
                if (value1 != null && value2 != null)
                {
                    return Subtraction();
                }
            }
            else if (operators == "*")
            {
                if (value1 != null && value2 != null)
                {
                    return Multiplication();
                }
            }
            else if (operators == "/")
            {
                if (value1 != null && value2 != null)
                {
                    return Division();
                }
            }

            return null;
        }
    }
    

        Calc calc = new Calc();
        string strings;
        string sqrt;
        string temp_strings;
        string lable;

        public Form1()
        {
            InitializeComponent();
            sqrt = "";
            label1.Text = "0";
            this.KeyPreview = true;
            lable = "";
            label2.Text = strings = "";

        }
        public void Texts(string s)
        {
            if (lable == temp_strings && strings != "" && label2.Text == "")
            {
                lable = "" + s;
                label2.Text = strings;
            }
            else if (lable == "0")
                lable = "" + s;
            else
            {
                lable += "" + s;
                strings = "";
            }


            label1.Text = lable;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MC_Click(object sender, EventArgs e)
        {
            calc.member = null;
        }

        private void MR_Click(object sender, EventArgs e)
        {
            if (calc.member != null)
                label1.Text = lable = calc.member.ToString();
        }

        private void MS_Click(object sender, EventArgs e)
        {
            calc.member = Double.Parse(label1.Text);
            calc.member = calc.member == 0 ? null : calc.member;
        }

        private void MPlus_Click(object sender, EventArgs e)
        {
            if (calc.member != null)
            {
                calc.member += Double.Parse(label1.Text);
                calc.member = calc.member == 0 ? null : calc.member;
            }
        }

        private void MMin_Click(object sender, EventArgs e)
        {
            if (calc.member != null)
            {
                calc.member -= Double.Parse(label1.Text);
                calc.member = calc.member == 0 ? null : calc.member;
            }
        }

        private void Backspase_Click(object sender, EventArgs e)
        {
            if (lable != "" && Double.Parse(lable) > 0 && lable != "0")
            {
                if (lable.Length > 1)
                    lable = lable.Substring(0, lable.Length - 1);
                else
                    lable = "0";


                label1.Text = lable;
            }

        }

        private void CleanElement_Click(object sender, EventArgs e)
        {
            calc.value2 = null;
            lable = "0";
            label1.Text = "0";
            if (label2.Text == "0")
                label2.Text = "";
            sqrt = "";

        }

        private void CleanAll_Click(object sender, EventArgs e)
        {
            calc.value2 = null;
            calc.value1 = null;

            temp_strings = "";
            strings = "";
            lable = "0";

            label1.Text = "0";
            label2.Text = "";
            sqrt = "";
            calc.operators = "";
            calc.member_value2 = null;
        }

        private void Plus_Click(object sender, EventArgs e)
        {


            if (lable != "")
            {

                if (Double.Parse(lable) != calc.value1 && calc.value2 == null && lable == "0")
                {
                    if (lable == "0")
                        lable = label1.Text;

                    label2.Text = lable + " + ";
                    calc.operators = "+";
                    lable = "";
                }
                else if (calc.value1 == null)
                {
                    if (lable == "0")
                        lable = label1.Text;

                    calc.value1 = Double.Parse(lable);
                    label2.Text = lable + " + ";
                    calc.operators = "+";
                    lable = "";
                }
                else if (calc.value2 == null)
                {
                    calc.value2 = Double.Parse(lable);

                    calc.value1 = calc.Operetion() != null ? calc.Operetion() : calc.value1;

                    calc.operators = "+";

                    if (strings == "")
                        label2.Text += lable + " + ";
                    else
                        label2.Text += " + ";

                    label1.Text = calc.value1.ToString();
                    calc.value2 = null;
                    lable = "0";
                    strings = "";
                }
            }

        }


        private void Min_Click(object sender, EventArgs e)
        {

            if (lable != "")
            {

                if (Double.Parse(lable) != calc.value1 && calc.value2 == null && lable == "0")
                {
                    if (lable == "0")
                        lable = label1.Text;

                    label2.Text = lable + " - ";
                    calc.operators = "-";
                    lable = "";
                }
                else if (calc.value1 == null)
                {
                    if (lable == "0")
                        lable = label1.Text;

                    calc.value1 = Double.Parse(lable);
                    label2.Text = lable + " - ";
                    calc.operators = "-";
                    lable = "";
                }
                else if (calc.value2 == null)
                {
                    calc.value2 = Double.Parse(lable);

                    calc.value1 = calc.Operetion() != null ? calc.Operetion() : calc.value1;

                    calc.operators = "-";

                    if (strings == "")
                        label2.Text += lable + " - ";
                    else
                        label2.Text += " - ";

                    label1.Text = calc.value1.ToString();
                    calc.value2 = null;
                    lable = "0";
                    strings = "";
                }
            }

        }

        private void PlusForMin_Click(object sender, EventArgs e)
        {
            if (lable != "")
            {
                if (sqrt == "" && label1.Text != "0" && lable == "0")
                {
                    sqrt = lable = label1.Text;
                }
                else if (sqrt == "")
                {
                    sqrt = lable;
                }
                else
                    label2.Text = label2.Text.Replace(sqrt, "");


                label2.Text += sqrt = ("negate(" + sqrt + ")");
                calc.value2 = Double.Parse(lable) * (-1);
                lable = calc.value2.ToString();
                label1.Text = calc.value2.ToString();
                strings = label1.Text;

                calc.value2 = null;
            }
            else if (lable == "")
            {
                lable = label1.Text;

                if (sqrt == "" && label1.Text != "0" && lable == "0")
                {
                    sqrt = lable = label1.Text;
                }
                else if (sqrt == "")
                {
                    sqrt = lable;
                }
                else
                    label2.Text = label2.Text.Replace(sqrt, "");


                label2.Text += sqrt = ("negate(" + sqrt + ")");
                calc.value2 = Double.Parse(lable) * (-1);
                lable = calc.value2.ToString();
                label1.Text = calc.value2.ToString();
                strings = label1.Text;

                calc.value2 = null;
            }
        }

        private void Sqrt_Click(object sender, EventArgs e)
        {
            if (lable != "")
            {
                if (sqrt == "" && label1.Text != "0" && lable == "0")
                {
                    sqrt = lable = label1.Text;
                }
                else if (sqrt == "")
                {
                    sqrt = lable;
                }
                else
                    label2.Text = label2.Text.Replace(sqrt, "");


                label2.Text += sqrt = ("√(" + sqrt + ")");
                calc.value2 = Math.Sqrt(Double.Parse(lable));
                lable = calc.value2.ToString();
                label1.Text = calc.value2.ToString();
                strings = label1.Text;

                calc.value2 = null;
            }
            else if (lable == "")
            {
                lable = label1.Text;

                if (sqrt == "" && label1.Text != "0" && lable == "0")
                {
                    sqrt = lable = label1.Text;
                }
                else if (sqrt == "")
                {
                    sqrt = lable;
                }
                else
                    label2.Text = label2.Text.Replace(sqrt, "");


                label2.Text += sqrt = ("√(" + sqrt + ")");
                calc.value2 = Math.Sqrt(Double.Parse(lable));
                lable = calc.value2.ToString();
                label1.Text = calc.value2.ToString();
                strings = label1.Text;

                calc.value2 = null;
            }
        }
        private void Dell_Click(object sender, EventArgs e)
        {

            if (lable != "")
            {

                if (Double.Parse(lable) != calc.value1 && calc.value2 == null && lable == "0")
                {
                    if (lable == "0")
                        lable = label1.Text;

                    label2.Text = lable + " / ";
                    calc.operators = "/";
                    lable = "";
                }
                else if (calc.value1 == null)
                {
                    if (lable == "0")
                        lable = label1.Text;

                    calc.value1 = Double.Parse(lable);
                    label2.Text = lable + " / ";
                    calc.operators = "/";
                    lable = "";
                }
                else if (calc.value2 == null)
                {
                    calc.value2 = Double.Parse(lable);

                    calc.value1 = calc.Operetion() != null ? calc.Operetion() : calc.value1;

                    calc.operators = "/";

                    if (strings == "")
                        label2.Text += lable + " / ";
                    else
                        label2.Text += " / ";

                    label1.Text = calc.value1.ToString();
                    calc.value2 = null;
                    lable = "0";
                    strings = "";
                }
            }
        }

        private void Proz_Click(object sender, EventArgs e)
        {

            if (calc.value1 == null || calc.operators == null)
            {
                label1.Text = "0";
                label2.Text = "0";
                calc.value2 = null;
                calc.value1 = null;
                lable = "";
            }
            else if (calc.value2 == null)
            {
                if (strings == "")
                {
                    strings = label2.Text;
                }
                calc.value2 = Double.Parse(label1.Text);
                calc.value2 = calc.Proz() != null ? calc.Proz() : calc.value2;

                temp_strings = label1.Text = lable = calc.value2.ToString();



                label2.Text = strings + label1.Text;

                calc.value2 = null;

            }
        }

        private void B1_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            b.Focus();
            Texts(b.Text);

        }


        private void B3_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    Texts("0");
                    break;

                case Keys.NumPad1:
                    Texts("1");
                    break;

                case Keys.NumPad2:
                    Texts("2");
                    break;

                case Keys.NumPad3:
                    Texts("3");
                    break;

                case Keys.NumPad4:
                    Texts("4");
                    break;

                case Keys.NumPad5:
                    Texts("5");
                    break;

                case Keys.NumPad6:
                    Texts("6");
                    break;

                case Keys.NumPad7:
                    Texts("7");
                    break;

                case Keys.NumPad8:
                    Texts("8");
                    break;

                case Keys.NumPad9:
                    Texts("9");
                    break;

                case Keys.Divide:
                    Dell_Click(sender, e);
                    break;
                case Keys.Multiply:
                    Ymnoj_Click(sender, e);
                    break;
                case Keys.Subtract:
                    Min_Click(sender, e);
                    break;
                case Keys.Add:
                    Plus_Click(sender, e);
                    break;
                case Keys.Return:
                    RESULT_Click(sender, e);
                    break;
                case Keys.Decimal:
                    Zap_Click(sender, e);
                    break;
                case Keys.Delete:
                    CleanAll_Click(sender, e);
                    break;
                case Keys.Back:
                    CleanElement_Click(sender, e);
                    break;

            }

        }

        private void Ymnoj_Click(object sender, EventArgs e)
        {

            if (lable != "")
            {

                if (Double.Parse(lable) != calc.value1 && calc.value2 == null && lable == "0")
                {
                    if (lable == "0")
                        lable = label1.Text;

                    label2.Text = lable + " * ";
                    calc.operators = "*";
                    lable = "";
                }
                else if (calc.value1 == null)
                {
                    if (lable == "0")
                        lable = label1.Text;

                    calc.value1 = Double.Parse(lable);
                    label2.Text = lable + " * ";
                    calc.operators = "*";
                    lable = "";
                }
                else if (calc.value2 == null)
                {
                    calc.value2 = Double.Parse(lable);

                    calc.value1 = calc.Operetion() != null ? calc.Operetion() : calc.value1;

                    calc.operators = "*";

                    if (strings == "")
                        label2.Text += lable + " * ";
                    else
                        label2.Text += " * ";

                    label1.Text = calc.value1.ToString();
                    calc.value2 = null;
                    lable = "0";
                    strings = "";
                }
            }
        }

        private void OneDellX_Click(object sender, EventArgs e)
        {
            if (lable != "")
            {
                if (sqrt == "" && label1.Text != "0" && lable == "0")
                {
                    sqrt = lable = label1.Text;
                }
                else if (sqrt == "")
                {
                    sqrt = lable;
                }
                else
                    label2.Text = label2.Text.Replace(sqrt, "");


                label2.Text += sqrt = ("reciproc(" + sqrt + ")");
                calc.value2 = 1 / (Double.Parse(lable));
                lable = calc.value2.ToString();
                label1.Text = calc.value2.ToString();
                strings = label1.Text;

                calc.value2 = null;
            }
            else if (lable == "")
            {
                lable = label1.Text;

                if (sqrt == "" && label1.Text != "0" && lable == "0")
                {
                    sqrt = lable = label1.Text;
                }
                else if (sqrt == "")
                {
                    sqrt = lable;
                }
                else
                    label2.Text = label2.Text.Replace(sqrt, "");


                label2.Text += sqrt = ("reciproc(" + sqrt + ")");
                calc.value2 = 1 / (Double.Parse(lable));
                lable = calc.value2.ToString();
                label1.Text = calc.value2.ToString();
                strings = label1.Text;

                calc.value2 = null;
            }
        }



        private void RESULT_Click(object sender, EventArgs e)
        {
            if (calc.member_value2 != null && label2.Text == "")
            {
                calc.value2 = calc.member_value2;
                calc.value1 = Double.Parse(label1.Text);
                calc.value1 = calc.Operetion() != null ? calc.Operetion() : calc.value1;



                label2.Text = "";
                label1.Text = calc.value1.ToString();
                calc.value2 = null;
                calc.value1 = null;
                lable = "0";
                strings = "";
                sqrt = "";
            }
            else if (calc.value2 == null && calc.value1 != null)
            {

                calc.member_value2 = calc.value2 = Double.Parse(lable);
                calc.value1 = calc.Operetion() != null ? calc.Operetion() : calc.value1;



                label2.Text = "";
                label1.Text = calc.value1.ToString();
                calc.value2 = null;
                //calc.value1 = null;
                lable = "0";
                strings = "";
                sqrt = "";
            }
        }



        private void Zap_Click(object sender, EventArgs e)
        {
            if (!label1.Text.ToString().Contains("."))
            {
                label1.Text += ",";
                lable += ",";
            }
        }


    
}
