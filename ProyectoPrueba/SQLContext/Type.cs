using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.SQLContext
{
    public partial class Type
    {
        public Type()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Type1 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
