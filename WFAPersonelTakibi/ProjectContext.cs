using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAPersonelTakibi
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=.;database=EFDb;uid=sa;pwd=123";
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
