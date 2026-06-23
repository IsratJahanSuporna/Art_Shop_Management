using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_shop_management_system
{
    internal class SystemLogAccess
    {
        public int systemLogAcccessId;
        public int userId;
        public string log;
        public string date;

        public int SystemLogAcccessId
        {
            get { return systemLogAcccessId; }
            set { systemLogAcccessId = value; }
        }
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string Log
        {
            get { return log; }
            set { log = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public SystemLogAccess(int systemLogAcccessId, int userId, string log, string date)
        {
            this.systemLogAcccessId = SystemLogAcccessId;
            this.userId = UserId;
            this.log = Log;
            this.date = Date;
        }
    }
}
