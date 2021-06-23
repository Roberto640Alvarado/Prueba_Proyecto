using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.SQLContext
{
    public partial class Disease
    {
        public Disease()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Id { get; set; }
        public string Disease1 { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
