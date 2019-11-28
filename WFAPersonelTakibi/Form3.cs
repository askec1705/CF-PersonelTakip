using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace WFAPersonelTakibi
{
    public partial class Form3 : MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        Employee employee;

        public Form3(Employee employee) : this()
        {
            this.employee = employee;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lblFirstName.Text = employee.FirstName;
            lblLastName.Text = employee.LastName;
            lblPhone.Text = employee.Phone;
            lblAddress.Text = employee.Address;
            lblBirthDate.Text = employee.BirthDate.ToString();
            lblMail.Text = employee.Mail;
            lblDepartment.Text = employee.Department.ToString();
            lblGender.Text = employee.Gender.ToString();

            pcbImageUrl.Image = Image.FromFile(employee.ImageUrl);
        }
    }
}
