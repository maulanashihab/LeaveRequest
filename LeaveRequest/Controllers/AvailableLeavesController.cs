using LeaveRequest.Models;
using LeaveRequest.Repositories;
using LeaveRequest.Repositories.Interfaces;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Controllers
{
    public class AvailableLeavesController
    {
        IAvailableLeaveRepository iAvailableLeaveRepository = new AvailableLeaveRepository();
        public List<AvailableLeave> Get()
        {
            return iAvailableLeaveRepository.Get();
        }
        public AvailableLeave Get(int id)
        {
            return iAvailableLeaveRepository.Get(id);
        }
        public List<AvailableLeave> Get(string value)
        {
            return iAvailableLeaveRepository.Get(value);
        }
        bool Insert(AvailableLeaveVM availableLeaveVM)
        {
            return iAvailableLeaveRepository.Insert(availableLeaveVM);
        }
        bool Update(int id, AvailableLeaveVM availableLeaveVM)
        {
            return iAvailableLeaveRepository.Update(id, availableLeaveVM);
        }
        bool Delete(int id)
        {
            return iAvailableLeaveRepository.Delete(id);
        }
    }
}
