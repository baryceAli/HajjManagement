using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Guest
    {
        public int GuestId { get; set; }
        //public int CountryId { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int BagId { get; set; }
        //public Bag? Bag { get; set; }
        //public Country? Country { get; set; }
        public int AdministrativeDivisionId { get; set; }
        //public AdministrativeDivision AdministrativeDivision { get; set; }
        public int AdministrativeDivisionTypeId { get; set; }
        //public AdministrativeDivisionType? AdministrativeDivisionType { get; set; }
        public int? SupervisorId { get; set; }
        //public int UserId { get; set; }
        //public User Supervisor { get; set; }
        //public User User { get; set; }
    }
}
