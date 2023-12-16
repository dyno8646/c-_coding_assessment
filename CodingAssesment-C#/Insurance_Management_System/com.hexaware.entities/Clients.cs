using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.com.hexaware.entities
{
    public class Clients
    {
        private int clientId;
        private string clientName;
        private string contactInfo;
        private Policies policy;

        public Clients()
        {
        }

        public Clients(int clientId, string clientName, string contactInfo, Policies policy)
        {
            this.ClientId = clientId;
            this.ClientName = clientName;
            this.ContactInfo = contactInfo;
            this.Policy = policy;
        }

        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }

        public string ContactInfo
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }

        public Policies Policy
        {
            get { return policy; }
            set { policy = value; }
        }

        public override string ToString()
        {
            return $"Client [ClientId={ClientId}, ClientName={ClientName}, ContactInfo={ContactInfo}, Policy={Policy}]";
        }
    }
}
