using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.com.hexaware.entities
{
    public class Policies
    {
        private int policyId;
        private string policyNumber;
        private string policyType;
        private decimal coverageAmount;
        private decimal premiumAmount;
        private DateTime startDate;
        private DateTime endDate;

        public Policies()
        {
        }

        public Policies(int policyId, string policyNumber, string policyType, decimal coverageAmount, decimal premiumAmount, DateTime startDate, DateTime endDate)
        {
            this.PolicyId = policyId;
            this.PolicyNumber = policyNumber;
            this.PolicyType = policyType;
            this.CoverageAmount = coverageAmount;
            this.PremiumAmount = premiumAmount;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public int PolicyId
        {
            get { return policyId; }
            set { policyId = value; }
        }

        public string PolicyNumber
        {
            get { return policyNumber; }
            set { policyNumber = value; }
        }

        public string PolicyType
        {
            get { return policyType; }
            set { policyType = value; }
        }

        public decimal CoverageAmount
        {
            get { return coverageAmount; }
            set { coverageAmount = value; }
        }

        public decimal PremiumAmount
        {
            get { return premiumAmount; }
            set { premiumAmount = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public override string ToString()
        {
            return $"Policy [PolicyId={PolicyId}, PolicyNumber={PolicyNumber}, PolicyType={PolicyType}, " +
                   $"CoverageAmount={CoverageAmount}, PremiumAmount={PremiumAmount}, " +
                   $"StartDate={StartDate}, EndDate={EndDate}]";
        }
    }
}
