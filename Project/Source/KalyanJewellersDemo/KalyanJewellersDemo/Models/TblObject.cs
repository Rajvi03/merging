using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class TblObject
    {
        public TblObject()
        {
            DiamondDetails = new HashSet<DiamondDetail>();
            ProductDetailMetalColorNavigations = new HashSet<ProductDetail>();
            ProductDetailMetalpurityNavigations = new HashSet<ProductDetail>();
            ProductDetailProductStatusNavigations = new HashSet<ProductDetail>();
            ProductDetailUserCategoryNavigations = new HashSet<ProductDetail>();
        }

        public int TblObjectId { get; set; }
        public int? TblTypeId { get; set; }
        public string ObjectValue { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblType TblType { get; set; }
        public virtual ICollection<DiamondDetail> DiamondDetails { get; set; }
        public virtual ICollection<ProductDetail> ProductDetailMetalColorNavigations { get; set; }
        public virtual ICollection<ProductDetail> ProductDetailMetalpurityNavigations { get; set; }
        public virtual ICollection<ProductDetail> ProductDetailProductStatusNavigations { get; set; }
        public virtual ICollection<ProductDetail> ProductDetailUserCategoryNavigations { get; set; }
    }
}
