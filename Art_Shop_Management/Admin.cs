using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_shop_management_system
{
    internal class Admin:User 
    {
        private int adminId;
        private int permissonLevel;
        private SystemLogAccess systemLogAccess;

        public int AdminId
        {
            get { return adminId; }
            set { adminId = value; }
        }
        public int PermissonLevel
        {
            get { return permissonLevel; }
            set { permissonLevel = value; }
        }
        public SystemLogAccess SystemLogAccess
        {
            get { return systemLogAccess; }
            set { systemLogAccess = value; }
        }

        public Admin(int userId, string name, string hashPassword, string contactInformation, string email, string dob, string gender, string addrress, int permissonLevel, SystemLogAccess systemLogAccess)
            :base(userId, name, hashPassword, contactInformation, email, dob, gender, addrress)
        {
            this.permissonLevel = permissonLevel;
            this.systemLogAccess = systemLogAccess;
        }
    }
}
