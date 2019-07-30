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
    public class HolidaysController
    {
        IHolidayRepository iHolidayRepository = new HolidayRepository();

        public List<Holiday> Get()
        {
            return iHolidayRepository.Get();
        }
        public Holiday Get(int id)
        {
            return iHolidayRepository.Get(id);
        }
        public List<Holiday> Get(string value)
        {
            return iHolidayRepository.Get(value);
        }
        public bool Insert(HolidayVM holidayVM)
        {
            return iHolidayRepository.Insert(holidayVM);
        }
        public bool Update(int id, HolidayVM holidayVM)
        {
            return iHolidayRepository.Update(id, holidayVM);
        }
        public bool Delete(int id)
        {
            return iHolidayRepository.Delete(id);
        }
    }
}
