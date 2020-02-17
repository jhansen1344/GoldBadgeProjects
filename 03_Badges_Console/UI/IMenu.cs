using _03_KBadges_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console.UI
{
    public interface IMenu
    {
        string Description { get; }
        void RunMethod(BadgeRepository _repo);
    }
}
