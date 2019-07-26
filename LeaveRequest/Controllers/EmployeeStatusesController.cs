using LeaveRequest.Models;
using LeaveRequest.Repositories;
using LeaveRequest.Repository;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Controllers
{
    public class EmployeeStatusesController
    {
        IEmployeeStatusRepository iEmployeeStatusRepository = new EmployeeStatusRepository();
        public List<EmployeeStatus> Get()
        {
            return iEmployeeStatusRepository.Get();
        }
        public EmployeeStatus Get(int id)
        {
            return iEmployeeStatusRepository.Get(id);
        }
        public List<EmployeeStatus> Get(string value)
        {
            return iEmployeeStatusRepository.Get(value);
        }
        public bool Insert(EmployeeStatusVM employeeStatusVM)
        {
            return iEmployeeStatusRepository.Insert(employeeStatusVM);
        }
        public bool Update(int id, EmployeeStatusVM employeeStatusVM)
        {
            return iEmployeeStatusRepository.Update(id, employeeStatusVM);
        }
        public bool Delete(int id)
        {
            return iEmployeeStatusRepository.Delete(id);
        }

    }
}
