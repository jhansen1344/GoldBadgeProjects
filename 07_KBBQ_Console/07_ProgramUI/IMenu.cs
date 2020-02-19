using _07_KBBQ_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KBBQ_Console._07_ProgramUI
{
    public interface IMenu
    {
        string Description { get; }
        void RunMethod(EventRepo _eventRepo);
    }
}
