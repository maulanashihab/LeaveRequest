﻿using LeaveRequest.Core;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Models
{
    public class Role : BaseModel
    {
        public Role() { }
        public Role(RoleVM roleVM)
        {
            this.Name = roleVM.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update(RoleVM roleVM)
        {
            this.Name = roleVM.Name;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }
        
        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }

        public string Name { get; set; }
    }
}
