using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.ContextSQL
{
    public partial class Employee
    {
        public Employee()
        {
            Logins = new HashSet<Login>();
        }

        public string Id { get; set; }
        public string NameEmployee { get; set; }
        public string EMailInstitutional { get; set; }
        public string Direction { get; set; }
        public int IdBooth { get; set; }
        public int IdType { get; set; }
        public string IdAdministrator { get; set; }

        public virtual Administrator IdAdministratorNavigation { get; set; }
        public virtual Booth IdBoothNavigation { get; set; }
        public virtual Type IdTypeNavigation { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
    }
}
