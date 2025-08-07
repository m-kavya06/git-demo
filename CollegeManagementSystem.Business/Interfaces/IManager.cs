using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Business.Interfaces
{
    public interface IManager<T>
    {
        void Add();
        void View();
        void Update();
        void Delete();

    }
}
