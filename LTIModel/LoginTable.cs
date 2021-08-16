using System;
using System.Collections.Generic;

#nullable disable

namespace VehicleLoan.LTIModel
{
    public partial class LoginTable
    {
        public LoginTable()
        {
            EligibilityTables = new HashSet<EligibilityTable>();
        }

        public string Uname { get; set; }
        public string Upassword { get; set; }
        public string Uadmin { get; set; }

        public virtual ICollection<EligibilityTable> EligibilityTables { get; set; }
    }
}
