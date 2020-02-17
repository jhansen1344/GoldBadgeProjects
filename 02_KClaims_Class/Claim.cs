using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KClaims_Class
{
    
    public enum ClaimType { Car,Home,Theft}
    public class Claim
    {
        public Claim() { }
        public Claim(int id, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime incidentDate, DateTime claimDate) 
        {
            ID = id;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            IncidentDate = incidentDate;
            ClaimDate = claimDate;
        }
        public int ID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime IncidentDate { get; set; } = new DateTime();
        public DateTime ClaimDate { get; set; } = new DateTime();
        public bool IsValid {
            get
            {
                TimeSpan timeSpan = ClaimDate - IncidentDate;
                return (Convert.ToInt32(timeSpan.TotalDays) <= 30);
            }  
         }
    }
}
