using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.com.hexaware.entities
{
    public class Users
    {
        private int userId;
        private string username;
        private string password;
        private UserRole role;

        // Default constructor
        public Users()
        {
        }

        // Parameterized constructor
        public Users(int userId, string username, string password, UserRole role)
        {
            this.UserId = userId;
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public UserRole Role
        {
            get { return role; }
            set { role = value; }
        }
        public override string ToString()
        {
            return $"User [UserId={UserId}, Username={Username}, Role={Role}]";
        }
    }

    public enum UserRole
    {
        ADMIN, AGENT, CLIENT
    }
}

