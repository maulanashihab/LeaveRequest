using LeaveRequest.Context;
using LeaveRequest.Models;
using LeaveRequest.Repositories.Interfaces;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories
{
    public class UserRepository : IUserRepository
    {
        bool status = false;
        ApplicationContext applicationContext = new ApplicationContext();
        EmployeeVM employeeVM = new EmployeeVM();

        public List<User> Get()
        {
            var get = applicationContext.Users.Where(x => x.IsDelete == false).Include("Role").ToList();
            return get;
        }

        public List<User> Get(string value)
        {
            var get = applicationContext.Users.Where(x => ((x.Id.ToString().Contains(value))  || x.Email.Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }

        public User Get(int id)
        {
            var get = applicationContext.Users.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(UserVM userVM)
        {
            var push = new User(userVM);
            if(push != null)
            {
                var getRole = applicationContext.Roles.SingleOrDefault(x => x.IsDelete == false && x.Id == userVM.RoleId);
                push.Role = getRole;
                applicationContext.Users.Add(push);
                var result = applicationContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
            
        }

        public bool Update(int id, UserVM userVM)
        {
            var get = Get(userVM.Id);
            get.Update(userVM);
            applicationContext.Entry(get).State = EntityState.Modified;
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
