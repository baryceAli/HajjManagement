using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Range(1, int.MaxValue, ErrorMessage = "الرجاء ادخال الفندق")]
        public int HotelId { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        //public Hotel Hotel { get; set; }
        //public Hotel Hotel { get; set; }
    }
}
