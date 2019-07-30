using LeaveRequest.Context;
using LeaveRequest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using System.Data.Entity;
using LeaveRequest.Repositories.Interfaces;

namespace LeaveRequest.Repositories
{
    public class LeaveCategoryRepository : ILeaveCategoryRepository
    {
        bool status = false;
        ApplicationContext aplicationContext = new ApplicationContext();
        public bool Delete(int id)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                aplicationContext.Entry(get).State = System.Data.Entity.EntityState.Modified;
                var result = aplicationContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }

        public List<LeaveCategory> Get()
        {
            var get = aplicationContext.LeaveCategories.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public List<LeaveCategory> Get(string value)
        {
            var get = aplicationContext.LeaveCategories.Where(x => (x.Id.ToString().Contains(value) || x.Name.Contains(value) || x.TotalDays.ToString().Contains(value) || x.Description.Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }

        public LeaveCategory Get(int id)
        {
            var get = aplicationContext.LeaveCategories.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(LeaveCategoryVM leaveCategoryVM)
        {
            var push = new LeaveCategory(leaveCategoryVM);
            aplicationContext.LeaveCategories.Add(push);
            var result = aplicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int  id, LeaveCategoryVM leaveCategoryVm)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(leaveCategoryVm);
                aplicationContext.Entry(get).State = System.Data.Entity.EntityState.Modified;
                var result = aplicationContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
