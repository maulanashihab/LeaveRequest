using LeaveRequest.Repository;
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
    public class EmployeeStatusRepository : IEmployeeStatusRepository
    {
        bool status = false;
        ApplicationContext aplicationContext = new ApplicationContext();

     

        public List<EmployeeStatus> Get()
        {   
            //context .nama_table.isi
            var get = aplicationContext.EmployeeStatuses.Where(x=>x.IsDelete== false).ToList();
            return get;
        }

        public List<EmployeeStatus> Get(string value)
        {
            var get = aplicationContext.EmployeeStatuses.Where(x => (x.Id.ToString().Contains(value) || x.JoinDate.ToString().Contains(value) /*|| x.JoinDate.Year.ToString().Contains(value) || x.JoinDate.Day.ToString().Contains(value)*/ || x.Status.Contains(value)) && x.IsDelete == false).ToList(); 
            return get;
        }

        public EmployeeStatus Get(int id)
        {
            //SingleOrDefault itu menampilkan minimal satu atau null, kalau lebih tidak bisa
            var get = aplicationContext.EmployeeStatuses.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(EmployeeStatusVM employeeStatusVM)
        {
            
            var push = new EmployeeStatus(employeeStatusVM);
            aplicationContext.EmployeeStatuses.Add(push);
            var result = aplicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, EmployeeStatusVM employeeStatusVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(employeeStatusVM);
                aplicationContext.Entry(get).State = EntityState.Modified;
                var result = aplicationContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
            
        }
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
    }
}
