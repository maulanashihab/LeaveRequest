using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class AvailableLeaveVM
    {
        public int ThisYear { get; set; }
        public int LastYear { get; set; }
        public AvailableLeaveVM() { }
        public AvailableLeaveVM(int thisYear, int lastYear)
        {
            this.ThisYear = thisYear;
            this.LastYear = lastYear;
        }
        public void Update(int thisYear, int lastYear)
        {
            this.ThisYear = thisYear;
            this.LastYear = lastYear;
        }
    }
}
