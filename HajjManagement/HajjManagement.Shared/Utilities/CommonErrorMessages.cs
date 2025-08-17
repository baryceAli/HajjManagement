using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Utilities
{
    public static class CommonErrorMesages
    {
        public static string NOT_AUTHORIZED_PAGE_ACCESS_Header { get; set; } = "Not Authorized";
        public static string NOT_AUTHORIZED_PAGE_ACCESS_Message { get; set; } = "Sorry! You are not authorized to view this page.";
        public static string NOT_AUTHORIZED_PAGE_ACCESS_Details { get; set; } = "It seems that you don't have the rights to access this page. Please contact the administrator.";
    }
}
