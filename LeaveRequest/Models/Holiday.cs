using LeaveRequest.Core;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Models
{
    public class Holiday : BaseModel
    {
        public DateTime? HolidayDate { get; set; }

        public string HolidayName { get; set; }

        public Holiday() { }

        public Holiday(HolidayVM holidayVM)
        {
            this.HolidayName = holidayVM.HolidayName;
            this.HolidayDate = holidayVM.HolidayDate;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update(HolidayVM holidayVM)
        {
            this.HolidayName = holidayVM.HolidayName;
            this.HolidayDate = holidayVM.HolidayDate;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
