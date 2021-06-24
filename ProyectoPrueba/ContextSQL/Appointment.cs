using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.ContextSQL
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string DuiCitizen { get; set; }
        public int IdVaccination { get; set; }

        public virtual Citizen DuiCitizenNavigation { get; set; }
        public virtual Vaccination IdVaccinationNavigation { get; set; }
    }
}
