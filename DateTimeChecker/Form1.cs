using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimeChecker
{
    public partial class Form1 : Form
    {
        readonly DateCheck dateCheck;
        public Form1()
        {
            InitializeComponent();
            dateCheck = new DateCheck();
        }

        public void ClearBtn_Click(object sender, EventArgs e)
        {
            dayTextBox.Clear();
            monthTextBox.Clear();
            yearTextBox.Clear();
        }

        public void CheckBtn_Click(object sender, EventArgs e)
        {
            if (!byte.TryParse(dayTextBox.Text, out _))
            {
                MessageBox.Show("Input data for Day is incorrect format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!byte.TryParse(monthTextBox.Text, out _))
            {
                MessageBox.Show("Input data for Month is incorrect format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!short.TryParse(yearTextBox.Text, out _))
            {
                MessageBox.Show("Input data for Year is incorrect format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sbyte day = sbyte.Parse(dayTextBox.Text);
                sbyte month = sbyte.Parse(monthTextBox.Text);
                short year = short.Parse(yearTextBox.Text);

                string inputDate = $"{day:D2}/{month:D2}/{year:D4}";

                if (!dateCheck.IsDayInRange(day))
                {
                    MessageBox.Show("Input data for Day is out of range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!dateCheck.IsMonthInRange(month))
                {
                    MessageBox.Show("Input data for Month is out of range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!dateCheck.IsYearInRange(year))
                {
                    MessageBox.Show("Input data for Year is out of range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!dateCheck.IsValidDate(year, month, day))
                {
                    MessageBox.Show($"{inputDate} is NOT correct date time!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"{inputDate} is correct date time!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Proceed with further processing
            }
        }

        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
