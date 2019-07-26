﻿using LeaveRequest.Models;
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

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AvailableLeave> AvailableLeave { get; set; }
    }
}
