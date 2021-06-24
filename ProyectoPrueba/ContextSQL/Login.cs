using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.ContextSQL
{
    public partial class Login
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int IdBooth { get; set; }
        public string IdEmployee { get; set; }

        public virtual Booth IdBoothNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
