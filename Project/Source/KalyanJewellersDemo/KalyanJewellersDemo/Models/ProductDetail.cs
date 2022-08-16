using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class ProductDetail
    {
        public ProductDetail()
        {
            Discounts = new HashSet<Discount>();
            Images = new HashSet<Image>();
        }

        public int ProductDetailsId { get; set; }
        public int? ProductId { get; set; }
        public string StyleNo { get; set; }
        public decimal? Height { get; set; }
        public decimal? TotalWeight { get; set; }
        public string Size { get; set; }
        public decimal? MetalWeight { get; set; }
        public int? ProductDesignId { get; set; }
        public int? UserCategory { get; set; }
        public int? MetalColor { get; set; }
        public int? Metalpurity { get; set; }
        public int? ProductStatus { get; set; }
        public int? MetalPrice { get; set; }
        public int? MakingCharges { get; set; }
        public DateTime? PcreatedDate { get; set; }
        public int? Stock { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblObject MetalColorNavigation { get; set; }
        public virtual TblObject MetalpurityNavigation { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductDesign ProductDesign { get; set; }
        public virtual TblObject ProductStatusNavigation { get; set; }
        public virtual TblObject UserCategoryNavigation { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
