using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class Subscriber
    {
        public Subscriber()
        {
            Users = new HashSet<User>();
        }

        public int SubscribersId { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
