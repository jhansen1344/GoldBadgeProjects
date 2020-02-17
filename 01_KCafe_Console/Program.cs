using _01_KCafe_Class;
using _01_KCafeConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KCafe_Console
{
    class Program
    {
        private readonly MenuRepository _menu = new MenuRepository();
        static void Main(string[] args)
        {
            ProgramUI programUI = new ProgramUI();
            programUI.Run();
        }
    }
}
