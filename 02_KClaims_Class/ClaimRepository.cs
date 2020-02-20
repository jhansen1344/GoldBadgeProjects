using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaims_Class
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimQ = new Queue<Claim>();

        //Add
        public bool AddClaim(int id, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime incidentDate, DateTime claimDate)
        {
           Claim newClaim = new Claim(id, typeOfClaim, description, claimAmount, incidentDate, claimDate);
           _claimQ.Enqueue(newClaim);
            return true;
        }
        //Return all
        public Queue<Claim> GetClaims()
        {
            return _claimQ;
        }
        //Return next
        public Claim DairyQueenNextClaim()
        {
            return _claimQ.Dequeue();
        }
        //Look at next
        public Claim PeekNextClaim()
        {
            if(_claimQ.Count>0)
            {
                return _claimQ.Peek();
            }
            return null;
        }  
    }
}
