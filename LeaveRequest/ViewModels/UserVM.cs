using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public UserVM() { } //constructor

        public UserVM(int id, string email, string password, int roleid)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.RoleId = roleid;
        }

        public void Update(int id, string email, string password, int roleid) 
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.RoleId = roleid;
        }
    }
}
