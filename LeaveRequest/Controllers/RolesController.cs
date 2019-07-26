using LeaveRequest.Models;
using LeaveRequest.Repositories;
using LeaveRequest.Repositories.Interfaces;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Controllers
{
    public class RolesController
    {
        IRoleRepository iRoleRepository = new RoleRepository();

        public List<Role> Get()
        {
            return iRoleRepository.Get();
        }

        public Role Get(int id)
        {
            return iRoleRepository.Get(id);
        }

        public List<Role> Get(string value)
        {
            return iRoleRepository.Get(value);
        }

        public bool Insert(RoleVM roleVM)
        {
            return iRoleRepository.Insert(roleVM);
        }

        public bool Update(int id, RoleVM roleVM)
        {
            return iRoleRepository.Update(id, roleVM);
        }
        public bool Delete(int id)
        {
            return iRoleRepository.Delete(id);
        }
    }
}
