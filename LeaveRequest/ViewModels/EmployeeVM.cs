using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Religion { get; set; }
        public bool MaritalStatus { get; set; }
        public int Num_Of_Children { get; set; }
        public int ManagerId { get; set; }
        public EmployeeVM() { }
        public EmployeeVM(string firstName, string lastName, bool gender, string religion, bool maritalStatus, int numofchildren, int managerId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Religion = religion;
            this.MaritalStatus = maritalStatus;
            this.Num_Of_Children = numofchildren;
            this.ManagerId = managerId;
        }
        public void Update(string firstName, string lastName, bool gender, string religion, bool maritalStatus, int numofchildren, int managerId)
        { 
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Religion = religion;
            this.MaritalStatus = maritalStatus;
            this.Num_Of_Children = numofchildren;
            this.ManagerId = managerId;
        }
    }
}
