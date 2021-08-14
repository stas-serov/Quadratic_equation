using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quadratic_equation
{
    public partial class Form1 : Form
    {
        private double a, b, c, d;
        private double[] result;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// button for calculating roots
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculation_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox_a.Text);
                b = Convert.ToDouble(textBox_b.Text);
                c = Convert.ToDouble(textBox_c.Text);
                if (radioButton1.Checked)
                {
                    d = b * b - 4 * a * c;
                    if (d > 0) result = new double [] { ((-b + Math.Sqrt(d)) / (2 * a)), ((-b - Math.Sqrt(d)) / (2 * a)) };
                    else if (d < 0) result = new double[] { Convert.ToDouble(null), Convert.ToDouble(null) };
                    else result = new double[] { -b / (2 * a), -b / (2 * a) };
                    if ((result[0] == Convert.ToDouble(null)) && (result[1] == Convert.ToDouble(null))) MessageBox.Show("No valid roots!", "Message");
                    else
                    {
                        textBox_x1.Text = result[0].ToString("G5");
                        textBox_x2.Text = result[1].ToString("G5");
                    }
                    
                }
                else if (radioButton2.Checked)
                {
                    result = calc(a, b, c);
                    if ((result[0] == Convert.ToDouble(null)) && (result[1] == Convert.ToDouble(null))) MessageBox.Show("No valid roots!", "Message");
                    else
                    {
                        textBox_x1.Text = result[0].ToString("G5");
                        textBox_x2.Text = result[1].ToString("G5");
                    }
                }
                else if (radioButton3.Checked)
                {
                    Calculation calc = new Calculation();
                    result = calc.calculation(a, b, c);
                    if ((result[0] == Convert.ToDouble(null)) && (result[1] == Convert.ToDouble(null))) MessageBox.Show("No valid roots!", "Message");
                    else
                    {
                        textBox_x1.Text = result[0].ToString("G5");
                        textBox_x2.Text = result[1].ToString("G5");
                    }
                }
                else MessageBox.Show("Choose a calculation method!", "Error!");
            }
            catch
            {
                MessageBox.Show("Enter the correct data!", "Error!");
            }
        }
        /// <summary>
        /// method for editing field "a"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) ||
               (e.KeyChar == (char)Keys.Delete) || (e.KeyChar == ',') || (e.KeyChar == '-')) & (e.KeyChar != '.'))
            {           
                string s = textBox_a.Text;
                if (e.KeyChar == ',')
                {
                    int i = s.IndexOf(",", 0, s.Length);
                    if (i != (-1) || s == "-") { e.KeyChar = (char)Keys.None; }
                }
                if (e.KeyChar == '-')
                {
                    int i = s.Length;
                    if (i > 0) e.KeyChar = (char)Keys.None;
                }
                if (e.KeyChar == '0')
                {
                    if (textBox_a.Text == "0")
                    {
                        e.KeyChar = (char)Keys.None;
                    }
                }
            }
            else e.KeyChar = (char)Keys.None;

        }
        /// <summary>
        /// method for editing field "b"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_b_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) ||
               (e.KeyChar == (char)Keys.Delete) || (e.KeyChar == ',') || (e.KeyChar == '-')) & (e.KeyChar != '.'))
            {
                string s = textBox_b.Text;
                if (e.KeyChar == ',')
                {
                    int i = s.IndexOf(",", 0, s.Length);
                    if (i != (-1) || s == "-") { e.KeyChar = (char)Keys.None; }
                }
                if (e.KeyChar == '-')
                {
                    int i = s.Length;
                    if (i > 0) e.KeyChar = (char)Keys.None;
                }
                if (e.KeyChar == '0')
                {
                    if (textBox_b.Text == "0")
                    {
                        e.KeyChar = (char)Keys.None;
                    }
                }
            }
            else e.KeyChar = (char)Keys.None;
        }
        /// <summary>
        /// method for editing field "c"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_c_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) ||
               (e.KeyChar == (char)Keys.Delete) || (e.KeyChar == ',') || (e.KeyChar == '-')) & (e.KeyChar != '.'))
            {
                string s = textBox_c.Text;
                if (e.KeyChar == ',')
                {
                    int i = s.IndexOf(",", 0, s.Length);
                    if (i != (-1) || s == "-") { e.KeyChar = (char)Keys.None; }
                }
                if (e.KeyChar == '-')
                {
                    int i = s.Length;
                    if (i > 0) e.KeyChar = (char)Keys.None;
                }
                if (e.KeyChar == '0')
                {
                    if (textBox_c.Text == "0")
                    {
                        e.KeyChar = (char)Keys.None;
                    }
                }
            }
            else e.KeyChar = (char)Keys.None;
        }
        /// <summary>
        /// button for new equation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void new_Click(object sender, EventArgs e)
        {
            textBox_a.Clear();
            textBox_b.Clear();
            textBox_c.Clear();
            textBox_x1.Clear();
            textBox_x2.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }
        /// <summary>
        /// separate method for calculating roots
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public double[] calc (double a, double b, double c)
        {
            d = b * b - 4 * a * c;
            if (d > 0) return new double[] { ((-b + Math.Sqrt(d)) / (2 * a)), ((-b - Math.Sqrt(d)) / (2 * a)) };
            else if (d < 0) return new double[] { Convert.ToDouble(null), Convert.ToDouble(null) };
            else return new double[] { -b / (2 * a), -b / (2 * a) };
        }
    }
}
