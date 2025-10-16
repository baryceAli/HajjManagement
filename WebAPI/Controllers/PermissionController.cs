using Asp.Versioning;
using CoreBusiness;
using CoreBusiness.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Util;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // v1
    [ApiVersion("2.0")] // v2 (future changes)
    public class PermissionController : ControllerBase
    {
        private readonly RoleManager<Role> roleManager;
        private readonly ILogger<RoleController> logger;

        public PermissionController(RoleManager<Role> roleManager, ILogger<RoleController> logger)
        {
            this.roleManager = roleManager;
            this.logger = logger;
        }
        


    }
}
