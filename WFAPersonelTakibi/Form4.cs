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
        
        public Form4()
        {
            InitializeComponent();
        }

        Employee employee;

        EmployeesService employeesService = new EmployeesService();

        public Form4(Employee employee)
        {
            this.employee = employee;
        }

        public void Temizle(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is MetroTextBox)
                {
                    item.Text = "";
                }
                else if (item is MetroComboBox)
                {
                    item.Text = default;
                }
                if (item is MetroDateTime)
                {
                    item.Text = "";
                }
            }
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.Phone = txtPhone.Text;
            employee.Address = txtAddress.Text;
            employee.BirthDate = dtBirthDate.Value;
            employee.Mail = txtMail.Text;

            foreach (Control item in metroPanel1.Controls)
            {
                if (item is MetroRadioButton)//MetroRadioButton'un çalışması için yukarıya "using MetroFramework.Controls" ekle

                {
                    MetroRadioButton rd = (MetroRadioButton)item;
                    if (rd.Checked)
                    {
                        employee.Gender = (Gender)Enum.Parse(typeof(Gender), rd.Text);
                    }
                }
            }

            if (pcbImageUrl.Tag != null)
            {
                employee.ImageUrl = pcbImageUrl.Tag.ToString();
            }

            Temizle(groupBox1);

            MessageBox.Show("İşleminiz başarıyla gerçekleşti.");

            bool result = employeesService.Update(employee);

            employeesService.Update(employee);
        }

        private void PcbImageUrl_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pcbImageUrl.Image = Image.FromFile(ofd.FileName);

                string imageName = $@"{Environment.CurrentDirectory}\..\..\img\{Guid.NewGuid()}{System.IO.Path.GetExtension(ofd.FileName)}";

                pcbImageUrl.Image.Save(imageName);

                bool result = System.IO.File.Exists(imageName);
                if (result)
                {
                    pcbImageUrl.Tag = imageName;
                }
            }
        }

        private void MetroLink1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
