using LeaveRequest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.ViewModels;

namespace LeaveRequest.Models
{
    public class EmployeeStatus : BaseModel
    {
        public DateTime? JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        

        public EmployeeStatus() { }
        public EmployeeStatus(EmployeeStatusVM employeeStatusVM)
        {
            this.JoinDate = employeeStatusVM.JoinDate;
            this.EndDate = employeeStatusVM.EndDate;
            this.Status = employeeStatusVM.Status;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update(EmployeeStatusVM employeeStatusVM)
        {
            
            this.JoinDate = employeeStatusVM.JoinDate;
            this.EndDate = employeeStatusVM.EndDate;
            this.Status = employeeStatusVM.Status;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }

        
    }
}
