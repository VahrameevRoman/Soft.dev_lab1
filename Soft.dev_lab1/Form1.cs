using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soft.dev_lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (CheckForPositiveNumber(textBoxA.Text) == false)
            {
                check = false;
            }
            else if (CheckForPositiveNumber(textBoxB.Text) == false)
            {
                check = false;
            }
            else if (CheckForPositiveNumber(textBoxAlpha.Text) == false)
            {
                check = false;
            }
            else if (double.Parse(textBoxAlpha.Text) >= 180)
            {
                check = false;
            }
            if (!check)
            {
                labelS.Visible = false;
                textBoxS.Visible = false;
                MessageBox.Show(
                "Введите корректные значения переменных.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            else Calculation();
        }

        private bool CheckForPositiveNumber(string str)
        {
            double number;
            if (double.TryParse(str, out number) && (number > 0)) return true;
            return false;
        }

        private void Calculation()
        {
            double a = double.Parse(textBoxA.Text);
            double b = double.Parse(textBoxB.Text);
            double alpha = double.Parse(textBoxAlpha.Text);
            double result = Math.Round(a * b * Math.Sin(alpha/57.2958), 5);
            if (result > 0)
            {
                labelS.Visible = true;
                textBoxS.Visible = true;
                textBoxS.Text = Convert.ToString(result);
            }
            else
            {
                labelS.Visible = false;
                textBoxS.Visible = false;
                MessageBox.Show(
                "Параллелограмма с введёнными переменными не может существовать.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Выйти из программы?",
            "Внимание",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
