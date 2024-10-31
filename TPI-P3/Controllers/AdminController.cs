using Application.Exceptions;
using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPI_P3.Controllers;


namespace Api.Controllers
{
    [Route("api/Admins")]
    [ApiController]
    [Authorize(Roles = "superadmin")]
    public class AdminController : RoleCheckController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("Create-New-Admin")]
        public ActionResult<AddNewAdminDTO> CreateAdmin(AddNewAdminDTO addNewAdminDTO)
        {
            if (!IsSuperAdmin())
            {
                return Forbid();
            }


            var createdAdmin = _adminService.Add(addNewAdminDTO);

            return Ok(createdAdmin);

        }
        [HttpGet("Get-All")]
        public ActionResult<List<ShowAdminDto>> GetAll()
        {
            var admins = _adminService.GetAll();

            var ListOfAdminsDTO = admins.Where(a => a.State == Domain.Enums.EntitiesState.Active).Select(ShowAdminDto.Create).ToList();
            if (!ListOfAdminsDTO.Any())
            {
                return NotFound(new { message = "list of admins is empty" });
            }
            return Ok(ListOfAdminsDTO);

        }

        [HttpGet("Get-One/{id}")]
        public ActionResult<ShowAdminDto> GetById([FromRoute] int id)
        {

            var admin = _adminService.GetById(id);
            var adminDTO = ShowAdminDto.Create(admin);
            return Ok(adminDTO);

        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {

            var admin = _adminService.GetById(id);
            _adminService.Delete(id);
            return NoContent();

        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] UpdateAdminDTO updateAdminDTO)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            _adminService.Update(updateAdminDTO);
            return NoContent();

        }
    }
}



