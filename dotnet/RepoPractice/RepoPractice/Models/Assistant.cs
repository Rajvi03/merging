﻿using System;
using System.Collections.Generic;

#nullable disable

namespace RepoPractice.Models
{
    public partial class Assistant
    {
        public Assistant()
        {
            Patients = new HashSet<Patient>();
        }

        public int AssistantsId { get; set; }
        public string AssistantName { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
