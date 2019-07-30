using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Repository
{
    public interface IEmployeeStatusRepository
    {
        List<EmployeeStatus> Get();
        EmployeeStatus Get(int id);
        List<EmployeeStatus> Get(string value);

        bool Insert(EmployeeStatusVM employeeStatusVM);
        bool Update(int id, EmployeeStatusVM employeeStatusVM);
        bool Delete(int id);

    }
}
