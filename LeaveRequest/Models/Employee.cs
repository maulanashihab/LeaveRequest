using LeaveRequest.Core;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Models
{
    public class Employee : BaseModel
    {
        public Employee() { }
        public Employee(EmployeeVM employeeVM)
        {
            this.FirstName = employeeVM.FirstName;
            this.LastName = employeeVM.LastName;
            this.Gender = employeeVM.Gender;
            this.Religion = employeeVM.Religion;
            this.MaritalStatus = employeeVM.MaritalStatus;
            this.Num_Of_Children = employeeVM.Num_Of_Children;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update(EmployeeVM employeeVM)
        {
            this.FirstName = employeeVM.FirstName;
            this.LastName = employeeVM.LastName;
            this.Gender = employeeVM.Gender;
            this.Religion = employeeVM.Religion;
            this.MaritalStatus = employeeVM.MaritalStatus;
            this.Num_Of_Children = employeeVM.Num_Of_Children;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Religion { get; set; }
        public bool MaritalStatus { get; set; }
        public int Num_Of_Children { get; set; }
        public Employee Manager { get; set; } //foreign key self join
    }
}
