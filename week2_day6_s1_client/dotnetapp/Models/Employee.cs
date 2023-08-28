using System;
using System.Collections.Generic;

namespace dotnetapp.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public int? Deptid { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public int? Salary { get; set; }

        public virtual Dept? Dept { get; set; }
    }
}
