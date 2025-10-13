using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "الرجاء ادخال الحقيبة")]
        public int BagId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "الرجاء ادخال الوحدة الإدارية")]
        public int AdministrativeDivisionId { get; set; }
        public int? SupervisorId { get; set; }
    }
}
