using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Repositories.Interfaces
{
    public interface IHolidayRepository
    {
        List<Holiday> Get();
        Holiday Get(int id);
        List<Holiday> Get(string value);
        bool Insert(HolidayVM holidayVM);
        bool Update(int id, HolidayVM holidayVM);
        bool Delete(int id);
    }
}
