using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> Get();
        User Get(int id);
        List<User> Get(string value);
        bool Insert(UserVM userVM);
        bool Update(int id, UserVM userVM);
        bool Delete(int id);
    }
}
