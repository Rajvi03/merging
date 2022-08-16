using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class ProductDesign
    {
        public ProductDesign()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int ProductDesignId { get; set; }
        public int? JewelleryTypeId { get; set; }
        public string DesignName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual JewelleryType JewelleryType { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
