using System;
using System.Collections.Generic;

#nullable disable

namespace VehicleLoan.LTIModel
{
    public partial class LoanTable
    {
        public int LoanId { get; set; }
        public int? UserId { get; set; }
        public string EmploymentType { get; set; }
        public int AnnualSalary { get; set; }
        public string ExistingEmi { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int ShowroomPrice { get; set; }
        public int OnRoadPrice { get; set; }
        public int LoanAmount { get; set; }
        public int LoanTenure { get; set; }
        public double RateOfInterest { get; set; }
        public string LoanStatus { get; set; }

        public virtual UserTable User { get; set; }
    }
}
