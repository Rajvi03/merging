using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class JewelleryType
    {
        public JewelleryType()
        {
            ProductDesigns = new HashSet<ProductDesign>();
        }

        public int JewelleryTypeId { get; set; }
        public int? MaterialTypeId { get; set; }
        public string JewelleryName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual MaterialType MaterialType { get; set; }
        public virtual ICollection<ProductDesign> ProductDesigns { get; set; }
    }
}
