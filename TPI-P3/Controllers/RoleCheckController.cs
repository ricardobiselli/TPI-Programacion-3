using Microsoft.AspNetCore.Mvc;

namespace TPI_P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class RoleCheckController : ControllerBase
    {
        protected bool IsAdminOrSuperAdmin()
        {
            if (User.IsInRole("admin") || User.IsInRole("superadmin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsClient()
        {
            if (User.IsInRole("client"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsSuperAdmin()
        {
            if (User.IsInRole("superadmin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsAdmin()
        {
            if (User.IsInRole("admin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
