using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveRequest.ViewModels
{
    public class ParameterVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public ParameterVM() { }

        public ParameterVM(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }

        public void Update(int id, string name, int value)
        {
            this.Id = id;
            this.Name = name;
            this.Value = value;
        }
    }
}
