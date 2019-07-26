using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Interfaces
{
    public interface IAvailableLeaveRepository
    {
        List<AvailableLeave> Get();
        AvailableLeave Get(int id);
        List<AvailableLeave> Get(string value);
        bool Insert(AvailableLeaveVM availableLeaveVM);
        bool Update(int id, AvailableLeaveVM availableLeaveVM);
        bool Delete(int id);
    }
}
