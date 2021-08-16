using System;
using System.Collections.Generic;

#nullable disable

namespace VehicleLoan.LTIModel
{
    public partial class EligibilityTable
    {
        public int EligId { get; set; }
        public string Uname { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int ShowroomPrice { get; set; }
        public int OnRoadPrice { get; set; }
        public int LoanAmt { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string ExistingEmi { get; set; }
        public double RateOfInterest { get; set; }
        public int LoanPeriod { get; set; }

        public virtual LoginTable UnameNavigation { get; set; }
    }
}
