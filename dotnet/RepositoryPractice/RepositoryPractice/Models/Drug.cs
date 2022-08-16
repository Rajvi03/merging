using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryPractice.Models
{
    public partial class Drug
    {
        public Drug()
        {
            DrugsDetails = new HashSet<DrugsDetail>();
        }

        public int DrugId { get; set; }
        public string DrugName { get; set; }

        public virtual ICollection<DrugsDetail> DrugsDetails { get; set; }
    }
}
