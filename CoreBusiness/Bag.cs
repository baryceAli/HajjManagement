using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Bag
    {
        public int BagId { get; set; }
        public string Name { get; set; }
        public int? ContractId { get; set; }
        //public Contract? Contract { get; set; }
        //public Contract Contract { get; set; }
        public int? SupervisorId { get; set; }
        //public int UserId { get; set; }
        //public User? Supervisor { get; set; }
        //public User User { get; set; }
        //public ICollection<Guest>? Guests { get; set; }
    }
}
