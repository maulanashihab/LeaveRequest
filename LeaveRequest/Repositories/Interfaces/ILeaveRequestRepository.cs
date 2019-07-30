using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.Models;

namespace LeaveRequest.Repositories.Interfaces
{
    public interface ILeaveRequestRepository
    {
        List<LeeaveRequest> Get();
        
        LeeaveRequest Get(int id);
        List<LeeaveRequest> Get(string value);

        bool Insert(LeaveRequestVM leaveRequestVM);
        bool Update(int id, LeaveRequestVM leaveRequestVM);
        bool Delete(int id);
    }
}
