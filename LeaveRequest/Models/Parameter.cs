using LeaveRequest.Core;
using LeaveRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.Models
{
    public class Parameter : BaseModel
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public Parameter() { }

        public Parameter(ParameterVM parameterVM)
        {
            this.Name = parameterVM.Name;
            this.Value = parameterVM.Value;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Update(ParameterVM parameterVM)
        {
            this.Name = parameterVM.Name;
            this.Value = parameterVM.Value;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
