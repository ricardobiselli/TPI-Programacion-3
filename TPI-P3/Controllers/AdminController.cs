    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models.Users;
    using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
    {
        [Route("api/Admins")]
        [ApiController]
        [Authorize(Roles = "superadmin")]
        public class AdminController : ControllerBase
        {
            private readonly IAdminService _adminService;

            public AdminController(IAdminService adminService)
            {
                _adminService = adminService;
            }

            [HttpPost("register")]
            public async Task<ActionResult<Admin>> AddAsync([FromBody] Admin admin)
            {
                await _adminService.AddAsync(admin);
                return Ok(admin);
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Admin>>> GetAllAsync()
            {
                var admins = await _adminService.GetAllAsync();
                if (admins == null)
                {
                    return NotFound();
                }
                return Ok(admins);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Admin>> GetByIdAsync([FromRoute] int id)
            {
                var admin = await _adminService.GetByIdAsync(id);
                if (admin == null)
                {
                    return NotFound();
                }
                return Ok(admin);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteAsync([FromRoute] int id)
            {
                var admin = await _adminService.GetByIdAsync(id);
                if (admin == null)
                {
                    return NotFound();
                }

                await _adminService.DeleteAsync(id);
                return NoContent();
            }

            [HttpPut("{id}")]
            public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] Admin updatedAdmin)
            {
                var admin = await _adminService.GetByIdAsync(id);
                if (admin == null)
                {
                    return NotFound();
                }

                await _adminService.UpdateAsync(id, updatedAdmin);
                return NoContent();
            }
        }
    }
