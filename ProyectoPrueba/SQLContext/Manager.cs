using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.SQLContext
{
    public partial class Manager
    {
        public Manager()
        {
            Booths = new HashSet<Booth>();
        }

        public string Id { get; set; }
        public string NameManager { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }

        public virtual ICollection<Booth> Booths { get; set; }
    }
}
