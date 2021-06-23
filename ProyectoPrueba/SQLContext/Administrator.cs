using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.SQLContext
{
    public partial class Administrator
    {
        public Administrator()
        {
            Citizens = new HashSet<Citizen>();
            Employees = new HashSet<Employee>();
        }

        public string Id { get; set; }
        public string NameUser { get; set; }
        public string PasswordUser { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
