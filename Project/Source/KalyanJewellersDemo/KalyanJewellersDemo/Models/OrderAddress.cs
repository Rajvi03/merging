using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class OrderAddress
    {
        public OrderAddress()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderAddressId { get; set; }
        public int UserId { get; set; }
        public string Company { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
