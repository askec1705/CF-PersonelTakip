using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAPersonelTakibi
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeeID = Guid.NewGuid(); //otomatik olarak yeni id üretsin diye
        }

        public Guid EmployeeID { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        [MaxLength(100)]
        [Required]
        public string Mail { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [MaxLength(100)]
        [Required]
        public string Address { get; set; }

        [MaxLength(24)]
        [Required]
        public string Phone { get; set; }

        [Required]
        public Department Department { get; set; }
        public string ImageUrl { get; set; } = $@"{Environment.CurrentDirectory}\..\..\img\avatar.jpg";
        public EntityState State { get; internal set; }
    }
}
