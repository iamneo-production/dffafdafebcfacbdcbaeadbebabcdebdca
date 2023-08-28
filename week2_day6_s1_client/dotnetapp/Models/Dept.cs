using System;
using System.Collections.Generic;

namespace dotnetapp.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
