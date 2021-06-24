using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.ContextSQL
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int IdCitizen { get; set; }
        public int IdVaccination { get; set; }

        public virtual Citizen IdCitizenNavigation { get; set; }
        public virtual Vaccination IdVaccinationNavigation { get; set; }
    }
}
