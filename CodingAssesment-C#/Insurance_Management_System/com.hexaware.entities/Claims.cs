using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.com.hexaware.entities
{
    public class Claims
    {
        private int claimId;
        private string claimNumber;
        private DateTime dateFiled;
        private double claimAmount;
        private ClaimStatus status;
        private Policies policy;
        private Clients client;

        public Claims()
        {
        }
        public Claims(int claimId, string claimNumber, DateTime dateFiled, double claimAmount, ClaimStatus status, Policies policy, Clients client)
        {
            this.ClaimId = claimId;
            this.ClaimNumber = claimNumber;
            this.DateFiled = dateFiled;
            this.ClaimAmount = claimAmount;
            this.Status = status;
            this.Policy = policy;
            this.Client = client;
        }

        public int ClaimId
        {
            get { return claimId; }
            set { claimId = value; }
        }

        public string ClaimNumber
        {
            get { return claimNumber; }
            set { claimNumber = value; }
        }

        public DateTime DateFiled
        {
            get { return dateFiled; }
            set { dateFiled = value; }
        }

        public double ClaimAmount
        {
            get { return claimAmount; }
            set { claimAmount = value; }
        }

        public ClaimStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public Policies Policy
        {
            get { return policy; }
            set { policy = value; }
        }

        public Clients Client
        {
            get { return client; }
            set { client = value; }
        }

        public override string ToString()
        {
            return $"Claim [ClaimId={ClaimId}, ClaimNumber={ClaimNumber}, DateFiled={DateFiled}, " +
                   $"ClaimAmount={ClaimAmount}, Status={Status}, Policy={Policy}, Client={Client}]";
        }
    }

    public enum ClaimStatus
    {
        PENDING, APPROVED, DENIED
    }
}
