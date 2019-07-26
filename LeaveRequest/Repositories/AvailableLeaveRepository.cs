using LeaveRequest.Context;
using LeaveRequest.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using System.Data.Entity;

namespace LeaveRequest.Repositories
{
    public class AvailableLeaveRepository : IAvailableLeaveRepository
    {
        bool status = false;
        ApplicationContext applicationContext = new ApplicationContext();

        public List<AvailableLeave> Get()
        {
            var get = applicationContext.AvailableLeave.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public AvailableLeave Get(int id)
        {
            var get = applicationContext.AvailableLeave.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public List<AvailableLeave> Get(string value)
        {
            var get = applicationContext.AvailableLeave.Where(x => (x.Id.ToString().Contains(value) || x.ThisYear.ToString().Contains(value) || x.LastYear.ToString().Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(AvailableLeaveVM availableLeaveVM)
        {
            var push = new AvailableLeave(availableLeaveVM);
            applicationContext.AvailableLeave.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, AvailableLeaveVM availableLeaveVM)
        {
            var push = new AvailableLeave(availableLeaveVM);
            applicationContext.AvailableLeave.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Delete(int id)
        {
            var get = Get(id);
            get.Delete();
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}
