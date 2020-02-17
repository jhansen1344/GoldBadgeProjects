using _02_KClaims_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaims_Console._02_ProgramUI
{
    public interface IMenu
    {
        string Description { get; }
        void RunMethod(ClaimRepository _repo);
    }
}
