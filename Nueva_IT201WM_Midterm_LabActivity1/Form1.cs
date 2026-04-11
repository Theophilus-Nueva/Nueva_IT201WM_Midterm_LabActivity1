using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

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
                return 250;
            }

            if (income >= 34750)
            {
                return 1750;
            }

            double msc = Math.Round(income / 500.0) * 500.0;
            return msc * 0.05;
        }

        public double CalculatePhilHealthContribution(double income)
        {
            if (income <= 10000)
            {
                return 250;
            }
            else if (income >= 100000)
            {
                return 2500;
            }
            else
            {
                return (income * 0.05) / 2.0;
            }
        }

        public double CalculatePagIbigContribution(double income)
        {
            if (income <= 1500)
            {
                return income * 0.01;
            }

            double contribution = income * 0.02;
            return contribution > 200 ? 200 : contribution;
        }

        public double CalculateTaxContribution(double taxableIncome)
        {
            if (taxableIncome <= 20833)
            {
                return 0;
            }
            else if (taxableIncome <= 33333)
            {
                return (taxableIncome - 20833) * 0.15;
            }
            else if (taxableIncome <= 66667)
            {
                return 1875 + ((taxableIncome - 33333) * 0.20);
            }
            else if (taxableIncome <= 166667)
            {
                return 8541.67 + ((taxableIncome - 66667) * 0.25);
            }
            else if (taxableIncome <= 666667)
            {
                return 33541.67 + ((taxableIncome - 166667) * 0.30);
            }
            else
            {
                return 183541.67 + ((taxableIncome - 666667) * 0.35);
            }
        }

        private void netIncome_btn_Click(object sender, EventArgs e)
        {
            double totalOtherDeductions = 0;
            foreach (TextBox textbox in otherdeductionsGroup.Controls.OfType<TextBox>())
            {
                double.TryParse(textbox.Text, out double value);
                totalOtherDeductions += value;
            }

            double.TryParse(grossIncome_text.Text, out double grossIncome);

            double sss = CalculateSSSContribution(grossIncome);
            double philhealth = CalculatePhilHealthContribution(grossIncome);
            double pagibig = CalculatePagIbigContribution(grossIncome);

            double taxableIncome = grossIncome - (sss + philhealth + pagibig + totalOtherDeductions);

            double tax = CalculateTaxContribution(taxableIncome);

            SSSContribution_text.Text = $"{sss}";
            PhilhealthContribution_text.Text = $"{philhealth}";
            PagibigContribution_text.Text = $"{pagibig}";
            IncomeTaxContribution_text.Text = $"{tax}";

            totalDeduction_text.Text = $"{sss + philhealth + pagibig + tax + totalOtherDeductions}";
            summaryIncome_text.Text = $"{grossIncome - (sss + philhealth + pagibig + tax + totalOtherDeductions)}";
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            GlobalData.EmployeeID = employeeId.Text;
            GlobalData.Firstname = firstname.Text;
            GlobalData.Middlename = middlename.Text;
            GlobalData.Surname = surname.Text;
            GlobalData.Paydate = paydate.Text;
            GlobalData.Department = departnemtName.Text;

            GlobalData.BasicIncome = basicIncome_text.Text;
            GlobalData.HonorariumIncome = honorariumIncome_text.Text;
            GlobalData.OtherIncome = otherIncome_text.Text;
            GlobalData.GrossIncome = grossIncome_text.Text;

            GlobalData.Tax = IncomeTaxContribution_text.Text;
            GlobalData.SSS = SSSContribution_text.Text;
            GlobalData.PagIbig = PagibigContribution_text.Text;
            GlobalData.PhilHealth = PhilhealthContribution_text.Text;

            GlobalData.Deductions = totalDeduction_text.Text;
            GlobalData.NetIncome = summaryIncome_text.Text;

            Form2 form2 = new Form2();
            form2.ShowDialog();

            label28.Text = employeeId.Text;
        }
    }

    public static class GlobalData
    {
        public static string EmployeeID { get; set; }
        public static string Firstname { get; set; }
        public static string Middlename { get; set; }
        public static string Surname { get; set; }
        public static string Department { get; set; }
        public static string Paydate { get; set; }


        public static string BasicIncome { get; set; }
        public static string HonorariumIncome { get; set; }
        public static string OtherIncome { get; set; }
        public static string GrossIncome { get; set; }
        public static string Deductions { get; set; }



        public static string Tax { get; set; }
        public static string SSS { get; set; }
        public static string PagIbig { get; set; }
        public static string PhilHealth { get; set; }

        public static string NetIncome { get; set; }
    }
}
    