using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KBadges_Class
{
    public class Badge
    {
        public Badge() { }
        public Badge(int id, List<string> doorList)
        {
            ID = id;
            DoorList = doorList;
        }
        public int ID{get;set;}
        public List<string> DoorList { get; set; }
    }
}
