using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Data
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }

        public abstract void Display();
    }
}
