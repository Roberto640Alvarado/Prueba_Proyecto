using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.ContextSQL
{
    public partial class Disease
    {
        public int Id { get; set; }
        public string Disease1 { get; set; }
        public int IdCitizen { get; set; }

        public virtual Citizen IdCitizenNavigation { get; set; }
    }
}
