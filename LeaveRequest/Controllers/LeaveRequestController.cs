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
    public class LeaveRequestController
    {
        ILeaveRequestRepository iLeaveRequesRepository = new LeaveRequestRepository();
        public List<LeeaveRequest> Get()
        {
            return iLeaveRequesRepository.Get();
        }
        public LeeaveRequest Get(int id)
        {
            return iLeaveRequesRepository.Get(id);
        }
        public List<LeeaveRequest> Get(string value)
        {
            return iLeaveRequesRepository.Get(value);
        }
        public bool Insert(LeaveRequestVM leaveRequstVM)
        {
            return iLeaveRequesRepository.Insert(leaveRequstVM);
        }
        public bool Update(int id, LeaveRequestVM leaveRequestVM)
        {
            return iLeaveRequesRepository.Update(id, leaveRequestVM);
        }
        public bool Delete(int id)
        {
            return iLeaveRequesRepository.Delete(id);
        }

    }
}
