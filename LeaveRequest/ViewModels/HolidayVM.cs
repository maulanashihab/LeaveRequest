using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class HolidayVM
    {
        //Apa yg dibutuhkan di View dan Model, yg diinputkan secara sadar/manual
        public DateTime? HolidayDate { get; set; }

        public string HolidayName { get; set; }

        public HolidayVM() { } //constructor

        public HolidayVM(string holidayname, DateTime? holidaydate)
        {
            this.HolidayName = holidayname;
            this.HolidayDate = holidaydate;
        }

        public void Update(string holidayname, DateTime? holidaydate)
        {
            this.HolidayName = holidayname;
            this.HolidayDate = holidaydate;
        }
    }
}
