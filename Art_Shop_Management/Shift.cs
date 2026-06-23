using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_shop_management_system
{
    internal class Shift
    {
        private string shiftId;
        private string startTime;
        private string endTime;
        public string shiftName;

        public string ShiftId
        {
            get { return shiftId; }
            set { shiftId = value; }
        }
        public string StartTime 
        { get { return startTime; } 
            set { startTime = value; } 
        }

        public string EndTime 
        { get { return endTime;} 
            set { endTime = value; }
        }

        public string ShiftName 
        { get { return shiftName; }
            set { shiftName = value; }
        }

        public Shift(string shiftId, string startTime, string endTime, string shiftName)
        {
            this.shiftId = shiftId;
            this.startTime = startTime;
            this.endTime = endTime;
            this.shiftName = shiftName;
        }
    }
}