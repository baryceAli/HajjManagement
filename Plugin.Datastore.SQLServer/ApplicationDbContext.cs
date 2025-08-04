using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Datastore.SQLServer
{
    public class ApplicationDbContext: IdentityDbContext<User, Role, int>
    {
    }
}
