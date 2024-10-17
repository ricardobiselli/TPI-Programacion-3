using Application.Interfaces;
using Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/Admins")]
        [ApiController]
        //[Authorize(Roles = "superadmin")]
        public class AdminController : ControllerBase
        {
            private readonly IAdminService _adminService;

            public AdminController(IAdminService adminService)
            {
                _adminService = adminService;
            }

            [HttpPost("register")]
            public  ActionResult<Admin> AddAsync([FromBody] Admin admin)
            {
                 _adminService.Add(admin);
                return Ok(admin);
            }

            [HttpGet]
            public  ActionResult<IEnumerable<Admin>> GetAll()
            {
                var admins =  _adminService.GetAll();
                if (admins == null)
                {
                    return NotFound();
                }
                return Ok(admins);
            }

            [HttpGet("{id}")]
            public  ActionResult<Admin> GetById([FromRoute] int id)
            {
                var admin =  _adminService.GetById(id);
                if (admin == null)
                {
                    return NotFound();
                }
                return Ok(admin);
            }

            [HttpDelete("{id}")]
            public  ActionResult Delete([FromRoute] int id)
            {
                var admin =  _adminService.GetById(id);
                if (admin == null)
                {
                    return NotFound();
                }

                 _adminService.Delete(id);
                return NoContent();
            }

            [HttpPut("{id}")]
            public ActionResult Update([FromRoute] int id, [FromBody] Admin updatedAdmin)
            {
                var admin =  _adminService.GetById(id);
                if (admin == null)
                {
                    return NotFound();
                }

                 _adminService.Update(id, updatedAdmin);
                return NoContent();
            }
        }
    }
