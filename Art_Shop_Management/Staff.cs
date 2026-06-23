using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Art_shop_management_system
{
    internal class Staff : User
    {
        private int staffId;
        private int salesCounter;
        private string shiftId;
        private string employeeStatus;
        private int totalSales;

        public int StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }
        public int SalesCounter
        {
            get { return salesCounter; }
            set { salesCounter = value; }
        }
        public string ShiftId
        {
            get { return shiftId; }
            set { shiftId = value; }
        }
        public string EmployeeStatus
        {
            get { return employeeStatus; }
            set { employeeStatus = value; }
        }
        public int TotalSales
        {
            get { return totalSales; }
            set { totalSales = value; }
        }

        public Staff(int userId, string name, string hashPassword, string contactInformation, string email, string dob, string gender, string addrress, int salesCounter, string shiftId, string employeeStatus, int totalSales)
            : base(userId, name, hashPassword, contactInformation, email, dob, gender, addrress)
        {
            this.salesCounter = salesCounter;
            this.shiftId = shiftId;
            this.employeeStatus = employeeStatus;
            this.totalSales = totalSales;
        }
    }
}
