using LeaveRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.ViewModels;

namespace LeaveRequest.Repositories.Interfaces
{
    public interface ILeaveCategoryRepository
    {
        List<LeaveCategory> Get();
        LeaveCategory Get(int id);
        List<LeaveCategory> Get(string value);

        bool Delete(int id);
        bool Update(int id, LeaveCategoryVM leaveCategoryVm);
        bool Insert(LeaveCategoryVM leaveCategoryVM);
    }
}
