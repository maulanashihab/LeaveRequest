using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class EmployeeStatusVM
    {
        
        public DateTime? JoinDate{ get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
       
        public EmployeeStatusVM(DateTime? joinDate, DateTime? endDate, string status)
        {
            this.JoinDate = joinDate;
            this.EndDate = endDate;
            this.Status = status;
        }

        public void Update(DateTime? joinDate, DateTime? endDate, string status)
        {
       
            this.JoinDate = joinDate;
            this.EndDate = endDate;
            this.Status = status;
        }
                
    }
}
