using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> Get();
        Role Get(int id);
        List<Role> Get(string value);
        bool Insert(RoleVM roleVM);
        bool Update(int id, RoleVM roleVM);
        bool Delete(int id); 
    }
}
