using System;
using System.Collections.Generic;

namespace Hospital.Models
{
    public partial class Patients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string HealthCondition { get; set; }
        public int DoctorId { get; set; }
        public int NurseId { get; set; }
        public DateTime Created { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Nurses Nurse { get; set; }
    }
}
