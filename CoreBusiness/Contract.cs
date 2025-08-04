using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Contract
    {
        public int ContractId { get; set; }
        public string ContractNo { get; set; }
        public int Beds { get; set; }
        public int UsedBeds { get; set; }
        public int HotelId { get; set; }
        //public Hotel Hotel { get; set; }
        //public Hotel Hotel { get; set; }
    }
}
