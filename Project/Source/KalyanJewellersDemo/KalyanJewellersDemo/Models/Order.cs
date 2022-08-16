using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class Order
    {
        public int OrdersId { get; set; }
        public int UserId { get; set; }
        public int CartDetailId { get; set; }
        public int OrderAddressId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderAmount { get; set; }
        public int? DiscountAmount { get; set; }
        public int? PayableAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual User CartDetail { get; set; }
        public virtual OrderAddress OrderAddress { get; set; }
        public virtual User User { get; set; }
    }
}
