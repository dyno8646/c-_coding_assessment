using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance_Management_System.com.hexaware.entities;
using Insurance_Management_System.com.hexaware.util;

namespace Insurance_Management_System.com.hexaware.dao
{
    public interface IPolicyService
    {
        bool CreatePolicy(Policies policy);
        Policies GetPolicy(int policyId);
        List<Policies> GetAllPolicies();
        bool UpdatePolicy(Policies policy);
        bool DeletePolicy(int policyId);
    }
}
