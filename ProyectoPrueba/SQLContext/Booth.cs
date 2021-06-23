using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.SQLContext
{
    public partial class Booth
    {
        public Booth()
        {
            Employees = new HashSet<Employee>();
            Logins = new HashSet<Login>();
        }

        public int Id { get; set; }
        public string Direction { get; set; }
        public string IdManager { get; set; }

        public virtual Manager IdManagerNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}
