using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoPrueba.SQLContext
{
    public partial class EffectSecondary
    {
        public EffectSecondary()
        {
            Vaccinations = new HashSet<Vaccination>();
        }

        public int Id { get; set; }
        public string EffectSecondary1 { get; set; }

        public virtual ICollection<Vaccination> Vaccinations { get; set; }
    }
}
