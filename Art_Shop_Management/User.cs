using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_shop_management_system
{
    public class User
    {
        protected int userId;
        protected string Name;
        protected string hashPassword;
        protected string contactInformation;
        protected string email;
        protected string dob;
        protected string gender;
        protected string addrress;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public string HashPassword
        {
            get { return hashPassword; }
            set { hashPassword = value; }
        }
         
        public string ContactInformation
        {
            get { return contactInformation; }
            set { contactInformation = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Addrress
        {
            get { return addrress; }
            set { addrress = value; }
        }

        public User(int userId, string name, string hashPassword, string contactInformation, string email, string dob, string gender, string addrress)
        {
            this.userId = userId;
            this.Name = name;
            this.hashPassword = hashPassword;
            this.contactInformation = contactInformation;
            this.email = email;
            this.dob = dob;
            this.gender = gender;
            this.addrress = addrress;
        }
    }
}
