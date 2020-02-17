using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KBadges_Class
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int,List<string>>();
        public bool AddBadge(int id, List<string> doorList)
        {
            if(!_badgeDictionary.ContainsKey(id))
            {
                Badge newBadge = new Badge(id, doorList);
                _badgeDictionary.Add(newBadge.ID, newBadge.DoorList);
                return true;
            }
            return false;
        }

        public Dictionary<int,List<string>> GetAllBadges()
        {
            return _badgeDictionary;
        }

        //Return list doors access
        public List<string> GetDoorAccess(int id)
        {
            if(_badgeDictionary.ContainsKey(id))
            {
                List<string> currentDoors = new List<string>();
                currentDoors = _badgeDictionary[id];
                return currentDoors;
            }
            return null;
        }

        //Update Door Access
        public List<string> UpdateDoorAccess(int id, string door)
        {
            List<string> currentDoors = GetDoorAccess(id);
            if(currentDoors!=null)
            {
                foreach (var item in currentDoors)
                {
                    if (item.ToUpper() == door.ToUpper())
                    {
                        currentDoors.Remove(door.ToUpper());
                        return currentDoors;
                    }
                }
                currentDoors.Add(door.ToUpper());
            }
            return currentDoors;
        }
        
        //Remove All Door Access
        public bool RemoveAllDoorAccess(int id)
        {
            List<string> currentDoors = GetDoorAccess(id);
            if (currentDoors != null)
            {
                currentDoors.Clear();
                return true;
            }
            return false;
        }
    }
}
