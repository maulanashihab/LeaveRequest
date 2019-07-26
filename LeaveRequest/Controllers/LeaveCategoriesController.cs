using LeaveRequest.Models;
using LeaveRequest.Repositories;
using LeaveRequest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.ViewModels;
using LeaveRequest.Repositories.Interfaces;

namespace LeaveRequest.Controllers
{
    public class LeaveCategoriesController
    {
        ILeaveCategoryRepository iLeaveCategoryRepository = new LeaveCategoryRepository();
        public List<LeaveCategory> Get()
        {
            return iLeaveCategoryRepository.Get();
        }
        public LeaveCategory Get(int id)
        {
            return iLeaveCategoryRepository.Get(id);
        }
        public List<LeaveCategory> Get(string value)
        {
            return iLeaveCategoryRepository.Get(value);
        }
        public bool Insert(LeaveCategoryVM leaveCategoryVM)
        {
            return iLeaveCategoryRepository.Insert(leaveCategoryVM);
        }
        public bool Update(int id, LeaveCategoryVM leaveCategoryVm)
        {
            return iLeaveCategoryRepository.Update(id, leaveCategoryVm);
        }
        public bool Delete(int id)
        {
            return iLeaveCategoryRepository.Delete(id);
        }

  
    }
}
