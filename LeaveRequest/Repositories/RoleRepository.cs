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
    public class RoleRepository : IRoleRepository
    {
        bool status = false;
        ApplicationContext applicationContext = new ApplicationContext();

        public bool Delete(int id)
        {
            var get = Get(id);
            if(get != null)
            {
                get.Delete();
                applicationContext.Entry(get).State = EntityState.Modified;
                var result = applicationContext.SaveChanges();
                return result > 0;
            }else
            {
                return false;
            }
            
        }

        public List<Role> Get()
        {
            var get = applicationContext.Roles.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public List<Role> Get(string value)
        {
            var get = applicationContext.Roles.Where(x => (x.Id.ToString().Contains(value) || x.Name.Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }

        public Role Get(int id)
        {
            var get = applicationContext.Roles.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(RoleVM roleVM)
        {
            var push = new Role(roleVM);
            applicationContext.Roles.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, RoleVM roleVM)
        {
            var get = Get(id);
            if(get != null)
            {
                get.Update(roleVM);
                applicationContext.Entry(get).State = EntityState.Modified;
                var result = applicationContext.SaveChanges();
                return result > 0;
            }else
            {
                return false;
            }
           
        }
    }
}
