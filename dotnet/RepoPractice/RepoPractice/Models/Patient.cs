using System;
using System.Collections.Generic;

#nullable disable

namespace RepoPractice.Models
{
    public partial class Patient
    {
        public Patient()
        {
            DrugsDetails = new HashSet<DrugsDetail>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int? DoctorId { get; set; }
        public int? AssistantId { get; set; }

        public virtual Assistant Assistant { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<DrugsDetail> DrugsDetails { get; set; }
    }
}
