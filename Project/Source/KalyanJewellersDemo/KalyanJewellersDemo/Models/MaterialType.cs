using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class MaterialType
    {
        public MaterialType()
        {
            JewelleryTypes = new HashSet<JewelleryType>();
        }

        public int MaterialTypeId { get; set; }
        public string MaterialName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<JewelleryType> JewelleryTypes { get; set; }
    }
}
