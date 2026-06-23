using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_shop_management_system
{
    internal class Customer: User
    {
        private int customerId;
        private string customerName;
        private int membershipTier;
        private int totalSpending;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public int MembershipTier
        {
            get { return membershipTier; }
            set { membershipTier = value; }
        }
        public int TotalSpending
        {
            get { return totalSpending; }
            set { totalSpending = value; }
        }

        public Customer(int userId, string name, string hashPassword, string contactInformation, string email, string dob, string gender, string addrress, string customerName, int membershipTier, int totalSpending)
                      :base(userId, name, hashPassword, contactInformation, email, dob, gender, addrress)
        {
             this.name = Name;
            this.membershipTier = MembershipTier;
            this.totalSpending = TotalSpending;
        }
    }
}
