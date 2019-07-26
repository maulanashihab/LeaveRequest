﻿using LeaveRequest.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveRequest.Models;
using LeaveRequest.ViewModels;
using LeaveRequest.Context;
using System.Data.Entity;

namespace LeaveRequest.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        bool status = false;
        ApplicationContext applicationContext = new ApplicationContext();
        public bool Delete(int id)
        {
            var get = Get(id);
            get.Delete();
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public List<Employee> Get()
        {
            var get = applicationContext.Employee.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public List<Employee> Get(string value) //for search data by value id, firstname & lastname.
        {
            var get = applicationContext.Employee.Where(x => (x.Id.ToString().Contains(value) || x.FirstName.Contains(value) || x.LastName.Contains(value) || x.Gender.Contains(value)) && x.IsDelete == false).ToList();
            return get;
        }

        public Employee Get(int id)
        {
            var get = applicationContext.Employee.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(EmployeeVM employeeVM)
        {
            var push = new Employee(employeeVM);
            var getEmployee = applicationContext.Employee.SingleOrDefault(x => x.IsDelete == false && x.Id == employeeVM.ManagerId);
            push.Manager = getEmployee;
            applicationContext.Employee.Add(push);
            var result = applicationContext.SaveChanges();
            return result > 0;
        }

        public bool Update(int id, EmployeeVM employeeVM)
        {
            var get = Get(id);
            get.Update(employeeVM);
            applicationContext.Entry(get).State = EntityState.Modified;
            var result = applicationContext.SaveChanges();
            return result > 0;
        }
    }
}