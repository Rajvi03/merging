using System;
using System.Collections.Generic;

#nullable disable

namespace RepoPractice.Models
{
    public partial class DrugsDetail
    {
        public int DrugsDetailsId { get; set; }
        public int? PatientId { get; set; }
        public int? DrugId { get; set; }
        public string Timing { get; set; }

        public virtual Drug Drug { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
