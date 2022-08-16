﻿using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class WishList
    {
        public int WishListId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
