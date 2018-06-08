using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace DPWin
{
    public partial class Copy : Form
    {
        public Copy()
        {
            InitializeComponent();
        }

        Employee employee = new Employee() { EmpAddress = new Address() };
        Employee employeeCopied;

        StringBuilder sb = new StringBuilder();

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnShallowCopy_Click(object sender, EventArgs e)
        {
            employeeCopied = this.employee.ShallowCopy();
            Refresh();
        }

        private void btnDeepCopy_Click(object sender, EventArgs e)
        {
            employeeCopied = this.employee.DeepCopy();
            Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private new void Refresh() {
            sb.Clear();
            sb.AppendLine("---------------------------------");
            sb.AppendLine(string.Format("Main Employee : {0} ",
                this.employee.ToString()));
            sb.AppendLine();
            sb.AppendLine(string.Format("Copied Employee : {0} ",
                employeeCopied.ToString()));
            sb.AppendLine("-----------------------------------");
            sb.AppendLine(txtOutput.Text);

            txtOutput.Text = sb.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            employee.Id = txtId.Text;
            employee.Name = txtName.Text;
            employee.EmpAddress.Country = txtCountry.Text;
            employee.EmpAddress.DoorNumber = int.Parse(txtDoorNo.Text);
            employee.EmpAddress.StreetNumber = int.Parse(txtStreetNo.Text);
            employee.EmpAddress.Zipcode = int.Parse(txtZipcode.Text);
            MessageBox.Show("Updated");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.ResetText();
        }
    }
}
