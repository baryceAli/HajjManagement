using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Log
    {
        public int LogId { get; set; }
        public string TableName { get; set; }
        public string OperationType { get; set; }
        public string StateBeforeActoin { get; set; }
        public string StateAfterAction { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        public int UserId { get; set; }
        //public User? User { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
