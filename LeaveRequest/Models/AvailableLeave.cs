using LeaveRequest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.ViewModels;

namespace LeaveRequest.Models
{
    public class AvailableLeave : BaseModel
    {
        private AvailableLeaveVM availableLeaveVM;

        public AvailableLeave() { }

        public AvailableLeave(AvailableLeave availableLeaveVM)
        {
            this.ThisYear = availableLeaveVM.ThisYear;
            this.LastYear = availableLeaveVM.LastYear;
        }

        public AvailableLeave(AvailableLeaveVM availableLeaveVM)
        {
            this.availableLeaveVM = availableLeaveVM;
        }

        public void Update(AvailableLeave availableLeaveVM)
        {
           
            this.ThisYear = availableLeaveVM.ThisYear;
            this.LastYear = availableLeaveVM.LastYear;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
        public int ThisYear { get; set; }
        public int LastYear { get; set; }
        
    }
}
