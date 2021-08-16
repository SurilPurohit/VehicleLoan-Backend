using System;
using System.Collections.Generic;

#nullable disable

namespace VehicleLoan.LTIModel
{
    public partial class UserTable
    {
        public UserTable()
        {
            LoanTables = new HashSet<LoanTable>();
            UploadTables = new HashSet<UploadTable>();
        }

        public int UserId { get; set; }
        public string Uname { get; set; }
        public int Uage { get; set; }
        public string Ugender { get; set; }
        public string Umobile { get; set; }
        public string Uemail { get; set; }
        public string Upassword { get; set; }
        public string Uaddress { get; set; }
        public string Ustate { get; set; }
        public string Ucity { get; set; }
        public int Upin { get; set; }

        public virtual ICollection<LoanTable> LoanTables { get; set; }
        public virtual ICollection<UploadTable> UploadTables { get; set; }
    }
}
