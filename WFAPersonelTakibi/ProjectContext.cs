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
            Database.Connection.ConnectionString = "Server=.;Database=wfaPt;UID=sa;PWD=123;";
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
