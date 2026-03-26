using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_IT201WM_Midterm_LabActivity1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void grossIncome_btn_Click(object sender, EventArgs e)
        {
            double totaGrossIncome = 0;

            foreach (GroupBox groupBox in this.Controls.OfType<GroupBox>())
            {
                TextBox[] textbox = groupBox.Controls.OfType<TextBox>().ToArray();

                double rate_per_hour = 0;
                double num_of_hours_cutoff = 0;

                double.TryParse(textbox[0].Text, out rate_per_hour);
                double.TryParse(textbox[1].Text, out num_of_hours_cutoff);


                textbox[2].Text = $"{rate_per_hour * num_of_hours_cutoff}";
                totaGrossIncome += rate_per_hour * num_of_hours_cutoff;
            }

            grossIncome_text.Text = totaGrossIncome.ToString();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            foreach (TextBox textbox in this.Controls.OfType<TextBox>())
            {
                textbox.Clear();
            }

            foreach (GroupBox groupBox in this.Controls.OfType<GroupBox>())
            {
                foreach (TextBox textbox in groupBox.Controls.OfType<TextBox>())
                {
                    textbox.Clear();
                }
            }

            pictureBox1.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        public double CalculateSSSContribution(double income)
        {
            if (income < 5250)
            {
                return 760;
            }
            else if (income >= 9750 && income < 10250)
            {
                return 1520;
            }
            else if (income >= 14750 && income < 15250)
            {
                return 2280;
            }
            else if (income >= 19750 && income < 20250)
            {
                return 3030;
            }
            else if (income >= 24750 && income < 25250)
            {
                return 3780;
            }
            else if (income >= 29750 && income < 30250)
            {
                return 4530;
            }
            else if (income >= 34750)
            {
                return 5280;
            }
            else
            {
                return 0;
            }
        }

        public double CalculateTaxContribution(double income)
        {
            if (income <= 250000)
            {
                return 0;
            }
            else if (income > 250000 && income <= 400000)
            {
                return (income - 250000) * 0.15;
            }
            else if (income > 400000 && income <= 800000)
            {
                return 22500 + ((income - 400000) * 0.20);
            }
            else if (income > 800000 && income <= 2000000)
            {
                return 102500 + ((income - 800000) * 0.25);
            }
            else if (income > 2000000 && income <= 8000000)
            {
                return 402500 + ((income - 2000000) * 0.30);
            }
            else
            {
                return 2202500 + ((income - 8000000) * 0.35);
            }
        }

        public double CalculatePhilHealthContribution(double income)
        {
            if (income <= 10000)
            {
                return 500;
            }
            else if (income >= 100000)
            {
                return 5000;
            }
            else
            {
                return income * 0.05;
            }
        }

        private void netIncome_btn_Click(object sender, EventArgs e)
        {
            double.TryParse(grossIncome_text.Text, out double grossIncome);

            SSSContribution_text.Text = $"{CalculateSSSContribution(grossIncome)}";
            IncomeTaxContribution_text.Text = $"{CalculateTaxContribution(grossIncome)}";
            PagibigContribution_text.Text = $"{grossIncome * 0.02}";
            PhilhealthContribution_text.Text = $"{CalculatePhilHealthContribution(grossIncome)}";
        }
    }
}
    