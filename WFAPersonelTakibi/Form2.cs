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

        Employee employee;

        EmployeesService employeesService = new EmployeesService();

        ProjectContext db = new ProjectContext();

        public Form2(Employee employee)
        {
            this.employee = employee;
        }

        public void Liste()
        {
            dgvEmployees.DataSource = db.Employees.Select(pb => new
            {
                pb.EmployeeID,
                pb.FirstName,
                pb.LastName,
                pb.Phone
            }).ToList();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Liste();
        }

        public static List<Employee> Employees = new List<Employee>();

        private void TsmSil_Click(object sender, EventArgs e)
        {
            Guid Id = (Guid)dgvEmployees.SelectedRows[0].Cells[0].Value;
            Employee employee = db.Employees.FirstOrDefault(x => x.EmployeeID == Id);
            employeesService.Delete(employee);
                Liste();
        }

        private void TsmDuzenle_Click(object sender, EventArgs e)
        {
            Guid Id = (Guid)dgvEmployees.SelectedRows[0].Cells[0].Value;
            Employee employee = db.Employees.FirstOrDefault(x => x.EmployeeID == Id);
            Form4 frm4 = new Form4(employee);
            this.Hide();
            frm4.ShowDialog();
        }

        private void TsmDetay_Click(object sender, EventArgs e)
        {
            Guid Id = (Guid)dgvEmployees.SelectedRows[0].Cells[0].Value;
            Employee personel = db.Employees.FirstOrDefault(x => x.EmployeeID == Id);
            Form3 frm3 = new Form3(personel);
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
