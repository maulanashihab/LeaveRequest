using LeaveRequest.Context;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories
{
    class LeaveHistoryRepository
    {
        //bool status = false;
        //ApplicationContext applicationContext = new ApplicationContext();

        //public List<LeaveHistory> Get()
        //{
        //    var get = applicationContext.LeaveHistories.Where(x => x.IsDelete == false).ToList();
        //    return get;
        //}

        //public List<LeaveHistory> Get(string value)
        //{
        //    var get = applicationContext.LeaveHistories.Where(x => (x.Id.ToString().Contains(value) || x.EmployeeId.ToString().Contains(value)|| x.FirstName.Contains(value) || x.LastName.Contains(value) || x.Gender.ToString().Contains(value) || x.FromDate.ToString().Contains(value) || x.LastName.ToString().Contains(value)) && x.IsDelete == false).ToList();
        //    return get;
        //}

        //public LeaveHistory Get(int id)
        //{
        //    var get = applicationContext.LeaveHistories.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
        //    return get;
        //}

        //public bool Insert(LeaveHistoryVM leaveHistoryVM)
        //{
        //    var push = new LeaveHistory(leaveHistoryVM);
        //    applicationContext.LeaveHistories.Add(push);
        //    var result = applicationContext.SaveChanges();
        //    return result > 0;
        //}

        //public bool Update(int id, LeaveHistoryVM leaveHistoryVM)
        //{
        //    var get = Get(id);
        //    get.Update(leaveHistoryVM);
        //    applicationContext.Entry(get).State = EntityState.Modified;
        //    var result = applicationContext.SaveChanges();
        //    return result > 0;
        //}

        //public bool Delete(int id)
        //{
        //    var get = Get(id);
        //    get.Delete();
        //    applicationContext.Entry(get).State = EntityState.Modified;
        //    var result = applicationContext.SaveChanges();
        //    return result > 0;
        //}
    }
}
