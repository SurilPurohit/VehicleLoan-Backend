using System;
using System.Collections.Generic;

#nullable disable

namespace VehicleLoan.LTIModel
{
    public partial class UploadTable
    {
        public int? UserId { get; set; }
        public string Adhar { get; set; }
        public string Pan { get; set; }

        public virtual UserTable User { get; set; }
    }
}
