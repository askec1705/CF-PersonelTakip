using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace WFAPersonelTakibi
{
    public partial class Form4 : MetroForm
    {
        private Employee employee;

        public Form4()
        {
            InitializeComponent();
        }

        EmployeesService employeesService = new EmployeesService();

        public Form4(Employee employee)
        {
            this.employee = employee;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cmbDepartment.Items.AddRange(Enum.GetNames(typeof(Department)));

            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtPhone.Text = employee.Phone;
            txtAddress.Text = employee.Address;
            dtBirthDate.Value = employee.BirthDate;
            txtMail.Text = employee.Mail;
            cmbDepartment.Text = employee.Department.ToString();

            MetroRadioButton rd = (MetroRadioButton)metroPanel1.Controls.Find(("rd" + employee.Gender.ToString()), false)[0];
            rd.Checked = true;
            pcbImageUrl.Image = Image.FromFile(employee.ImageUrl);
        }

        private void MetroLink1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.ShowDialog();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool result = employeesService.Update(employee);
        }
    }
}
