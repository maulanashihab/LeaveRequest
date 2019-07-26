    using LeaveRequest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("LeaveRequest") { }

        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<LeaveHistory> LeaveHistories { get; set; }

    }
}
