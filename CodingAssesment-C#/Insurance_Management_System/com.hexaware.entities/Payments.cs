using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.com.hexaware.entities
{
    public class Payments
    {
        private int paymentId;
        private DateTime paymentDate;
        private double paymentAmount;
        private Clients client;

        public Payments()
        {
        }

        public Payments(int paymentId, DateTime paymentDate, double paymentAmount, Clients client)
        {
            this.PaymentId = paymentId;
            this.PaymentDate = paymentDate;
            this.PaymentAmount = paymentAmount;
            this.Client = client;
        }

        public int PaymentId
        {
            get { return paymentId; }
            set { paymentId = value; }
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        public double PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }

        public Clients Client
        {
            get { return client; }
            set { client = value; }
        }

        public override string ToString()
        {
            return $"Payment [PaymentId={PaymentId}, PaymentDate={PaymentDate}, " +
                   $"PaymentAmount={PaymentAmount}, Client={Client}]";
        }
    }
}
