using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.SQLContext
{
    public partial class Vaccination
    {
        public Vaccination()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public DateTime DateTimeApplication { get; set; }
        public DateTime DateTimeProcess { get; set; }
        public DateTime? TimeSecondaryEffect { get; set; }
        public int IdPlaceVaccination { get; set; }
        public int? IdEffectSecondary { get; set; }

        public virtual EffectSecondary IdEffectSecondaryNavigation { get; set; }
        public virtual PlaceVaccination IdPlaceVaccinationNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
