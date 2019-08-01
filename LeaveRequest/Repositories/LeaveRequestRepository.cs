using LeaveRequest.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using LeaveRequest.Context;
using System.Data.Entity;

namespace LeaveRequest.Repositories
{
    class LeaveRequestRepository : ILeaveRequestRepository
    {
        bool status = false;
        ApplicationContext aplicationContext = new ApplicationContext();
        public bool Delete(int id)
        {

            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                aplicationContext.Entry(get).State = EntityState.Modified;
                var result = aplicationContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }

        public List<LeeaveRequest> Get()
        {
            var get = aplicationContext.LeaveRequest.Include("Employee").Include("LeaveCategory").Where(x => x.IsDelete == false ).ToList();
            return get;
        }

        public List<LeeaveRequest> Get(string value)
        {
             var get = aplicationContext.LeaveRequest.Where(x => (x.Id.ToString().Contains(value) || x.FromDate.ToString().Contains(value)|| x.ToDate.ToString().Contains(value)|| x.Reason.Contains(value) 
             || x.ApproverComments.Contains(value) || x.Status.Contains(value)) && x.IsDelete == false).ToList(); 
            return get;
        }

        public LeeaveRequest Get(int id)
        {
            var get = aplicationContext.LeaveRequest.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }
        
        public bool Insert(LeaveRequestVM leaveRequestVM)
        {
            var push = new LeeaveRequest(leaveRequestVM);
            var getEmployee = aplicationContext.Employees.SingleOrDefault(x => x.IsDelete == false && x.Id == leaveRequestVM.Employees);
            push.Employee = getEmployee;
            var getCategory = aplicationContext.LeaveCategories.SingleOrDefault(x => x.IsDelete == false && x.Id == leaveRequestVM.Leave_Categories);
            push.LeaveCategory = getCategory; 
            aplicationContext.LeaveRequest.Add(push);
            var result = aplicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, LeaveRequestVM leaveRequestVM)
        {
            var get = Get(id);
            if (get != null)
            {
                var getEmployee = aplicationContext.Employees.SingleOrDefault(x => x.IsDelete == false && x.Id == leaveRequestVM.Employees);
                get.Employee = getEmployee;
                var getCategory = aplicationContext.LeaveCategories.SingleOrDefault(x => x.IsDelete == false && x.Id == leaveRequestVM.Leave_Categories);
                get.LeaveCategory = getCategory;
                get.Update(leaveRequestVM);
                aplicationContext.Entry(get).State = EntityState.Modified;
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
