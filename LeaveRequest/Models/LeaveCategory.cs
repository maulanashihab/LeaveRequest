using LeaveRequest.Core;
using LeaveRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.ViewModels;

namespace LeaveRequest.Models
{
    public class LeaveCategory :BaseModel 
    {
        public string Name { get; set; }
        public int TotalDays { get; set; }
        public string Description { get; set; }

        public LeaveCategory() { }
        public LeaveCategory(LeaveCategoryVM LeaveCategoryVM)
        {
            this.Name = LeaveCategoryVM.Name;
            this.TotalDays = LeaveCategoryVM.TotalDays;
            this.Description = LeaveCategoryVM.Description;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Update(LeaveCategoryVM LeaveCategoryVM)
        {
            this.Name = LeaveCategoryVM.Name;
            this.TotalDays = LeaveCategoryVM.TotalDays;
            this.Description = LeaveCategoryVM.Description;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
