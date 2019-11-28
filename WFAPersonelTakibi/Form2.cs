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
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        EmployeesService employeesService = new EmployeesService();

        public void Liste()
        {
            dgvEmployees.DataSource = Form1.Employees.Select(pb => new
            {
                pb.EmployeeID,
                pb.FirstName,
                pb.LastName,
                pb.Phone
            }).ToList();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgvEmployees.DataSource = Form1.Employees
                .Select(x => new { ID = x.EmployeeID, Adi = x.FirstName, Soyadi = x.LastName, Telefon = x.Phone })
                .ToList();
            Liste();
        }
        private void TsmDuzenle_Click(object sender, EventArgs e)
        {
            Guid Id = (Guid)dgvEmployees.SelectedRows[0].Cells[0].Value;
            Employee employee = Form1.Employees.FirstOrDefault(x => x.EmployeeID == Id);
            Form4 frm4 = new Form4(employee);
            this.Hide();
            frm4.ShowDialog();
        }

        private void TsmSil_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                Guid Id = (Guid)dgvEmployees.SelectedRows[0].Cells[0].Value;
                Employee employee = Form1.Employees.FirstOrDefault(x => x.EmployeeID == Id);
                employeesService.Delete(employee);
            }
        }

        private void TsmDetay_Click(object sender, EventArgs e)
        {
            Guid Id = (Guid)dgvEmployees.SelectedRows[0].Cells[0].Value;
            Employee employee = Form1.Employees.FirstOrDefault(x => x.EmployeeID == Id);
            Form3 frm3 = new Form3(employee);
            this.Hide();
            frm3.ShowDialog();
        }

        private void TsmYeni_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
        }
    }
}
