using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class Discount
    {
        public int DiscountId { get; set; }
        public int? ProductDetailsId { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ProductDetail ProductDetails { get; set; }
    }
}
