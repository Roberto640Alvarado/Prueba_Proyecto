using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.ContextSQL
{
    public partial class Citizen
    {
        public Citizen()
        {
            Appointments = new HashSet<Appointment>();
        }

        public string Dui { get; set; }
        public string NameCitizen { get; set; }
        public string Phone { get; set; }
        public string Direction { get; set; }
        public string EMail { get; set; }
        public string IdAdministrator { get; set; }
        public int? IdDisease { get; set; }
        public int IdInstitution { get; set; }

        public virtual Administrator IdAdministratorNavigation { get; set; }
        public virtual Disease IdDiseaseNavigation { get; set; }
        public virtual Institution IdInstitutionNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
