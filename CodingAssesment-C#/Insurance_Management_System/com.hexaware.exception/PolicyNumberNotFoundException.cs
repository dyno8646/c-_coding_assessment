﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.com.hexaware.exception
{
    public class PolicyNumberNotFoundException: Exception
    {
        public PolicyNumberNotFoundException()
        {
        }

        public PolicyNumberNotFoundException(string message)
            : base(message)
        {
        }

        public PolicyNumberNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
