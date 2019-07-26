using LeaveRequest.Core;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Models
{
    public class LeeaveRequest: BaseModel
    {
       public DateTime? FromDate { get; set; }
       public DateTime? ToDate { get; set; }
        public string Reason { get; set; }
        public string ApproverComments { get; set; }
        public string Status { get; set; }
        public int Employees_Id { get; set; }
        public LeaveCategory LeaveCategory { get; set; }//foreign key join

        public LeeaveRequest() { }
        public LeeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            this.FromDate = leaveRequestVM.FromDate;
            this.ToDate = leaveRequestVM.ToDate;
            this.Reason = leaveRequestVM.Reason;
            this.ApproverComments = leaveRequestVM.ApproverComments;
            this.Status = leaveRequestVM.Status;
            this.Employees_Id = leaveRequestVM.Employees_Id;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Update(LeaveRequestVM leaveRequestVM)
        {
            this.FromDate = leaveRequestVM.FromDate;
            this.ToDate = leaveRequestVM.ToDate;
            this.Reason = leaveRequestVM.Reason;
            this.ApproverComments = leaveRequestVM.ApproverComments;
            this.Status = leaveRequestVM.Status;
            this.Employees_Id = leaveRequestVM.Employees_Id;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
