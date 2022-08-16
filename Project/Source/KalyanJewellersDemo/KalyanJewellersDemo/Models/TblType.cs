using System;
using System.Collections.Generic;

#nullable disable

namespace KalyanJewellersDemo.Models
{
    public partial class TblType
    {
        public TblType()
        {
            TblObjects = new HashSet<TblObject>();
        }

        public int TblTypeId { get; set; }
        public string TypeName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<TblObject> TblObjects { get; set; }
    }
}
