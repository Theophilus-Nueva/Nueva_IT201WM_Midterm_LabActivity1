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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label29.Text = GlobalData.EmployeeID;
            label30.Text = $"{GlobalData.Firstname} {GlobalData.Middlename} {GlobalData.Surname}";
            label33.Text = GlobalData.Department;
            paydate1.Text = GlobalData.Paydate;
            paydate2.Text = GlobalData.Paydate;

            label35.Text = GlobalData.BasicIncome;
            label36.Text = GlobalData.HonorariumIncome;
            label37.Text = GlobalData.OtherIncome;

            earnings.Text = GlobalData.GrossIncome;
            deductions.Text = GlobalData.Deductions;


            label18.Text = GlobalData.NetIncome;
            label19.Text = GlobalData.SSS;
            label26.Text = GlobalData.PhilHealth;

        }
    }
}
