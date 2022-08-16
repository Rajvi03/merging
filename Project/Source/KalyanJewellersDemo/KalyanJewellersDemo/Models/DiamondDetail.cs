using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class DiamondDetail
    {
        public int DiamondDetailsId { get; set; }
        public int? ProductDetailsId { get; set; }
        public int? TotalNoOfDiamonds { get; set; }
        public int? TotalWeight { get; set; }
        public int? Clarity { get; set; }
        public string Color { get; set; }
        public string SettingType { get; set; }
        public string Shape { get; set; }
        public int? DiamondWeight { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblObject ClarityNavigation { get; set; }
    }
}
