using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class Image
    {
        public int ImagesId { get; set; }
        public int? ProductDetailsId { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ProductDetail ProductDetails { get; set; }
    }
}
