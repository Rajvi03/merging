using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            OrderAddresses = new HashSet<OrderAddress>();
            OrderCartDetails = new HashSet<Order>();
            OrderUsers = new HashSet<Order>();
            WishLists = new HashSet<WishList>();
        }

        public int UsersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string AlternateMobileNo { get; set; }
        public string Gender { get; set; }
        public string UserRole { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? AnniversaryDate { get; set; }
        public string Company { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public int? ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? SubscribersId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Subscriber Subscribers { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderAddress> OrderAddresses { get; set; }
        public virtual ICollection<Order> OrderCartDetails { get; set; }
        public virtual ICollection<Order> OrderUsers { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
    public partial class UserVM
    {
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string Password { get; set; }
    }
}
