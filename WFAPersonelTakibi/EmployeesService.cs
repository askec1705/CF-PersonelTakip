using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAPersonelTakibi
{
    public class EmployeesService
    {
        private ProjectContext _context;
        public EmployeesService()
        {
            _context = new ProjectContext();
        }
        public bool Add(Employee employee)
        {
            _context.Employees.Add(employee).State = System.Data.Entity.EntityState.Added;
            return _context.SaveChanges() > 0;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public bool Delete(Employee employee)
        {
            _context.Employees.Remove(employee).State = System.Data.Entity.EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        public bool Update(Employee employee)
        {
            _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;// changetracker state'i modified ise güncelleme yapar.
            return _context.SaveChanges() > 0;
        }
        public Employee GetById(int id)
        {
            return null;
        }
    }
}
