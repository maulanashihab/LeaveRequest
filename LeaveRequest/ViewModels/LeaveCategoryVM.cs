using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class LeaveCategoryVM
    {
       

        public string Name { get; set; }
        public int TotalDays { get; set; }
        public string Description { get; set; }

        public LeaveCategoryVM(string name,int totalDays,string description)
        {
            this.Name = name;
            this.TotalDays = totalDays;
            this.Description = description;
        }


        public void Update(string name, int totalDays,string description)
        {
            this.Name = name;
            this.TotalDays = totalDays;
            this.Description = description;
        }
    }
}
