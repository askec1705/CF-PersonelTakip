using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace WFAPersonelTakibi
{
    
    public partial class Form1 : MetroForm
      
    {
        public Form1()
        {
            InitializeComponent();
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

        public void HataMetodu(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is MetroTextBox && item.Text is null)
                {
                    MessageBox.Show("Lütfen bilgileri eksiksiz giriniz");
                }

                else if (item is ComboBox && item.Text is null)
                {
                    MessageBox.Show("Lütfen bilgileri eksiksiz giriniz");
                }
                else if (item is MetroDateTime && item.Text is null)
                {
                    MessageBox.Show("Lütfen bilgileri eksiksiz giriniz");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDepartment.Items.AddRange(Enum.GetNames(typeof(Department)));
        }
        public static List<Employee> Employees = new List<Employee>();

        EmployeesService employeesService = new EmployeesService();
        public void BtnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();

            employee.Mail = txtMail.Text;
            employee.Phone = txtPhone.Text;
            employee.Address = txtAddress.Text;
            employee.LastName = txtLastName.Text;
            employee.FirstName = txtFirstName.Text;
            employee.BirthDate = dtBirthDate.Value;

            employee.Department = (Department)Enum.Parse(typeof(Department), cmbDepartment.Text);

            if (pcbImageUrl.Tag != null)
            {
                employee.ImageUrl = pcbImageUrl.Tag.ToString();
            }

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

            HataMetodu(groupBox1);
            Temizle(groupBox1);
            Employees.Add(employee);
            bool result = employeesService.Add(employee);
            Employees.Add(employee);
            MetroMessageBox.Show(this, result ? "Kayıt başarıyla eklendi" : "Kayıt ekleme hatası", "Kayıt Ekleme Bildirme", MessageBoxButtons.OK, result ? MessageBoxIcon.Hand : MessageBoxIcon.Error);
        }

        private void PcbImageUrl_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK) //eğer kullanıcı bir img seçip ok tuşuna bastıysa...
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

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            txtFirstName.Text = FakeData.NameData.GetFirstName();
            txtLastName.Text = FakeData.NameData.GetSurname();
            dtBirthDate.Value = FakeData.DateTimeData.GetDatetime();
            txtMail.Text = FakeData.NetworkData.GetEmail().ToLower();
            txtAddress.Text = FakeData.PlaceData.GetAddress();
            txtPhone.Text = FakeData.PhoneNumberData.GetPhoneNumber(); 
        }
    }
}
