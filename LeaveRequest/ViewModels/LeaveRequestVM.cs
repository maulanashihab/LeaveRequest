














using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class LeaveRequestVM
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate {get;set;}
        public string Reason { get; set; }
        public string ApproverComments { get; set; }
        public string Status { get; set; }
        public int Employees_Id { get; set; }
        public int Leave_Categories_Id { get; set; } 

        public LeaveRequestVM(DateTime? fromDate, DateTime? toDate, string reason, string approverComments, string status, int employees_Id,int leave_Categories_Id)
        {
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.Reason = reason;
            this.ApproverComments = approverComments;
            this.Status = status;
            this.Employees_Id = employees_Id;
            this.Leave_Categories_Id = leave_Categories_Id;
        }
        public void Update(DateTime? fromDate, DateTime? toDate, string reason, string approverComments, string status, int employees_Id, int leave_Categories_Id)
        {
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.Reason = reason;
            this.ApproverComments = approverComments;
            this.Status = status;
            this.Employees_Id = employees_Id;
            this.Leave_Categories_Id = leave_Categories_Id;
        }
       
    }
}